using Discord;
using Discord.Interactions;
using IrisBot.Enums;
using IrisBot.Translation;
using System.Data.SQLite;
using System.Text;

namespace IrisBot.Modules
{
    public class MapleggModule : InteractionModuleBase<ShardedInteractionContext>
    {
        [SlashCommand("신용점수", "MAPLE.GG 데이터를 바탕으로 신용점수를 매깁니다")]
        [RequireBotPermission(GuildPermission.EmbedLinks)]
        [RequireBotPermission(GuildPermission.SendMessages)]
        public async Task MapleggSearchAsync(string nickname)
        {
            Translations lang = await TranslationLoader.FindGuildTranslationAsync(Context.Guild.Id);
            EmbedBuilder eb = new EmbedBuilder();
            if (lang != Translations.Korean)
            {
                await RespondAsync("🚫 Sorry, this feature is only supported for Korean discord server.\r\nChange bot language to Korean on this server(/language).", ephemeral: true);
                return;
            }

            UserInfo user = new UserInfo(nickname);
            if (user.IsError)
            {
                await RespondAsync("🚫 MAPLE.GG에서 정보를 가져오는 중 오류가 발생했습니다.", ephemeral: true);
            }
            else if (user.Level == null)
            {
                await RespondAsync($"⚠️ {nickname} 캐릭터는 존재하지 않거나 당일에 닉네임이 변경된 아이디입니다.\r\n인게임에 존재하는 닉네임일 경우 당일에 닉네임을 변경한 사기꾼이므로 거래를 중단하시기 바랍니다.", ephemeral: true);
            }
            else
            {
                eb.WithTitle($"신용점수 조회 결과");
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"- 닉네임: [{nickname}](https://maple.gg/u/{nickname})");
                sb.AppendLine($"- 레벨: {user.Level}");
                if (string.IsNullOrEmpty(user.Guild))
                    sb.AppendLine("- 길드: 없음");
                else
                {
                    if (user.GuildRank == null)
                        sb.AppendLine($"- 길드: {user.Guild} (월드랭킹 없음 / {user.GuildSize} 명)");
                    else
                        sb.AppendLine($"- 길드: {user.Guild} (월드랭킹 {user.GuildRank}위 / {user.GuildSize} 명)");
                }
                    
                sb.AppendLine($"- 직업: {user.Job}");
                if (user.Union == null)
                    sb.AppendLine("- 유니온: 부캐 / 500 이하");
                else
                    sb.AppendLine($"- 유니온: {user.Union}");
                sb.AppendLine($"- 인기도: {user.Popularity}");
                if (user.DojangFloor == null)
                    sb.AppendLine("- 무릉도장: 기록 없음");
                else
                    sb.AppendLine($"- 무릉도장: {user.DojangFloor}층");
                eb.AddField("ℹ️ 캐릭터 정보", sb.ToString());

                if (user.Score <= 30)
                {
                    eb.AddField("신용 점수", $"⚠️ {user.Score}점 - 신용 점수가 매우 낮습니다. 거래에 신중을 가해주세요.");
                }
                else if (user.Score <= 60)
                {
                    eb.AddField("신용 점수", $"⚠️ {user.Score}점 - 신용 점수가 조금 낮습니다. 거래에 신중을 가해주세요.");
                }
                else
                {
                    eb.AddField("신용 점수", $"{user.Score} / 100점");
                }

                if (user.Message.Length > 0)
                    eb.AddField("점수에 반영된 지표", user.Message);

                eb.AddField("거래 전 주의사항 및 사기꾼 패턴",
                    "1. 신용 점수가 낮은것은 신용도가 낮은것을 뜻하며 해당 캐릭터가 사기꾼임을 의미하지 않습니다.\r\n" +
                    "2. 신용 점수는 어떠한 방법으로도 해당 캐릭터를 보증할 수 없습니다. 신용 점수는 반드시 참고용으로만 사용되야합니다.\r\n" +
                    "3. 신용 점수와 더불어 기여도 혹은 서버 내 유명도 등을 확인 후 주관에 따른 종합적인 판단이 필요합니다.\r\n" +
                    "4. 모든 고성능 확성기 상의 거래는 잠재적인 사기의 위험성을 동반합니다.\r\n" +
                    "5. 최근 사기꾼들은 낮은 가격의 통구매 할인 또는 각종 인증으로 피해자를 기만합니다.\r\n" +
                    "6. 판매자의 메소가 계속 줄지 않은채 확성기를 사용한다면 사기로 의심할 수 있습니다.\r\n" +
                    "7. 현금거래 및 계정양도는 메이플스토리 운영정책을 위배합니다. " +
                    "따라서 피해 발생시 어떠한 공식 복구 서비스도 받으실 수 없습니다.");

                eb.WithColor(Color.Purple);
                await RespondAsync("", embed: eb.Build(), ephemeral: true);
            }
        }
    }
}
