using Discord;
using Discord.Interactions;
using IrisBot.Database;
using IrisBot.Enums;
using IrisBot.Translation;
using System.CodeDom.Compiler;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;

namespace IrisBot.Modules
{
    public class MonsterlifeModule : InteractionModuleBase<ShardedInteractionContext>
    {
        [SlashCommand("몬라조합", "몬스터라이프 도감")]
        [RequireBotPermission(GuildPermission.EmbedLinks)]
        [RequireBotPermission(GuildPermission.SendMessages)]
        public async Task MLRecipeAsync(string info)
        {
            EmbedBuilder eb = new EmbedBuilder();

            switch (info.Replace(" ", ""))
            {
                case "박쥐는사탕을좋아해":
                    eb.WithTitle("📒 몬스터라이프 박쥐는 사탕을 좋아해 (B)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9500529/icon");
                    eb.AddField("잠재능력", "농장 레벨 상승 시 100 와르 획득");
                    eb.AddField("조합법",
                        "[박쥐는 호박을 좋아해(스페셜상자 C)](https://meso.kr/monster.php?n=%EB%B0%95%EC%A5%90%EB%8A%94+%ED%98%B8%EB%B0%95%EC%9D%84+%EC%A2%8B%EC%95%84%ED%95%B4) + [핑크 테니(장난감 B+)](https://meso.kr/monster.php?n=%ED%95%91%ED%81%AC+%ED%85%8C%EB%8B%88)");
                    eb.AddField("수급 난이도", "★☆☆☆☆");
                    eb.WithFooter("채용 추천 직업 : X");
                    break;
                case "예티파라오":
                    eb.WithTitle("📒 몬스터라이프 예티 파라오 (A)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9305408/icon");
                    eb.AddField("잠재능력", "농장의 획득 경험치 15 증가");
                    eb.AddField("조합법",
                        "[예티와 페페(예티와 페페 A)](https://meso.kr/monster.php?n=%EC%98%88%ED%8B%B0%EC%99%80+%ED%8E%98%ED%8E%98) + [파라오 미이라(언데드 A+)](https://meso.kr/monster.php?n=%ED%8C%8C%EB%9D%BC%EC%98%A4+%EB%AF%B8%EC%9D%B4%EB%9D%BC)");
                    eb.AddField("수급 난이도", "★☆☆☆☆");
                    eb.WithFooter("채용 추천 직업 : 농장 40레벨 이하 (추천도 최상)");
                    break;
                case "아우프헤벤":
                    eb.WithTitle("📒 몬스터라이프 아우프헤벤 (A+)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/8220011/icon");
                    eb.AddField("잠재능력", "농장건물의 단위 시간당 생산량 1 증가");
                    eb.AddField("조합법",
                        "[머신 MT-09(아인종 S)](https://meso.kr/monster.php?n=%EB%A8%B8%EC%8B%A0+MT-09) + [이루워터(스페셜상자 A)](https://meso.kr/monster.php?n=%EC%9D%B4%EB%A3%A8%EC%9B%8C%ED%84%B0)");
                    eb.AddField("수급 난이도", "★★☆☆☆");
                    eb.WithFooter("채용 추천 직업 : X");
                    break;
                case "쌍둥이월묘":
                    eb.WithTitle("📒 몬스터라이프 쌍둥이 월묘 (S)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9500530/icon");
                    eb.AddField("잠재능력", "농장 몬스터의 획득 경험치 2 증가");
                    eb.AddField("조합법",
                        "[월묘(스페셜상자 A)](https://meso.kr/monster.php?n=%EC%9B%94%EB%AC%98) + [100일 맞은 커플버섯(버섯 S)](https://meso.kr/monster.php?n=100%EC%9D%BC%EB%A7%9E%EC%9D%80+%EC%BB%A4%ED%94%8C%EB%B2%84%EC%84%AF)");
                    eb.AddField("수급 난이도", "★★☆☆☆");
                    eb.WithFooter("채용 추천 직업 : X");
                    break;
                case "오베론":
                    eb.WithTitle("📒 몬스터라이프 오베론 (S)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/8220012/icon");
                    eb.AddField("잠재능력", "올스탯 +5");
                    eb.AddField("조합법",
                        "[듀나스(스페셜상자 A+)](https://meso.kr/monster.php?n=%EB%93%80%EB%82%98%EC%8A%A4) + [빛의 정령(정령 S)](https://meso.kr/monster.php?n=%EB%B9%9B%EC%9D%98+%EC%A0%95%EB%A0%B9)");
                    eb.AddField("수급 난이도", "★★★☆☆");
                    eb.WithFooter("채용 추천 직업 : 데몬어벤저 제외 전직업군 (추천도 하)");
                    break;
                case "파풀라투스의시계":
                case "파풀":
                case "파풀라투스":
                    eb.WithTitle("📒 몬스터라이프 파풀라투스의 시계 (S)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/8500001/icon");
                    eb.AddField("잠재능력", "올스탯 +5");
                    eb.AddField("조합법",
                        "[파풀라투스(악마 S)](https://meso.kr/monster.php?n=%ED%8C%8C%ED%92%80%EB%9D%BC%ED%88%AC%EC%8A%A4) + [킹 롬바드(골렘 S)](https://meso.kr/monster.php?n=%ED%82%B9+%EB%A1%AC%EB%B0%94%EB%93%9C)");
                    eb.AddField("수급 난이도", "★★☆☆☆");
                    eb.WithFooter("채용 추천 직업 : 데몬어벤저 제외 전직업군 (추천도 하)");
                    break;
                case "검은바이킹":
                case "바이킹":
                    eb.WithTitle("📒 몬스터라이프 검은 바이킹 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/3300110/icon");
                    eb.AddField("잠재능력", "DEX +5, 데미지 +2%");
                    eb.AddField("조합법",
                        "[바이킹 군단(스페셜상자 S)](https://meso.kr/monster.php?n=%EB%93%80%EB%82%98%EC%8A%A4) + [진지한 바이킹(조류 S)](https://meso.kr/monster.php?n=%EB%B9%9B%EC%9D%98+%EC%A0%95%EB%A0%B9)");
                    eb.AddField("수급 난이도", "★★★☆☆");
                    eb.WithFooter("채용 추천 직업 : 전직업 (추천도 중상)");
                    break;
                case "각성한락스피릿":
                case "락스피릿":
                    eb.WithTitle("📒 몬스터라이프 각성한 락 스피릿 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9300890/icon");
                    eb.AddField("잠재능력", "올스탯 +5");
                    eb.AddField("조합법",
                        "[락 스피릿(악마 A+)](https://meso.kr/monster.php?n=%EB%9D%BD+%EC%8A%A4%ED%94%BC%EB%A6%BF) + [부조화의 정령(에르다스 S)](https://meso.kr/monster.php?n=%EB%B6%80%EC%A1%B0%ED%99%94%EC%9D%98+%EC%A0%95%EB%A0%B9)");
                    eb.AddField("수급 난이도", "★★★☆☆");
                    eb.WithFooter("채용 추천 직업 : 데몬어벤저 제외 전직업군 (추천도 하)");
                    break;
                case "마스터잭슨":
                    eb.WithTitle("📒 몬스터라이프 마스터 잭슨 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9300776/icon");
                    eb.AddField("잠재능력", "올스탯 +5");
                    eb.AddField("조합법",
                        "[캡틴 블랙 슬라임(슬라임과 달팽이 SS)](https://meso.kr/monster.php?n=%EC%BA%A1%ED%8B%B4+%EB%B8%94%EB%9E%99+%EC%8A%AC%EB%9D%BC%EC%9E%84) + [도도 (스페셜상자 A)](https://meso.kr/monster.php?n=%EB%8F%84%EB%8F%84)");
                    eb.AddField("수급 난이도", "★★★☆☆");
                    eb.WithFooter("채용 추천 직업 : 전직업 (추천도 하)");
                    break;
                case "강화형베릴":
                case "베릴":
                    eb.WithTitle("📒 몬스터라이프 강화형 베릴 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9300639/icon");
                    eb.AddField("잠재능력", "올스탯 +6");
                    eb.AddField("조합법",
                        "[베릴(스페셜상자 S)](https://meso.kr/monster.php?n=%EB%B2%A0%EB%A6%B4) + [아우프헤벤(스페셜 A+)](https://meso.kr/monster.php?n=%EC%95%84%EC%9A%B0%ED%94%84%ED%97%A4%EB%B2%A4)");
                    eb.AddField("수급 난이도", "★★★☆☆");
                    eb.WithFooter("채용 추천 직업 : 전직업 (추천도 하)");
                    break;
                case "마스터레드너그":
                case "레드너그":
                    eb.WithTitle("📒 몬스터라이프 마스터 레드너그 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/8148012/icon");
                    eb.AddField("잠재능력", "STR +15");
                    eb.AddField("조합법",
                        "[마족 역사(솔져 A+)](https://meso.kr/monster.php?n=%EB%A7%88%EC%A1%B1+%EC%97%AD%EC%82%AC) + [교도관 아니(파충류 SS)](https://meso.kr/monster.php?n=%EA%B5%90%EB%8F%84%EA%B4%80+%EC%95%84%EB%8B%88)");
                    eb.AddField("수급 난이도", "★★★☆☆");
                    eb.WithFooter("채용 추천 직업 : STR 사용 직업군 (추천도 중하)");
                    break;
                case "마스터렐릭":
                case "렐릭":
                    eb.WithTitle("📒 몬스터라이프 마스터 렐릭 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9300774/icon");
                    eb.AddField("잠재능력", "DEX +15");
                    eb.AddField("조합법",
                        "[마족 추격자(솔져 A+)](https://meso.kr/monster.php?n=%EB%A7%88%EC%A1%B1+%EC%B6%94%EA%B2%A9%EC%9E%90) + [구와르의 잔재(식물 SS)](https://meso.kr/monster.php?n=%EA%B5%AC%EC%99%80%EB%A5%B4%EC%9D%98+%EC%9E%94%EC%9E%AC)");
                    eb.AddField("수급 난이도", "★★★☆☆");
                    eb.WithFooter("채용 추천 직업 : DEX 사용 직업군 (추천도 중하)");
                    break;
                case "마스터마르가나":
                case "마르가나":
                    eb.WithTitle("📒 몬스터라이프 마스터 마르가나 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9300773/icon");
                    eb.AddField("잠재능력", "INT +15");
                    eb.AddField("조합법",
                        "[마족 환술사(솔져 A+)](https://meso.kr/monster.php?n=%EB%A7%88%EC%A1%B1+%ED%99%98%EC%88%A0%EC%82%AC) + [호박기사(유령 SS)](https://meso.kr/monster.php?n=%ED%98%B8%EB%B0%95%EA%B8%B0%EC%82%AC)");
                    eb.AddField("수급 난이도", "★★★☆☆");
                    eb.WithFooter("채용 추천 직업 : INT 사용 직업군 (추천도 중하)");
                    break;
                case "마스터히삽":
                case "히삽":
                    eb.WithTitle("📒 몬스터라이프 마스터 히삽 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9300775/icon");
                    eb.AddField("잠재능력", "LUK +15");
                    eb.AddField("조합법",
                        "[마족 약탈자(솔져 A+)](https://meso.kr/monster.php?n=%EB%A7%88%EC%A1%B1+%EC%95%BD%ED%83%88%EC%9E%90) + [에레고스(언데드 SS)](https://meso.kr/monster.php?n=%EC%97%90%EB%A0%88%EA%B3%A0%EC%8A%A4)");
                    eb.AddField("수급 난이도", "★★★☆☆");
                    eb.WithFooter("채용 추천 직업 : LUK 사용 직업군 (추천도 중하)");
                    break;
                case "성장한미르":
                    eb.WithTitle("📒 몬스터라이프 성장한 미르 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9300755/icon");
                    eb.AddField("잠재능력", "올스탯 +20");
                    eb.AddField("조합법",
                        "[성장중인 미르(스페셜 SS)](https://meso.kr/monster.php?n=%EC%84%B1%EC%9E%A5%EC%A4%91%EC%9D%B8+%EB%AF%B8%EB%A5%B4) + [성장 중인 미르(스페셜 SS)](https://meso.kr/monster.php?n=%EC%84%B1%EC%9E%A5%EC%A4%91%EC%9D%B8+%EB%AF%B8%EB%A5%B4)");
                    eb.AddField("수급 난이도", "★★★★★");
                    eb.WithFooter("채용 추천 직업 : 데몬어벤저 제외 전직업군 (추천도 중하), 제논 강력추천");
                    break;
                case "쁘띠라니아":
                case "라니아":
                    eb.WithTitle("📒 몬스터라이프 쁘띠 라니아 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9300883/icon");
                    eb.AddField("잠재능력", "올스탯 +20 (쁘띠 루미너스 빛/어둠/이퀄 3종 모두 보유시)");
                    eb.AddField("조합법",
                        "[쁘띠 루미너스(이퀄리브리엄)(스페셜 SS)](https://meso.kr/monster.php?n=%EC%81%98%EB%9D%A0+%EB%A3%A8%EB%AF%B8%EB%84%88%EC%8A%A4%28%EC%9D%B4%ED%80%84%EB%A6%AC%EB%B8%8C%EB%A6%AC%EC%97%84%29) + [쁘띠 시그너스(스페셜 SS)](https://meso.kr/monster.php?n=%EC%81%98%EB%9D%A0+%EC%8B%9C%EA%B7%B8%EB%84%88%EC%8A%A4)");
                    eb.AddField("수급 난이도", "★★★★☆");
                    eb.WithFooter("채용 추천 직업 : 데몬어벤저 제외 농장 40레벨 이상 전직업군 (추천도 중상), 제논 강력추천");
                    break;
                case "티폰":
                    eb.WithTitle("📒 몬스터라이프 티폰 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/8148000/icon");
                    eb.AddField("잠재능력", "공격력/마력 +1");
                    eb.AddField("조합법",
                        "[크세르크세스(소 SS)](https://meso.kr/monster.php?n=%ED%81%AC%EC%84%B8%EB%A5%B4%ED%81%AC%EC%84%B8%EC%8A%A4) + [프리저(조류 S)](https://meso.kr/monster.php?n=%ED%94%84%EB%A6%AC%EC%A0%80))");
                    eb.AddField("수급 난이도", "★★★☆☆");
                    eb.WithFooter("채용 추천 직업 : 전직업군 (추천도 하)");
                    break;
                case "무공의분신":
                case "무공":
                    eb.WithTitle("📒 몬스터라이프 무공의 분신 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9300350/icon");
                    eb.AddField("잠재능력", "공격력 +3");
                    eb.AddField("조합법",
                        "[선인인형(장난감 S)](https://meso.kr/monster.php?n=%EC%84%A0%EC%9D%B8%EC%9D%B8%ED%98%95) + [태륜(원숭이와 곰 S)](https://meso.kr/monster.php?n=%ED%83%9C%EB%A5%9C))");
                    eb.AddField("수급 난이도", "★★★☆☆");
                    eb.WithFooter("채용 추천 직업 : 공격력 사용 직업군 (추천도 중하)");
                    break;
                case "에피네아":
                    eb.WithTitle("📒 몬스터라이프 에피네아 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/5250007/icon");
                    eb.AddField("잠재능력", "마력 +3");
                    eb.AddField("조합법",
                        "[픽시맘(요정 S)](https://meso.kr/monster.php?n=%ED%94%BD%EC%8B%9C%EB%A7%98) + [고대 슬라임(슬라임과 달팽이 S)](https://meso.kr/monster.php?n=%EA%B3%A0%EB%8C%80+%EC%8A%AC%EB%9D%BC%EC%9E%84))");
                    eb.AddField("수급 난이도", "★★★☆☆");
                    eb.WithFooter("채용 추천 직업 : 마법사 직업군 (추천도 최하)");
                    break;
                case "미르":
                    eb.WithTitle("📒 몬스터라이프 미르 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9300750/icon");
                    eb.AddField("잠재능력", "공격력/마력 +5");
                    eb.AddField("조합법",
                        "[마뇽(용 SS)](https://meso.kr/monster.php?n=%EB%A7%88%EB%87%BD) + [루팡돼지(돼지 SS)](https://meso.kr/monster.php?n=%EB%A3%A8%ED%8C%A1%EB%8F%BC%EC%A7%80))");
                    eb.AddField("수급 난이도", "★★★☆☆");
                    eb.WithFooter("채용 추천 직업 : 전직업군 (추천도 중상, 성장한 미르 채용시 최상)");
                    break;
                case "쁘띠루미너스(어둠)":
                case "어둠루미":
                case "루미어둠":
                    eb.WithTitle("📒 몬스터라이프 쁘띠 루미너스(어둠) (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9300753/icon");
                    eb.AddField("잠재능력", "공격력/마력 +5");
                    eb.AddField("조합법",
                        "[파풀라투스의 시계(스페셜 S)](https://meso.kr/monster.php?n=%ED%8C%8C%ED%92%80%EB%9D%BC%ED%88%AC%EC%8A%A4%EC%9D%98+%EC%8B%9C%EA%B3%84) + [킹슬라임(슬라임과 달팽이 SS)](https://meso.kr/monster.php?n=%ED%82%B9%EC%8A%AC%EB%9D%BC%EC%9E%84))");
                    eb.AddField("수급 난이도", "★★★☆☆");
                    eb.WithFooter("채용 추천 직업 : 전직업군 (추천도 상)");
                    break;
                case "검은마법사의그림자":
                case "검마":
                case "검마그림자":
                    eb.WithTitle("📒 몬스터라이프 검은 마법사의 그림자 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9300806/icon");
                    eb.AddField("잠재능력", "공격력/마력 +6");
                    eb.AddField("조합법",
                        "[마스터 오멘(정령 SS)](https://meso.kr/monster.php?n=%EB%A7%88%EC%8A%A4%ED%84%B0+%EC%98%A4%EB%A9%98) + [쁘띠 루미너스(어둠)(스페셜 SS)](https://meso.kr/monster.php?n=%EC%81%98%EB%9D%A0+%EB%A3%A8%EB%AF%B8%EB%84%88%EC%8A%A4%28%EC%96%B4%EB%91%A0%29))");
                    eb.AddField("수급 난이도", "★★★☆☆");
                    eb.WithFooter("채용 추천 직업 : 전직업군 (추천도 상)");
                    break;
                case "쁘띠루미너스(이퀄리브리엄)":
                case "루미너스이퀄":
                case "이퀄루미":
                    eb.WithTitle("📒 몬스터라이프 쁘띠 루미너스(이퀄리브리엄) (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9300754/icon");
                    eb.AddField("잠재능력", "캐릭터 레벨 20당 공격력/마력 +1 (% 효과 미적용)");
                    eb.AddField("조합법",
                        "[쁘띠 루미너스(빛)(스페셜상자 SS)](https://meso.kr/monster.php?n=%EC%81%98%EB%9D%A0+%EB%A3%A8%EB%AF%B8%EB%84%88%EC%8A%A4%28%EB%B9%9B%29) + [쁘띠 루미너스(어둠)(스페셜 SS)](https://meso.kr/monster.php?n=%EC%81%98%EB%9D%A0+%EB%A3%A8%EB%AF%B8%EB%84%88%EC%8A%A4%28%EC%96%B4%EB%91%A0%29))");
                    eb.AddField("수급 난이도", "★★★★☆");
                    eb.WithFooter("채용 추천 직업 : 전직업군 (추천도 상)");
                    break;
                case "로맨티스트킹슬라임":
                case "로맨티스트":
                    eb.WithTitle("📒 몬스터라이프 로맨티스트 킹슬라임 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9500609/icon");
                    eb.AddField("잠재능력", "크리티컬 확률 +3%");
                    eb.AddField("조합법",
                        "[킹슬라임(슬라임과 달팽이 SS)](https://meso.kr/monster.php?n=%ED%82%B9%EC%8A%AC%EB%9D%BC%EC%9E%84) + [사랑에 빠진 커플예티(스페셜 S)](https://meso.kr/monster.php?n=%EC%82%AC%EB%9E%91%EC%97%90+%EB%B9%A0%EC%A7%84+%EC%BB%A4%ED%94%8C%EC%98%88%ED%8B%B0)");
                    eb.AddField("수급 난이도", "★★★☆☆");
                    eb.WithFooter("채용 추천 직업 : 자버프 크리티컬 확률에 따라 채용 추천");
                    break;
                case "쁘띠혼테일":
                case "혼테일":
                    eb.WithTitle("📒 몬스터라이프 쁘띠 혼테일 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9300690/icon");
                    eb.AddField("잠재능력", "크리티컬 확률 +3%");
                    eb.AddField("조합법",
                        "[레비아탄(용 S)](https://meso.kr/monster.php?n=%EB%A0%88%EB%B9%84%EC%95%84%ED%83%84) + [설산의 마녀(스페셜상자 A)](https://meso.kr/monster.php?n=%EC%84%A4%EC%82%B0%EC%9D%98+%EB%A7%88%EB%85%80)");
                    eb.AddField("수급 난이도", "★★★☆☆");
                    eb.WithFooter("채용 추천 직업 : 자버프 크리티컬 확률에 따라 채용 추천");
                    break;
                case "쁘띠팬텀":
                case "팬텀":
                    eb.WithTitle("📒 몬스터라이프 쁘띠 팬텀 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9300757/icon");
                    eb.AddField("잠재능력", "크리티컬 확률 +4%");
                    eb.AddField("조합법",
                        "[월묘도둑(스페셜 S)](https://meso.kr/monster.php?n=%EC%9B%94%EB%AC%98+%EB%8F%84%EB%91%91) + [로맨티스트 킹슬라임(스페셜 SS)](https://meso.kr/monster.php?n=%EB%A1%9C%EB%A7%A8%ED%8B%B0%EC%8A%A4%ED%8A%B8+%ED%82%B9%EC%8A%AC%EB%9D%BC%EC%9E%84)");
                    eb.AddField("수급 난이도", "★★★★☆");
                    eb.WithFooter("채용 추천 직업 : 자버프 크리티컬 확률에 따라 채용 추천");
                    break;
                case "라즐리":
                    eb.WithTitle("📒 몬스터라이프 라즐리 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9300759/icon");
                    eb.AddField("잠재능력", "크리티컬 확률 +5%");
                    eb.AddField("조합법",
                        "[시간의 눈(인공생명체 A)](https://meso.kr/monster.php?n=%EC%8B%9C%EA%B0%84%EC%9D%98+%EB%88%88) + [쁘띠 힐라(스페셜 SS)](https://meso.kr/monster.php?n=%EC%81%98%EB%9D%A0+%ED%9E%90%EB%9D%BC)");
                    eb.AddField("수급 난이도", "★★★☆☆");
                    eb.WithFooter("채용 추천 직업 : 자버프 크리티컬 확률에 따라 채용 추천");
                    break;
                case "쁘띠힐라":
                case "힐라":
                    eb.WithTitle("📒 몬스터라이프 쁘띠 힐라 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9300691/icon");
                    eb.AddField("잠재능력", "크리티컬 데미지 +2%");
                    eb.AddField("조합법",
                        "[리치(언데드 S)](https://meso.kr/monster.php?n=%EB%A6%AC%EC%B9%98) + [엘리트 블러드투스(개 S)](https://meso.kr/monster.php?n=%EC%97%98%EB%A6%AC%ED%8A%B8+%EB%B8%94%EB%9F%AC%EB%93%9C%ED%88%AC%EC%8A%A4)");
                    eb.AddField("수급 난이도", "★★★☆☆");
                    eb.WithFooter("채용 추천 직업 : 전직업 (추천도 최상)");
                    break;
                case "쁘띠시그너스":
                case "시그":
                case "시그너스":
                case "쁘띠시그":
                    eb.WithTitle("📒 몬스터라이프 쁘띠 시그너스 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9300687/icon");
                    eb.AddField("잠재능력", "데미지 +3%");
                    eb.AddField("조합법",
                        "[신수(스페셜 S)](https://meso.kr/monster.php?n=%EC%8B%A0%EC%88%98) + [오베론(스페셜 S)](https://meso.kr/monster.php?n=%EC%98%A4%EB%B2%A0%EB%A1%A0)");
                    eb.AddField("수급 난이도", "★★★☆☆");
                    eb.WithFooter("채용 추천 직업 : 전직업 (추천도 최상)");
                    break;
                case "허수아비":
                    eb.WithTitle("📒 몬스터라이프 허수아비 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9309203/icon");
                    eb.AddField("잠재능력", "데미지 +4%");
                    eb.AddField("조합법",
                        "[도둑까마귀(조류 B+)](https://meso.kr/monster.php?n=%EB%8F%84%EB%91%91%EA%B9%8C%EB%A7%88%EA%B7%80) + [쁘띠 아카이럼(스페셜 SS)](https://meso.kr/monster.php?n=%EC%81%98%EB%9D%A0+%EC%95%84%EC%B9%B4%EC%9D%B4%EB%9F%BC)");
                    eb.AddField("수급 난이도", "★★★☆☆");
                    eb.WithFooter("채용 추천 직업 : 전직업 (추천도 최상)");
                    break;
                case "쁘띠반레온":
                case "반레온":
                    eb.WithTitle("📒 몬스터라이프 쁘띠 반레온 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9300685/icon");
                    eb.AddField("잠재능력", "보스 공격 시 데미지 +5%");
                    eb.AddField("조합법",
                        "[릴리노흐(스페셜상자 S)](https://meso.kr/monster.php?n=%EB%A6%B4%EB%A6%AC%EB%85%B8%ED%9D%90) + [장난감 흑기사(장난감 S)](https://meso.kr/monster.php?n=%EC%9E%A5%EB%82%9C%EA%B0%90+%ED%9D%91%EA%B8%B0%EC%82%AC)");
                    eb.AddField("수급 난이도", "★★☆☆☆");
                    eb.WithFooter("채용 추천 직업 : 전직업 (추천도 최상)");
                    break;
                case "쁘띠랑":
                case "랑":
                    eb.WithTitle("📒 몬스터라이프 쁘띠 랑 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9300882/icon");
                    eb.AddField("잠재능력", "보스 공격시 데미지 +8% (쁘띠 은월 보유시)");
                    eb.AddField("조합법",
                        "[구미호(개 SS)](https://meso.kr/monster.php?n=%EA%B5%AC%EB%AF%B8%ED%98%B8) + [쁘띠 오르카(스페셜 SS)](https://meso.kr/monster.php?n=%EC%81%98%EB%9D%A0+%EC%98%A4%EB%A5%B4%EC%B9%B4)");
                    eb.AddField("수급 난이도", "★★★☆☆");
                    eb.WithFooter("채용 추천 직업 : 전직업 (추천도 최상)");
                    break;
                case "쁘띠매그너스":
                case "쁘띠매그":
                case "매그너스":
                case "매그":
                    eb.WithTitle("📒 몬스터라이프 쁘띠 매그너스 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9300684/icon");
                    eb.AddField("잠재능력", "몬스터 방어율 무시 +5%");
                    eb.AddField("조합법",
                        "[크림슨 발록(스페셜 S)](https://meso.kr/monster.php?n=%ED%81%AC%EB%A6%BC%EC%8A%A8+%EB%B0%9C%EB%A1%9D) + [푸소(스페셜상자 S)](https://meso.kr/monster.php?n=%ED%91%B8%EC%86%8C)");
                    eb.AddField("수급 난이도", "★★★☆☆");
                    eb.WithFooter("채용 추천 직업 : 방무가 모자란 전직업 (추천도 최상)");
                    break;
                case "라피스":
                    eb.WithTitle("📒 몬스터라이프 라피스 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9300758/icon");
                    eb.AddField("잠재능력", "몬스터 방어율 무시 +5%");
                    eb.AddField("조합법",
                        "[시간의 눈(인공생명체 A)](https://meso.kr/monster.php?n=%EC%8B%9C%EA%B0%84%EC%9D%98+%EB%88%88) + [이프리트(정령 SS)](https://meso.kr/monster.php?n=%EC%9D%B4%ED%94%84%EB%A6%AC%ED%8A%B8)");
                    eb.AddField("수급 난이도", "★★★☆☆");
                    eb.WithFooter("채용 추천 직업 : 방무가 모자란 전직업 (추천도 최상)");
                    break;
                case "양철나무꾼":
                case "나무꾼":
                    eb.WithTitle("📒 몬스터라이프 양철 나무꾼 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9309205/icon");
                    eb.AddField("잠재능력", "몬스터 방어율 무시 +6%");
                    eb.AddField("조합법",
                        "[내면의 분노(스페셜 SS)](https://meso.kr/monster.php?n=%EB%82%B4%EB%A9%B4%EC%9D%98+%EB%B6%84%EB%85%B8) + [빅터(인공생명체 SS)](https://meso.kr/monster.php?n=%EB%B9%85%ED%84%B0)");
                    eb.AddField("수급 난이도", "★★★★☆");
                    eb.WithFooter("채용 추천 직업 : 방무가 모자란 전직업 (추천도 최상)");
                    break;
                case "사랑에빠진커플예티":
                case "커플예티":
                    eb.WithTitle("📒 몬스터라이프 사랑에 빠진 커플예티 (S)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9500608/icon");
                    eb.AddField("잠재능력", "소환수 지속시간 +7%");
                    eb.AddField("조합법",
                        "[골드예티와 페페킹(예티와 페페 S)](https://meso.kr/monster.php?n=%EA%B3%A8%EB%93%9C%EC%98%88%ED%8B%B0%EC%99%80+%ED%8E%98%ED%8E%98%ED%82%B9) + [사랑에 빠진 판다곰(원숭이와 곰 A+)](https://meso.kr/monster.php?n=%EC%82%AC%EB%9E%91%EC%97%90+%EB%B9%A0%EC%A7%84+%ED%8C%90%EB%8B%A4%EA%B3%B0)");
                    eb.AddField("수급 난이도", "★★☆☆☆");
                    eb.WithFooter("채용 추천 직업 : 소환수 사용 직업(호영, 메카닉, 캡틴) (추천도 : 중상)");
                    break;
                case "빅펌킨":
                    eb.WithTitle("📒 몬스터라이프 빅 펌킨 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9010019/icon");
                    eb.AddField("잠재능력", "소환수 지속시간 +6%");
                    eb.AddField("조합법",
                        "[할로윈 펌프킨(유령 B)](https://meso.kr/monster.php?n=%ED%95%A0%EB%A1%9C%EC%9C%88+%ED%8E%8C%ED%94%84%ED%82%A8) + [거인(골렘 SS)](https://meso.kr/monster.php?n=%EA%B1%B0%EC%9D%B8)");
                    eb.AddField("수급 난이도", "★★★☆☆");
                    eb.WithFooter("채용 추천 직업 : 소환수 사용 직업(호영, 메카닉, 캡틴) (추천도 : 중상)");
                    break;
                case "쁘띠아카이럼":
                case "쁘띠아카":
                case "아카이럼":
                    eb.WithTitle("📒 몬스터라이프 쁘띠 아카이럼 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9300686/icon");
                    eb.AddField("잠재능력", "버프 지속시간 +5%");
                    eb.AddField("조합법",
                        "[타이머(스페셜상자 S)](https://meso.kr/monster.php?n=%ED%83%80%EC%9D%B4%EB%A8%B8) + [이계의 사제(파충류 S)](https://meso.kr/monster.php?n=%EC%9D%B4%EA%B3%84%EC%9D%98+%EC%82%AC%EC%A0%9C)");
                    eb.AddField("수급 난이도", "★★★☆☆");
                    eb.WithFooter("채용 추천 직업 : 버프 지속시간 채용 직업(모험가 마법사, 루미너스, 카이저 등) (추천도 : 상)");
                    break;
                case "반반":
                    eb.WithTitle("📒 몬스터라이프 반반 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/8910100/icon");
                    eb.AddField("잠재능력", "버프 지속시간 +5%");
                    eb.AddField("조합법",
                        "[그리프(조류 SS)](https://meso.kr/monster.php?n=%EA%B7%B8%EB%A6%AC%ED%94%84) + [핑크빈(스페셜상자 SS)](https://meso.kr/monster.php?n=%ED%95%91%ED%81%AC%EB%B9%88)");
                    eb.AddField("수급 난이도", "★★★☆☆");
                    eb.WithFooter("채용 추천 직업 : 버프 지속시간 채용 직업(모험가 마법사, 루미너스, 카이저 등) (추천도 : 상)");
                    break;
                case "군단장윌":
                case "윌":
                    eb.WithTitle("📒 몬스터라이프 군단장 윌 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/2600800/icon");
                    eb.AddField("잠재능력", "버프 지속시간 +6%");
                    eb.AddField("조합법",
                        "[거대 거미(스페셜 SS)](https://meso.kr/monster.php?n=%EA%B1%B0%EB%8C%80+%EA%B1%B0%EB%AF%B8) + [큰 운영자의 벌룬(스페셜 SS)](https://meso.kr/monster.php?n=%ED%81%B0+%EC%9A%B4%EC%98%81%EC%9E%90%EC%9D%98+%EB%B2%8C%EB%A3%AC)");
                    eb.AddField("수급 난이도", "★x10");
                    eb.WithFooter("채용 추천 직업 : 버프 지속시간 채용 직업(모험가 마법사, 루미너스, 카이저 등) (추천도 : 중)\r\n" +
                        "⚠️ 새끼거미 보유시에만 채용을 추천합니다.");
                    break;
                case "큰운영자의벌룬":
                    eb.WithTitle("📒 몬스터라이프 큰 운영자의 벌룬 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9300784/icon");
                    eb.AddField("잠재능력", "2% 확률로 스킬 재사용 대기시간 미적용");
                    eb.AddField("조합법",
                        "[작은 운영자 벌룬(SS)](https://meso.kr/monster.php?n=%EC%9E%91%EC%9D%80+%EC%9A%B4%EC%98%81%EC%9E%90+%EB%B2%8C%EB%A3%AC) + [작은 운영자 벌룬(SS)](https://meso.kr/monster.php?n=%EC%9E%91%EC%9D%80+%EC%9A%B4%EC%98%81%EC%9E%90+%EB%B2%8C%EB%A3%AC)");
                    eb.AddField("수급 난이도", "★★★★★");
                    eb.WithFooter("채용 추천 직업 : 제로, 데몬어벤저 (추천도 : 중)");
                    break;
                case "쁘띠은월":
                case "은월":
                    eb.WithTitle("📒 몬스터라이프 쁘띠 은월 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9300881/icon");
                    eb.AddField("잠재능력", "4% 확률로 스킬 재사용 대기시간 미적용");
                    eb.AddField("조합법",
                        "[쁘띠 팬텀(스페셜 SS)](https://meso.kr/monster.php?n=%EC%81%98%EB%9D%A0+%ED%8C%AC%ED%85%80) + [쁘띠 루미너스(빛)(스페셜상자 SS)](https://meso.kr/monster.php?n=%EC%81%98%EB%9D%A0+%EB%A3%A8%EB%AF%B8%EB%84%88%EC%8A%A4%28%EB%B9%9B%29)");
                    eb.AddField("수급 난이도", "★★★★☆");
                    eb.WithFooter("채용 추천 직업 : 쁘띠 랑(스페셜 SS) 보유 전직업 (추천도 최상)");
                    break;
                case "피에르":
                    eb.WithTitle("📒 몬스터라이프 피에르 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/8900100/icon");
                    eb.AddField("잠재능력", "파이널 어택류의 데미지 15% 증가");
                    eb.AddField("조합법",
                        "[주니어 발록(S)](https://meso.kr/monster.php?n=%EC%A3%BC%EB%8B%88%EC%96%B4+%EB%B0%9C%EB%A1%9D) + [타르가(장난감 SS)](https://meso.kr/monster.php?n=%ED%83%80%EB%A5%B4%EA%B0%80)");
                    eb.AddField("수급 난이도", "★★★☆☆");
                    eb.WithFooter("채용 추천 직업 : 파이널 어택 보유 전직업 (추천도 최상)");
                    break;
                case "내면의분노":
                    eb.WithTitle("📒 몬스터라이프 내면의 분노 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9001058/icon");
                    eb.AddField("잠재능력", "최대 HP +500");
                    eb.AddField("조합법",
                        "[락 스피릿(악마 A+)](https://meso.kr/monster.php?n=%EB%9D%BD+%EC%8A%A4%ED%94%BC%EB%A6%BF) + [이상한 몬스터(고양이 SS)](https://meso.kr/monster.php?n=%EC%9D%B4%EC%83%81%ED%95%9C+%EB%AA%AC%EC%8A%A4%ED%84%B0)");
                    eb.AddField("수급 난이도", "★★★☆☆");
                    eb.WithFooter("채용 추천 직업 : 데몬 어벤저 (추천도 중상)");
                    break;
                case "자이언트다크소울":
                    eb.WithTitle("📒 몬스터라이프 자이언트 다크소울 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9300627/icon");
                    eb.AddField("잠재능력", "최대 HP +500");
                    eb.AddField("조합법",
                        "[다크소울(악마 S)](https://meso.kr/monster.php?n=%EB%8B%A4%ED%81%AC%EC%86%8C%EC%9A%B8) + [거인(골렘 SS)](https://meso.kr/monster.php?n=%EA%B1%B0%EC%9D%B8)");
                    eb.AddField("수급 난이도", "★★★☆☆");
                    eb.WithFooter("채용 추천 직업 : 데몬 어벤저 (추천도 중하)");
                    break;
                case "킹캐슬골렘":
                    eb.WithTitle("📒 몬스터라이프 킹 캐슬 골렘 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/8211004/icon");
                    eb.AddField("잠재능력", "방어력 +150, 최대 HP +750");
                    eb.AddField("조합법",
                        "[캐슬 골렘(골렘 B)](https://meso.kr/monster.php?n=%EC%BA%90%EC%8A%AC+%EA%B3%A8%EB%A0%98) + [거인(골렘 SS)](https://meso.kr/monster.php?n=%EA%B1%B0%EC%9D%B8)");
                    eb.AddField("수급 난이도", "★★★☆☆");
                    eb.WithFooter("채용 추천 직업 : 데몬 어벤저 (추천도 중하)");
                    break;
                case "작은운영자벌룬":
                    eb.WithTitle("📒 몬스터라이프 작은 운영자 벌룬 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9300793/icon");
                    eb.AddField("잠재능력", "최대 HP +2%");
                    eb.AddField("조합법",
                        "[피에르(스페셜 SS)](https://meso.kr/monster.php?n=%ED%94%BC%EC%97%90%EB%A5%B4) + [총리대신(버섯 SS)](https://meso.kr/monster.php?n=%EC%B4%9D%EB%A6%AC%EB%8C%80%EC%8B%A0)");
                    eb.AddField("수급 난이도", "★★★★☆");
                    eb.WithFooter("채용 추천 직업 : 데몬 어벤저 (추천도 상)");
                    break;
                case "월묘도둑":
                    eb.WithTitle("📒 몬스터라이프 월묘 도둑 (S)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9303025/icon");
                    eb.AddField("잠재능력", "메소 획득량 +4%");
                    eb.AddField("조합법",
                        "[월묘(스페셜상자 A)](https://meso.kr/monster.php?n=%EC%9B%94%EB%AC%98) + [달빛도둑(고양이 A)](https://meso.kr/monster.php?n=%EB%8B%AC%EB%B9%9B%EB%8F%84%EB%91%91)");
                    eb.AddField("수급 난이도", "★☆☆☆☆");
                    eb.WithFooter("채용 추천 직업 : 사냥러 (추천도 상)");
                    break;
                case "쁘띠오르카":
                case "오르카":
                    eb.WithTitle("📒 몬스터라이프 쁘띠 오르카 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9300688/icon");
                    eb.AddField("잠재능력", "캐릭터의 획득 경험치 +3%");
                    eb.AddField("조합법",
                        "[거대 스노우맨(인공생명체 SS)](https://meso.kr/monster.php?n=%EA%B1%B0%EB%8C%80+%EC%8A%A4%EB%85%B8%EC%9A%B0%EB%A7%A8) + [쌍둥이 월묘(스페셜 A+)](https://meso.kr/monster.php?n=%EC%8C%8D%EB%91%A5%EC%9D%B4+%EC%9B%94%EB%AC%98)");
                    eb.AddField("수급 난이도", "★★★☆☆");
                    eb.WithFooter("채용 추천 직업 : 사냥러 (추천도 상)");
                    break;
                case "쁘띠메르세데스":
                case "메르세데스":
                    eb.WithTitle("📒 몬스터라이프 쁘띠 메르세데스 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9300756/icon");
                    eb.AddField("잠재능력", "캐릭터의 획득 경험치 +3%");
                    eb.AddField("조합법",
                        "[강화형 베릴(스페셜 SS)](https://meso.kr/monster.php?n=%EA%B0%95%ED%99%94%ED%98%95+%EB%B2%A0%EB%A6%B4) + [에피네아(스페셜 SS)](https://meso.kr/monster.php?n=%EC%97%90%ED%94%BC%EB%84%A4%EC%95%84)");
                    eb.AddField("수급 난이도", "★★★★★");
                    eb.WithFooter("채용 추천 직업 : 사냥러 (추천도 하)");
                    break;
                case "신수":
                    eb.WithTitle("📒 몬스터라이프 신수 (S)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/8850010/icon");
                    eb.AddField("잠재능력", "공격시 10% 확률로 HP, MP 20 회복");
                    eb.AddField("조합법",
                        "[피닉스(조류 S)](https://meso.kr/monster.php?n=%ED%94%BC%EB%8B%89%EC%8A%A4) + [라이카(소 S)](https://meso.kr/monster.php?n=%EB%9D%BC%EC%9D%B4%EC%B9%B4)");
                    eb.AddField("수급 난이도", "★★☆☆☆");
                    eb.WithFooter("채용 추천 직업 : X");
                    break;
                case "주니어발록":
                    eb.WithTitle("📒 몬스터라이프 주니어 발록 (S)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/8130100/icon");
                    eb.AddField("잠재능력", "피격 시 무적시간 +1초");
                    eb.AddField("조합법",
                        "[미니빈(악마 S)](https://meso.kr/monster.php?n=%EB%AF%B8%EB%8B%88%EB%B9%88) + [사신 스펙터(솔져 S)](https://meso.kr/monster.php?n=%EC%82%AC%EC%8B%A0+%EC%8A%A4%ED%8E%99%ED%84%B0)");
                    eb.AddField("수급 난이도", "★★☆☆☆");
                    eb.WithFooter("채용 추천 직업 : X");
                    break;
                case "크림슨발록":
                    eb.WithTitle("📒 몬스터라이프 크림슨 발록 (S)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/8150000/icon");
                    eb.AddField("잠재능력", "피격시 5% 확률로 3초 동안 무적효과");
                    eb.AddField("조합법",
                        "[잭오랜턴(유령 S)](https://meso.kr/monster.php?n=%EC%9E%AD%EC%98%A4%EB%9E%9C%ED%84%B4) + [해적왕 바르보사(솔져 S)](https://meso.kr/monster.php?n=%ED%95%B4%EC%A0%81%EC%99%95+%EB%B0%94%EB%A5%B4%EB%B3%B4%EC%82%AC)");
                    eb.AddField("수급 난이도", "★★☆☆☆");
                    eb.WithFooter("채용 추천 직업 : X");
                    break;
                case "게오르크":
                    eb.WithTitle("📒 몬스터라이프 게오르크 (S)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/3502008/icon");
                    eb.AddField("잠재능력", "방여럭 +150, 이동속도 +5");
                    eb.AddField("조합법",
                        "[거대 루 몬스터(인공생명체 S)](https://meso.kr/monster.php?n=%EA%B1%B0%EB%8C%80+%EB%A3%A8+%EB%AA%AC%EC%8A%A4%ED%84%B0) + [제노(아인종 SS)](https://meso.kr/monster.php?n=%EC%A0%9C%EB%85%B8)");
                    eb.AddField("수급 난이도", "★★☆☆☆");
                    eb.WithFooter("채용 추천 직업 : X");
                    break;
                case "몰킹":
                    eb.WithTitle("📒 몬스터라이프 몰킹 (S)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/3501008/icon");
                    eb.AddField("잠재능력", "이동속도 +10");
                    eb.AddField("조합법",
                        "[양파라고라(식물 A+)](https://meso.kr/monster.php?n=%EC%96%91%ED%8C%8C%EB%9D%BC%EA%B3%A0%EB%9D%BC) + [순무라고라(식물 A+)](https://meso.kr/monster.php?n=%EC%88%9C%EB%AC%B4%EB%9D%BC%EA%B3%A0%EB%9D%BC)");
                    eb.AddField("수급 난이도", "★★☆☆☆");
                    eb.WithFooter("채용 추천 직업 : X");
                    break;
                case "겁에질린사자":
                    eb.WithTitle("📒 몬스터라이프 겁에 질린 사자 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9309200/icon");
                    eb.AddField("잠재능력", "피격시 3% 확률로 3초 동안 무적효과");
                    eb.AddField("조합법",
                        "[풍선쥐(스페셜상자 B)](https://meso.kr/monster.php?n=%ED%92%8D%EC%84%A0%EC%A5%90) + [쁘띠 반 레온(스페셜 SS)](https://meso.kr/monster.php?n=%EC%81%98%EB%9D%A0+%EB%B0%98+%EB%A0%88%EC%98%A8)");
                    eb.AddField("수급 난이도", "★★★★☆");
                    eb.WithFooter("채용 추천 직업 : X");
                    break;
                case "쁘띠자쿰":
                case "자쿰":
                    eb.WithTitle("📒 몬스터라이프 쁘띠 자쿰 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9300689/icon");
                    eb.AddField("잠재능력", "피격시 3% 확률로 가드");
                    eb.AddField("조합법",
                        "[퍼펫골렘(골렘 S)](https://meso.kr/monster.php?n=%ED%8D%BC%ED%8E%AB%EA%B3%A8%EB%A0%98) + [프랑켄로이드(스페셜상자 A+)](https://meso.kr/monster.php?n=%ED%94%84%EB%9E%91%EC%BC%84%EB%A1%9C%EC%9D%B4%EB%93%9C)");
                    eb.AddField("수급 난이도", "★★★★☆");
                    eb.WithFooter("채용 추천 직업 : X");
                    break;
                case "토토":
                    eb.WithTitle("📒 몬스터라이프 토토 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9309206/icon");
                    eb.AddField("잠재능력", "이동속도 +5");
                    eb.AddField("조합법",
                        "[다크 엘리쟈(고양이 SS)](https://meso.kr/monster.php?n=%EB%8B%A4%ED%81%AC+%EC%97%98%EB%A6%AC%EC%9F%88) + [대장 블러드투스(개 S)](https://meso.kr/monster.php?n=%EB%8C%80%EC%9E%A5+%EB%B8%94%EB%9F%AC%EB%93%9C%ED%88%AC%EC%8A%A4)");
                    eb.AddField("수급 난이도", "★★★☆☆");
                    eb.WithFooter("채용 추천 직업 : X");
                    break;
                case "타란튤로스":
                    eb.WithTitle("📒 몬스터라이프 타란튤로스 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/8800400/icon");
                    eb.AddField("잠재능력", "상태이상 내성 +1");
                    eb.AddField("조합법",
                        "[킹크랑(스페셜상자 A)](https://meso.kr/monster.php?n=%ED%82%B9%ED%81%AC%EB%9E%91) + [쓰레기통(인공생명체 SS)](https://meso.kr/monster.php?n=%EC%93%B0%EB%A0%88%EA%B8%B0%ED%86%B5)");
                    eb.AddField("수급 난이도", "★★★★☆");
                    eb.WithFooter("채용 추천 직업 : X");
                    break;
                case "성장중인미르":
                    eb.WithTitle("📒 몬스터라이프 성장 중인 미르 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9300751/icon");
                    eb.AddField("잠재능력", "상태이상 내성 +5");
                    eb.AddField("조합법",
                        "[미르(스페셜 SS)](https://meso.kr/monster.php?n=%EB%AF%B8%EB%A5%B4) + [미르(스페셜 SS)](https://meso.kr/monster.php?n=%EB%AF%B8%EB%A5%B4)");
                    eb.AddField("수급 난이도", "★★★★☆");
                    eb.WithFooter("채용 추천 직업 : X");
                    break;
                case "거대거미":
                    eb.WithTitle("📒 몬스터라이프 거대 거미 (SS)");
                    eb.WithImageUrl("https://maplestory.io/api/KMS/333/mob/9309201/icon");
                    eb.AddField("잠재능력", "상태이상 내성 +3%");
                    eb.AddField("조합법",
                        "[타란튤로스(스페셜 SS)](https://meso.kr/monster.php?n=%ED%83%80%EB%9E%80%ED%8A%A4%EB%A1%9C%EC%8A%A4) + [새끼 거미(스페셜상자 B+)](https://meso.kr/monster.php?n=%EC%83%88%EB%81%BC+%EA%B1%B0%EB%AF%B8)");
                    eb.AddField("수급 난이도", "★★★★★");
                    eb.WithFooter("채용 추천 직업 : X");
                    break;
                default:
                    eb.WithTitle("⚠️ 불러오기 실패");
                    eb.WithDescription($"알 수 없는 이름: {info}");
                    break;
            }

            eb.WithColor(Color.Purple);
            if (eb.Fields.Count > 0)
            {
                foreach (var field in eb.Fields)
                {
                    string? asdf = field.Value.ToString();
                    if (asdf != null && asdf.Contains("스페셜상자"))
                    {
                        eb.WithFooter("⚠️ 스페셜상자 카테고리의 몬스터는 몬스터라이프 상점에서 판매하는 평범한 상자, 많이 좋은 상자, 조금 좋은 상자(A+/S) 또는 쁘띠 루미너스 상자에서만 등장합니다.");
                        break;
                    }
                }
            }

            await RespondAsync("", embed: eb.Build(), ephemeral: true);
        }

        [SlashCommand("몬라상자", "몬라상자 확률 및 정보를 표시합니다.")]
        [RequireBotPermission(GuildPermission.EmbedLinks)]
        [RequireBotPermission(GuildPermission.SendMessages)]
        public async Task MLBoxAsync(MLBoxInfo info)
        {
            Translations lang = await TranslationLoader.FindGuildTranslationAsync(Context.Guild.Id);
            EmbedBuilder eb = new EmbedBuilder();
            if (lang != Translations.Korean)
            {
                await RespondAsync("🚫 Sorry, this feature is only supported for Korean discord server.\r\nChange bot language to Korean on this server(/language).", ephemeral: true);
                return;
            }

            switch (info)
            {
                case MLBoxInfo.NormalBox:
                    eb.WithTitle("ℹ️ 평범한 상자 정보");
                    eb.AddField("등장 몹",
                        "흰 모래토끼(C), 박쥐는 호박을 좋아해(C), 애벌레(C), 주니어 씰(B), 갈색 모래토끼(B), 풍선쥐(B), 비급(B+), 세르프(B+), 새끼 거미(B+), " +
                        "도도(A), 킹크랑(A), 설산의 마녀(A), 이루워터(A), 월묘(A)");
                    eb.AddField("가격", "100,000 와르 (스페셜 상인)");
                    eb.WithFooter("⭐ 추천 몹: 비급(데미지 +1%), 세르프(아이템 드롭률 +2%), 새끼 거미(소환수 지속시간 1% 증가, 군단장 윌 하위 재료)");
                    break;
                case MLBoxInfo.SpecialBox1:
                    eb.WithTitle("ℹ️ 조금 좋은 상자(A+) 정보");
                    eb.AddField("등장 몹",
                        "듀나스(A+), 프랑켄로이드(A+)");
                    eb.AddField("가격", "250,000 와르 (스페셜 상인)");
                    break;
                case MLBoxInfo.SpecialBox2:
                    eb.WithTitle("ℹ️ 조금 좋은 상자(S) 정보");
                    eb.AddField("등장 몹",
                        "베릴(S), 푸소(S), 타이머(S), 릴리노흐(S), 바이킹 군단(S)");
                    eb.AddField("가격", "250,000 와르 (스페셜 상인)");
                    break;
                case MLBoxInfo.GemBox:
                    eb.WithTitle("ℹ️ 많이 좋은 상자 정보");
                    eb.AddField("등장 몹",
                        "도도(A / 12.403%), 킹크랑(A / 12.403%), 설산의 마녀(A / 12.403%), 이루워터(A / 12.403%), 월묘(A / 12.403%), 듀나스(A+ / 6.202%), 프랑켄로이드(A+ / 6.202%), " +
                        "베릴(S / 4.651%), 푸소(S / 4.651%), 타이머(S / 4.651%), 릴리노흐(S / 4.651%), 바이킹 군단(S / 4.651%), 핑크빈 (SS / 2.326%)");
                    eb.AddField("가격", "8젬 (상시판매), 250,000 와르 (스페셜 상인)");
                    break;
                case MLBoxInfo.LuminousBox:
                    eb.WithTitle("ℹ️ 쁘띠 루미너스 상자 정보");
                    eb.AddField("등장 몹",
                        "쁘띠 루미너스(빛)(SS / 100%)");
                    eb.AddField("가격", "582,000 와르 (농장 40레벨 달성시 상시 구매 가능)");
                    break;
            }
            eb.WithColor(Color.Purple);
            await RespondAsync("", embed: eb.Build(), ephemeral: true);
        }

        [SlashCommand("몬라능력", "능력치 카테고리별로 스페셜 몬스터를 출력합니다.")]
        [RequireBotPermission(GuildPermission.EmbedLinks)]
        [RequireBotPermission(GuildPermission.SendMessages)]
        public async Task MLStatsAsync(MLStats info)
        {
            Translations lang = await TranslationLoader.FindGuildTranslationAsync(Context.Guild.Id);
            EmbedBuilder eb = new EmbedBuilder();
            if (lang != Translations.Korean)
            {
                await RespondAsync("🚫 Sorry, this feature is only supported for Korean discord server.\r\nChange bot language to Korean on this server(/language).", ephemeral: true);
                return;
            }

            switch (info)
            {
                case MLStats.FarmStats:
                    eb.WithTitle("ℹ️ 농장 관련 효과");
                    eb.AddField("박쥐는 사탕을 좋아해 (B)",
                        "잠재능력 : 농장 레벨 상승 시 100 와르 획득\r\n" +
                        "수급 난이도 : ★☆☆☆☆\r\n" +
                        "채용 추천 직업 : X");
                    eb.AddField("예티 파라오 (A)",
                        "잠재능력 : 농장의 획득 경험치 15 증가\r\n" +
                        "수급 난이도 : ★☆☆☆☆\r\n" +
                        "채용 추천 직업 : 농장 40레벨 이하 (추천도 최상)");
                    eb.AddField("아우프 헤벤 (A+)",
                        "잠재능력 : 농장건물의 단위 시간당 생산량 1 증가\r\n" +
                        "수급 난이도 : ★★☆☆☆\r\n" +
                        "채용 추천 직업 : X");
                    eb.AddField("쌍둥이 월묘 (A+)",
                        "잠재능력 : 농장 몬스터의 획득 경험치 2 증가\r\n" +
                        "수급 난이도 : ★★☆☆☆\r\n" +
                        "채용 추천 직업 : X");
                    break;
                case MLStats.Stats:
                    eb.AddField("몬스터라이프 오베론 (S)",
                       "잠재능력 : 올스탯 +5\r\n" +
                       "수급 난이도 : ★★★☆☆\r\n" +
                       "채용 추천 직업 : 데몬어벤저 제외 전직업군 (추천도 하)");
                    eb.AddField("몬스터라이프 파풀라투스의 시계 (S)",
                        "잠재능력 : 올스탯 +5\r\n" +
                        "수급 난이도 : ★★☆☆☆\r\n" +
                        "채용 추천 직업 : 데몬어벤저 제외 전직업군 (추천도 하)");
                    eb.AddField("몬스터라이프 검은 바이킹 (SS)",
                        "잠재능력 : DEX +5, 데미지 +2%\r\n" +
                        "수급 난이도 : ★★★☆☆\r\n" +
                        "채용 추천 직업 : 전직업 (추천도 중상)");
                    eb.AddField("몬스터라이프 각성한 락 스피릿 (SS)",
                        "잠재능력 : 올스탯 +5\r\n" +
                        "수급 난이도 : ★★★☆☆\r\n" +
                        "채용 추천 직업 : 데몬어벤저 제외 전직업군 (추천도 하)");
                    eb.AddField("몬스터라이프 마스터 잭슨 (SS)",
                        "잠재능력 : 올스탯 +5\r\n" +
                        "수급 난이도 : ★★★☆☆\r\n" +
                        "채용 추천 직업 : 전직업 (추천도 하)");
                    eb.AddField("몬스터라이프 강화형 베릴 (SS)",
                        "잠재능력 : 올스탯 +6\r\n" +
                        "수급 난이도 : ★★★☆☆\r\n" +
                        "채용 추천 직업 : 전직업 (추천도 하)");
                    eb.AddField("몬스터라이프 마스터 레드너그 (SS)",
                        "잠재능력 : STR +15\r\n" +
                        "수급 난이도 : ★★★☆☆\r\n" +
                        "채용 추천 직업 : STR 사용 직업군 (추천도 중하)");
                    eb.AddField("몬스터라이프 마스터 렐릭 (SS)",
                        "잠재능력 : DEX +15\r\n" +
                        "수급 난이도 : ★★★☆☆\r\n" +
                        "채용 추천 직업 : DEX 사용 직업군 (추천도 중하)");
                    eb.AddField("몬스터라이프 마스터 마르가나 (SS)",
                        "잠재능력 : INT +15\r\n" +
                        "수급 난이도 : ★★★☆☆\r\n" +
                        "채용 추천 직업 : INT 사용 직업군 (추천도 중하)");
                    eb.AddField("몬스터라이프 마스터 히삽 (SS)",
                        "잠재능력 : LUK +15\r\n" +
                        "수급 난이도 : ★★★☆☆\r\n" +
                        "채용 추천 직업 : LUK 사용 직업군 (추천도 중하)");
                    eb.AddField("몬스터라이프 성장한 미르 (SS)",
                        "잠재능력 : 올스탯 +20\r\n" +
                        "수급 난이도 : ★★★★★\r\n" +
                        "채용 추천 직업 : 데몬어벤저 제외 전직업군 (추천도 중하), 제논 강력추천");
                    eb.AddField("몬스터라이프 쁘띠 라니아 (SS)",
                        "잠재능력 : 올스탯 +20 (쁘띠 루미너스 빛/어둠/이퀄 3종 모두 보유시)\r\n" +
                        "수급 난이도 : ★★★★☆\r\n" +
                        "채용 추천 직업 : 데몬어벤저 제외 농장 40레벨 이상 전직업군 (추천도 중상), 제논 강력추천");
                    break;
                case MLStats.DamageStats:
                    eb.AddField("몬스터라이프 티폰 (SS)",
                        "잠재능력 : 공격력/마력 +1\r\n" +
                        "수급 난이도 : ★★★☆☆\r\n" +
                        "채용 추천 직업 : 전직업군 (추천도 하)");
                    eb.AddField("몬스터라이프 무공의 분신 (SS)",
                        "잠재능력 : 공격력 +3\r\n" +
                        "수급 난이도 : ★★★☆☆\r\n" +
                        "채용 추천 직업 : 공격력 사용 직업군 (추천도 중하)");
                    eb.AddField("몬스터라이프 에피네아 (SS)",
                        "잠재능력 : 마력 +3\r\n" +
                        "수급 난이도 : ★★★☆☆\r\n" +
                        "채용 추천 직업 : 마법사 직업군 (추천도 최하)");
                    eb.AddField("몬스터라이프 미르 (SS)",
                        "잠재능력 : 공격력/마력 +5\r\n" +
                        "수급 난이도 : ★★★☆☆\r\n" +
                        "채용 추천 직업 : 전직업군 (추천도 중상, 성장한 미르 채용시 최상)");
                    eb.AddField("몬스터라이프 쁘띠 루미너스(어둠) (SS)",
                        "잠재능력 : 공격력/마력 +5\r\n" +
                        "수급 난이도 : ★★★☆☆\r\n" +
                        "채용 추천 직업 : 전직업군 (추천도 상)");
                    eb.AddField("몬스터라이프 검은 마법사의 그림자 (SS)",
                        "잠재능력 : 공격력/마력 +6\r\n" +
                        "수급 난이도 : ★★★☆☆\r\n" +
                        "채용 추천 직업 : 전직업군 (추천도 상)");
                    eb.AddField("몬스터라이프 쁘띠 루미너스(이퀄리브리엄) (SS)",
                        "잠재능력 : 캐릭터 레벨 20당 공격력/마력 +1 (% 효과 미적용)\r\n" +
                        "수급 난이도 : ★★★★☆\r\n" +
                        "채용 추천 직업 : 전직업군 (추천도 상)");
                    break;
                case MLStats.ImportantStats:
                    eb.AddField("몬스터라이프 로맨티스트 킹슬라임 (SS)",
                        "잠재능력 : 크리티컬 확률 +3%\r\n" +
                        "수급 난이도 : ★★★☆☆\r\n" +
                        "채용 추천 직업 : 자버프 크리티컬 확률에 따라 채용 추천");
                    eb.AddField("몬스터라이프 쁘띠 혼테일 (SS)",
                        "잠재능력 : 크리티컬 확률 +3%\r\n" +
                        "수급 난이도 : ★★★☆☆\r\n" +
                        "채용 추천 직업 : 자버프 크리티컬 확률에 따라 채용 추천");
                    eb.AddField("몬스터라이프 쁘띠 팬텀 (SS)",
                        "잠재능력 : 크리티컬 확률 +4%\r\n" +
                        "수급 난이도 : ★★★★☆\r\n" +
                        "채용 추천 직업 : 자버프 크리티컬 확률에 따라 채용 추천");
                    eb.AddField("몬스터라이프 라즐리 (SS)",
                        "잠재능력 : 크리티컬 확률 +5%\r\n" +
                        "수급 난이도 : ★★★☆☆\r\n" +
                        "채용 추천 직업 : 자버프 크리티컬 확률에 따라 채용 추천");
                    eb.AddField("몬스터라이프 쁘띠 힐라 (SS)",
                        "잠재능력 : 크리티컬 데미지 +2%\r\n" +
                        "수급 난이도 : ★★★☆☆\r\n" +
                        "채용 추천 직업 : 전직업 (추천도 최상)");
                    eb.AddField("몬스터라이프 쁘띠 시그너스 (SS)",
                        "잠재능력 : 데미지 +3%\r\n" +
                        "수급 난이도 : ★★★☆☆\r\n" +
                        "채용 추천 직업 : 전직업 (추천도 최상)");
                    eb.AddField("몬스터라이프 허수아비 (SS)",
                        "잠재능력 : 데미지 +4%\r\n" +
                        "수급 난이도 : ★★★☆☆\r\n" +
                        "채용 추천 직업 : 전직업 (추천도 최상)");
                    eb.AddField("몬스터라이프 쁘띠 반레온 (SS)",
                        "잠재능력 : 보스 공격 시 데미지 +5%\r\n" +
                        "수급 난이도 : ★★☆☆☆\r\n" +
                        "채용 추천 직업 : 전직업 (추천도 최상)");
                    eb.AddField("몬스터라이프 쁘띠 랑 (SS)",
                        "잠재능력 : 보스 공격시 데미지 +8% (쁘띠 은월 보유시)\r\n" +
                        "수급 난이도 : ★★★☆☆\r\n" +
                        "채용 추천 직업 : 전직업 (추천도 최상)");
                    eb.AddField("몬스터라이프 쁘띠 매그너스 (SS)",
                        "잠재능력 : 몬스터 방어율 무시 +5%\r\n" +
                        "수급 난이도 : ★★★☆☆\r\n" +
                        "채용 추천 직업 : 방무가 모자란 전직업 (추천도 최상)");
                    eb.AddField("몬스터라이프 라피스 (SS)",
                        "잠재능력 : 몬스터 방어율 무시 +5%\r\n" +
                        "수급 난이도 : ★★★☆☆\r\n" +
                        "채용 추천 직업 : 방무가 모자란 전직업 (추천도 최상)");
                    eb.AddField("몬스터라이프 양철 나무꾼 (SS)",
                        "잠재능력 : 몬스터 방어율 무시 +6%\r\n" +
                        "수급 난이도 : ★★★★☆\r\n" +
                        "채용 추천 직업 : 방무가 모자란 전직업 (추천도 최상)");
                    break;
                case MLStats.UtilityStats:
                    eb.AddField("몬스터라이프 사랑에 빠진 커플예티 (S)",
                        "잠재능력 : 소환수 지속시간 +7%\r\n" +
                        "수급 난이도 : ★★☆☆☆\r\n" +
                        "채용 추천 직업 : 소환수 사용 직업(호영, 메카닉, 캡틴) (추천도 : 중상)");
                    eb.AddField("몬스터라이프 빅 펌킨 (SS)",
                        "잠재능력 : 소환수 지속시간 +6%\r\n" +
                        "수급 난이도 : ★★★☆☆\r\n" +
                        "채용 추천 직업 : 소환수 사용 직업(호영, 메카닉, 캡틴) (추천도 : 중상)");
                    eb.AddField("몬스터라이프 쁘띠 아카이럼 (SS)",
                        "잠재능력 : 버프 지속시간 +5%\r\n" +
                        "수급 난이도 : ★★★☆☆\r\n" +
                        "채용 추천 직업 : 버프 지속시간 채용 직업(모험가 마법사, 루미너스, 카이저 등) (추천도 : 상)");
                    eb.AddField("몬스터라이프 반반 (SS)",
                        "잠재능력 : 버프 지속시간 +5%\r\n" +
                        "수급 난이도 : ★★★☆☆\r\n" +
                        "채용 추천 직업 : 버프 지속시간 채용 직업(모험가 마법사, 루미너스, 카이저 등) (추천도 : 상)");
                    eb.AddField("몬스터라이프 군단장 윌 (SS)",
                        "잠재능력 : 버프 지속시간 +6%\r\n" + 
                        "수급 난이도 : ★x10\r\n" +
                        "채용 추천 직업 : 버프 지속시간 채용 직업(모험가 마법사, 루미너스, 카이저 등) (추천도 : 중)\r\n" +
                        "⚠️ 새끼거미 보유시에만 채용을 추천합니다.");
                    eb.AddField("몬스터라이프 큰 운영자의 벌룬 (SS)",
                        "잠재능력 : 2% 확률로 스킬 재사용 대기시간 미적용\r\n" +
                        "수급 난이도 : ★★★★★\r\n" +
                        "채용 추천 직업 : 제로, 데몬어벤저 (추천도 : 중)");
                    eb.AddField("몬스터라이프 쁘띠 은월 (SS)",
                        "잠재능력 : 4% 확률로 스킬 재사용 대기시간 미적용\r\n" +
                        "수급 난이도 : ★★★★☆\r\n" +
                        "채용 추천 직업 : 쁘띠 랑(스페셜 SS) 보유 전직업 (추천도 최상)");
                    eb.AddField("몬스터라이프 피에르 (SS)",
                        "잠재능력 : 파이널 어택류의 데미지 15% 증가\r\n" +
                        "수급 난이도 : ★★★☆☆\r\n" +
                        "채용 추천 직업 : 파이널 어택 보유 전직업 (추천도 최상)");
                    break;
                case MLStats.HpStats:
                    eb.AddField("몬스터라이프 내면의 분노 (SS)",
                        "잠재능력 : 최대 HP +500\r\n" +
                        "수급 난이도 : ★★★☆☆\r\n" +
                        "채용 추천 직업 : 데몬 어벤저 (추천도 중상)");
                    eb.AddField("몬스터라이프 자이언트 다크소울 (SS)",
                        "잠재능력 : 최대 HP +500\r\n" +
                        "수급 난이도 : ★★★☆☆\r\n" +
                        "채용 추천 직업 : 데몬 어벤저 (추천도 중하)");
                    eb.AddField("몬스터라이프 킹 캐슬 골렘 (SS)",
                        "잠재능력 : 방어력 +150, 최대 HP +750\r\n" +
                        "수급 난이도 : ★★★☆☆\r\n" +
                        "채용 추천 직업 : 데몬 어벤저 (추천도 중하)");
                    eb.AddField("몬스터라이프 작은 운영자 벌룬 (SS)",
                        "잠재능력 : 최대 HP +2%\r\n" +
                        "수급 난이도 : ★★★★☆\r\n" +
                        "채용 추천 직업 : 데몬 어벤저 (추천도 상)");
                    break;
                case MLStats.HuntStats:
                    eb.AddField("몬스터라이프 월묘 도둑 (S)",
                        "잠재능력 : 메소 획득량 +4%\r\n" +
                        "수급 난이도 : ★☆☆☆☆\r\n" +
                        "채용 추천 직업 : 사냥러 (추천도 상)");
                    eb.AddField("몬스터라이프 쁘띠 오르카 (SS)",
                        "잠재능력 : 캐릭터의 획득 경험치 +3%\r\n" +
                        "수급 난이도 : ★★★☆☆\r\n" +
                        "채용 추천 직업 : 사냥러 (추천도 상)");
                    eb.AddField("몬스터라이프 쁘띠 메르세데스 (SS)",
                        "잠재능력 : 캐릭터의 획득 경험치 +3%\r\n" +
                        "수급 난이도 : ★★★★★\r\n" +
                        "채용 추천 직업 : 사냥러 (추천도 하)");
                    break;
                case MLStats.EtcStats:
                    eb.AddField("몬스터라이프 신수 (S)",
                        "잠재능력 : 공격시 10% 확률로 HP, MP 20 회복\r\n" +
                        "수급 난이도 : ★★☆☆☆\r\n" +
                        "채용 추천 직업 : X");
                    eb.AddField("몬스터라이프 주니어 발록 (S)",
                        "잠재능력 : 피격 시 무적시간 +1초\r\n" +
                        "수급 난이도 : ★★☆☆☆\r\n" +
                        "채용 추천 직업 : X");
                    eb.AddField("몬스터라이프 크림슨 발록 (S)",
                        "잠재능력 : 피격시 5% 확률로 3초 동안 무적효과\r\n" +
                        "수급 난이도 : ★★☆☆☆\r\n" +
                        "채용 추천 직업 : X");
                    eb.AddField("몬스터라이프 게오르크 (S)",
                        "잠재능력 : 방여럭 +150, 이동속도 +5\r\n" +
                        "수급 난이도 : ★★☆☆☆\r\n" +
                        "채용 추천 직업 : X");
                    eb.AddField("몬스터라이프 몰킹 (S)",
                        "잠재능력 : 이동속도 +10\r\n" +
                        "수급 난이도 : ★★☆☆☆\r\n" +
                        "채용 추천 직업 : X");
                    eb.AddField("몬스터라이프 겁에 질린 사자 (SS)",
                        "잠재능력 : 피격시 3% 확률로 3초 동안 무적효과\r\n" +
                        "수급 난이도 : ★★★★☆\r\n" +
                        "채용 추천 직업 : X");
                    eb.AddField("몬스터라이프 쁘띠 자쿰 (SS)",
                        "잠재능력 : 피격시 3% 확률로 가드\r\n" +
                        "수급 난이도 : ★★★★☆\r\n" +
                        "채용 추천 직업 : X");
                    eb.AddField("몬스터라이프 토토 (SS)",
                        "잠재능력 : 이동속도 +5\r\n" +
                        "수급 난이도 : ★★★☆☆\r\n" +
                        "채용 추천 직업 : X");
                    eb.AddField("몬스터라이프 타란튤로스 (SS)",
                        "잠재능력 : 상태이상 내성 +1\r\n" +
                        "수급 난이도 : ★★★★☆\r\n" +
                        "채용 추천 직업 : X");
                    eb.AddField("몬스터라이프 성장 중인 미르 (SS)",
                        "잠재능력 : 상태이상 내성 +5\r\n" +
                        "수급 난이도 : ★★★★☆\r\n" +
                        "채용 추천 직업 : X");
                    eb.AddField("몬스터라이프 거대 거미 (SS)",
                        "잠재능력 : 상태이상 내성 +3%\r\n" +
                        "수급 난이도 : ★★★★★\r\n" +
                        "채용 추천 직업 : X");
                    break;
            }
            eb.WithColor(Color.Purple);
            await RespondAsync("", embed: eb.Build(), ephemeral: true);
        }
    }
}
