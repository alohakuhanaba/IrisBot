using System.Text;
using HtmlAgilityPack;
using IrisBot.Database;
using IrisBot.Interfaces;
using Newtonsoft.Json;

namespace IrisBot
{
    public class ExpHistory
    {
        public string? Date { get; set; }
        public string? Exp { get; set; }
    }

    public class UserInfo : IUser
    {
        public string NickName { get; }
        public int? Level { get; }
        public string? Job { get; }
        public int? Popularity { get; }
        public int? DojangFloor { get; }
        public int? Union { get; }
        public List<ExpHistory>? ExpHistories { get; }
        public string? Guild { get; private set; }
        public int? GuildRank { get; private set; }
        public int? GuildSize { get; private set; }
        public int Score { get; }
        public bool IsError { get; }
        public StringBuilder Message { get; private set; }

        public UserInfo(string nickname)
        {
            NickName = nickname;
            Message = new StringBuilder();

            try
            {    
                string url = $"https://maple.gg/u/{nickname}";
                HtmlWeb web = new HtmlWeb();
                HtmlDocument htmlDoc = Task.Run(async () => { return await web.LoadFromWebAsync(url); }).Result;
                HtmlNodeCollection profile = htmlDoc.DocumentNode.SelectNodes("//ul[@class=\"user-summary-list\"]/li");
                HtmlNodeCollection profile2 = htmlDoc.DocumentNode.SelectNodes("//section[@class=\"box user-summary-box\"]");

                if (profile == null || profile2 == null)
                    return;

                Level = profile[1]?.InnerText?.ParseLevel();
                Job = profile[2]?.InnerText?.Trim();
                Popularity = profile[3]?.InnerText?.ParseInt();
                DojangFloor = profile2[0].SelectSingleNode(".//h1")?.InnerText?.ParseInt();
                Union = profile2[2].SelectSingleNode(".//span[@class=\"user-summary-level\"]")?.InnerText?.ParseInt();
                ExpHistories = AnalyzieExpHistory(htmlDoc); // 최근 경험치 증감폭을 측정함
                AnalyzieGuildInfo(htmlDoc);                 // 길드 이름과 인원수를 측정함
                Score = CalculateScore();
                IsError = false;
            }
            catch (Exception ex)
            {
                Task.Run(async () => { await CustomLog.ExceptionHandler(ex); });
                IsError = true;
            }
        }

        public List<ExpHistory>? AnalyzieExpHistory(HtmlDocument htmlDoc)
        {
            var scripts = htmlDoc.DocumentNode.Descendants("script");
            foreach (var script in scripts)
            {
                if (script.InnerHtml.Contains("expHistories"))
                {
                    var startIndex = script.InnerHtml.IndexOf('[');
                    var endIndex = script.InnerHtml.IndexOf(']');
                    var json = script.InnerHtml.Substring(startIndex, endIndex - startIndex + 1);

                    var expHistories = JsonConvert.DeserializeObject<List<ExpHistory>>(json);
                    return expHistories;
                }
            }
            return null;
        }

        public void AnalyzieGuildInfo(HtmlDocument htmlDoc)
        {
            try
            {
                var divNode = htmlDoc.DocumentNode.SelectSingleNode("//div[contains(@class, 'col-lg-2 col-md-4 col-sm-4 col-6 mt-3')]");
                if (divNode != null)
                {
                    var linkNode = divNode.SelectSingleNode(".//a[@href]");

                    if (linkNode != null)
                    {
                        var hrefValue = linkNode.GetAttributeValue("href", string.Empty);
                        HtmlWeb guild = new HtmlWeb();
                        HtmlDocument guildDoc = guild.Load(hrefValue);
                        HtmlNodeCollection info = guildDoc.DocumentNode.SelectNodes("//div[contains(@class, 'col-lg-25 col-md-4 col-sm-6 col-6 mt-2')]");
                        Guild = linkNode.InnerText;

                        if (info != null)
                        {
                            GuildRank = info[1].SelectSingleNode(".//span")?.InnerText?.ParseInt();
                            GuildSize = info[3].SelectSingleNode(".//span")?.InnerText?.ParseInt();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Task.Run(async () => { await CustomLog.ExceptionHandler(ex); });
            }
        }

        public int CalculateScore()
        {
            int totalScore = 0;

            // 인기도 (만점 10점)
            if (Popularity < 0)
            {
                totalScore = 100;
                Message.AppendLine("- 인기도가 음수입니다.");
            }
            else if (Popularity < 50)
            {
                totalScore += 10;
                Message.AppendLine("- 인기도가 낮습니다.");
            }
            else if (Popularity < 100)
            {
                totalScore += 5;
                Message.AppendLine("- 인기도가 소폭 낮습니다.");
            }

            // 레벨 (만점 15점)
            if (Level < 230)
            {
                totalScore = 100;
                Message.AppendLine("- 레벨이 매우 낮습니다.");
            }
            else if (Level < 250)
            {
                totalScore = 50;
                Message.AppendLine("- 레벨이 낮습니다.");
            }
            else if (Level < 260)
            {
                totalScore += 30;
                Message.AppendLine("- 레벨이 낮습니다.");
            }
            else if (Level < 265)
            {
                totalScore += 10;
            }
            else if (Level < 270)
            {
                totalScore += 5;
            }

            // 길드 (만점 35)
            if (string.IsNullOrEmpty(Guild))
            {
                totalScore += 100;
                Message.AppendLine("- 가입된 길드가 확인되지 않습니다.");
            }
            else
            {
                if (GuildSize < 50)
                {
                    totalScore += 40;
                    Message.AppendLine("- 가입된 길드의 규모가 작습니다 (50명 이하)");
                }
                else if (GuildSize < 75)
                {
                    totalScore += 30;
                    Message.AppendLine("- 가입된 길드의 규모가 작습니다 (75명 이하)");
                }
                else if (GuildSize < 100)
                {
                    totalScore += 20;
                    Message.AppendLine("- 가입된 길드의 규모가 작습니다 (100명 이하)");
                }
            }

            // 최근 활동일 (만점 25점)
            if (ExpHistories == null || ExpHistories.Count < 5)
            {
                totalScore += 100;
                Message.AppendLine("- 최근에 생성된 캐릭터이거나 닉네임 변경 이력이 있습니다.");
            }
            else
            {
                double maxDelta = 0.0;
                List<double> expGap = new List<double>();
                for (int i = 0; i < ExpHistories.Count() - 1; i++)
                {
                    DateTime.TryParse(ExpHistories[i].Date, out DateTime date1);
                    DateTime.TryParse(ExpHistories[i + 1].Date, out DateTime date2);

                    double delta = (date1 - date2).TotalDays;
                    if (maxDelta < delta)
                        maxDelta = delta;
                }

                // 현재 날짜와 제일 최근 경험치 날짜를 뺀 값도 포함
                if (ExpHistories.Count() > 0)
                {
                    DateTime.TryParse(ExpHistories[0].Date, out DateTime date);

                    double delta = (DateTime.Now.Date - date).TotalDays;
                    if (maxDelta < delta)
                        maxDelta = delta;
                }

                if (maxDelta > 364.0)
                {
                    totalScore += 100;
                    Message.AppendLine("- 최근 1년 이상의 장기간 메접 이력이 있습니다.");
                }
                else if (maxDelta > 180.0)
                {
                    totalScore += 100;
                    Message.AppendLine("- 최근 6개월 이상의 장기간 메접 이력이 있습니다.");
                }
                else if (maxDelta > 59.0)
                {
                    totalScore += 100;
                    Message.AppendLine("- 최근 2개월 이상의 장기간 메접 이력이 있습니다.");
                }
                else if (maxDelta > 30.0)
                {
                    totalScore += 50;
                    Message.AppendLine("- 최근 한 달 이상의 메접 이력이 있습니다.");
                }
                else if (maxDelta > 14.0)
                {
                    totalScore += 20;
                    Message.AppendLine("- 최근 2주 이상의 메접 이력이 있습니다.");
                }
            }

            // 유니온 (만점 15점)
            if (Union == null)
            {
                totalScore += 100;
                Message.AppendLine("- 유니온 레벨이 500 이하거나 부캐릭터일 수 있습니다.");
            }
            else if (Union < 6000)
            {
                totalScore += 15;
                Message.AppendLine("- 유니온 레벨이 낮습니다.");
            }
            else if (Union < 7000)
            {
                totalScore += 10;
                Message.AppendLine("- 유니온 레벨이 다소 낮습니다.");
            }
            else if (Union < 8000)
            {
                totalScore += 5;
            }

            return 100 - totalScore < 0 ? 0 : 100 - totalScore; // 점수 합이 100점이 넘을 경우 100점으로 고정
        }
    }
}
