using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using IrisBot.Database;
using IrisBot.Enums;
using IrisBot.Translation;
using System.Text;

namespace IrisBot.Modules
{
    [DefaultMemberPermissions(GuildPermission.Administrator)]
    public class AdminCommandModule : InteractionModuleBase<ShardedInteractionContext>
    {
        public async Task<GuildEmote?> IsExistsEmojiAsync(SocketGuild guild, string emojiId)
        {
            foreach (var em in await guild.GetEmotesAsync())
            {
                if (string.Equals(em.Id.ToString(), emojiId.ToString()))
                    return em;
            }

            return null;
        }

        [SlashCommand("addemoji", "Add emoji role")]
        public async Task AddEmojiAsync(string emoji, IRole role)
        {
            Translations lang = await TranslationLoader.FindGuildTranslationAsync(Context.Guild.Id);
            bool isCustomEmoji = Emote.TryParse(emoji, out Emote customEmoji);
            SocketRole? botRole = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Iris Player");
            if (role.Permissions.Administrator)
            {
                await RespondAsync(await TranslationLoader.GetTranslationAsync("emoji_admin_reject", lang));
            }
            else if (botRole != null && role.Position > botRole.Position)
            {
                await RespondAsync(await TranslationLoader.GetTranslationAsync("emoji_role_position_error", lang));
            }
            else if (isCustomEmoji)
            {
                await GuildSettings.UpdateRoleEmojiIdsAsync(Context.Guild.Id, role.Id, customEmoji.Id);
                await RespondAsync($"{await TranslationLoader.GetTranslationAsync("emoji_add_success", lang)}\r\n{customEmoji.ToString()} | {role.Name}");
            }
            else
            {
                await RespondAsync(await TranslationLoader.GetTranslationAsync("emoji_not_exists", lang));
            }
        }

        [SlashCommand("emojilist", "View list of emoji role")]
        public async Task ListEmoji()
        {
            Translations lang = await TranslationLoader.FindGuildTranslationAsync(Context.Guild.Id);
            List<string>? emojiList = GuildSettings.FindRoleEmojiIds(Context.Guild.Id);
            if (emojiList == null || emojiList.Count == 0)
            {
                await RespondAsync(await TranslationLoader.GetTranslationAsync("emojirole_not_exists", lang));
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                int i = 0;
                foreach (var val in emojiList)
                {
                    if (string.IsNullOrEmpty(val)) continue;

                    string[] tmp = val.Split('|'); // TMP[0] = ROLE, TMP[1] = EMOJI
                    GuildEmote? emote = await IsExistsEmojiAsync(Context.Guild, tmp[1]);
                    var role = Context.Guild.GetRole(Convert.ToUInt64(tmp[0]));

                    sb.Append($"{i}. ");
                    if (emote == null)
                        sb.Append(await TranslationLoader.GetTranslationAsync("removed_emoji", lang));
                    else
                        sb.Append(emote.ToString());

                    sb.Append(" | ");
                    if (role == null)
                        sb.Append(await TranslationLoader.GetTranslationAsync("removed_role", lang) + "\r\n");
                    else
                        sb.Append(role.Name + "\r\n");
                    i++;
                }

                if (string.IsNullOrEmpty(sb.ToString()))
                    await RespondAsync(await TranslationLoader.GetTranslationAsync("emojirole_not_exists", lang));
                else
                    await RespondAsync(sb.ToString(), ephemeral: true);
            }
        }

        [SlashCommand("rmemoji", "Remove emoji role")]
        public async Task RemoveEmoji(int index)
        {
            Translations lang = await TranslationLoader.FindGuildTranslationAsync(Context.Guild.Id);
            List<string>? emojiList = GuildSettings.FindRoleEmojiIds(Context.Guild.Id);
            if (emojiList == null || emojiList.Count == 0)
            {
                await RespondAsync(await TranslationLoader.GetTranslationAsync("emojirole_not_exists", lang));
            }
            else if (index >= emojiList.Count || index < 0)
            {
                await RespondAsync(await TranslationLoader.GetTranslationAsync("emoji_correct_number", lang));
            }
            else
            {
                string[] tmp = emojiList.ElementAt(index).Split("|"); // TMP[0] = ROLE, TMP[1] = EMOJI
                await GuildSettings.RemoveEmojiAsync(Context.Guild.Id, Convert.ToUInt64(tmp[0]), Convert.ToUInt64(tmp[1]));
                await RespondAsync(await TranslationLoader.GetTranslationAsync("emoji_remove_success", lang));
            }
        }

        [MessageCommand("rolemessage")]
        [RequireBotPermission(GuildPermission.EmbedLinks)]
        [RequireBotPermission(GuildPermission.SendMessages)]
        public async Task Role(IMessage message)
        {
            Translations lang = await TranslationLoader.FindGuildTranslationAsync(Context.Guild.Id);
            await GuildSettings.UpdateRoleMessageIdAsync(message.Id, Context.Guild.Id);
            await RespondAsync(await TranslationLoader.GetTranslationAsync("emoji_message_change_success", lang));
        }

        [SlashCommand("language", "Set bot language")]
        [RequireBotPermission(GuildPermission.EmbedLinks)]
        [RequireBotPermission(GuildPermission.SendMessages)]
        public async Task Language(Translations language)
        {
            await GuildSettings.UpdateLanguageAsync(language, Context.Guild.Id);

            Translations lang = await TranslationLoader.FindGuildTranslationAsync(Context.Guild.Id);
            await RespondAsync(await TranslationLoader.GetTranslationAsync("language_change", lang));
        }

        [SlashCommand("tmpprivate", "Toggle private channel private.")]
        [RequireBotPermission(GuildPermission.EmbedLinks)]
        [RequireBotPermission(GuildPermission.SendMessages)]
        public async Task ToggleTmpPrivate(bool isPrivate)
        {
            Translations lang = await TranslationLoader.FindGuildTranslationAsync(Context.Guild.Id);
            await GuildSettings.UpdateIsPrivateAsync(isPrivate, Context.Guild.Id);
            if (isPrivate)
                await RespondAsync(await TranslationLoader.GetTranslationAsync("tmp_channel_isprivate_true", lang));
            else
                await RespondAsync(await TranslationLoader.GetTranslationAsync("tmp_channel_isprivate_false", lang));
        }
        /*
        [SlashCommand("notice", "asdf")]
        [RequireBotPermission(GuildPermission.EmbedLinks)]
        [RequireBotPermission(GuildPermission.SendMessages)]
        public async Task MakeNoticeAsync(string emoji)
        {
            await RespondAsync("Complete!");
            
            for (int i = 1; i <= 10; i++)
            {
                await Task.Delay(2000);
                EmbedBuilder embed = new EmbedBuilder();
                switch (i)
                {
                    case 1:
                        embed.WithTitle("1. 노블 스킬 사용");
                        embed.WithDescription("- 수로 및 플래그 주 1회 참여시 사용 가능\r\n" +
                            "- 둘중 하나라도 미참여시 노블 스킬 사용 불가능. 단, 길드 추방이 아닌 노블스킬 사용 제한" +
                            "- 노블 스킬을 사용하지 않는다면 길드 컨텐츠 안해도 OK\r\n" +
                            "- 지각비 (수로 플래그 각각 젬스톤 50개) 제출 시 노블 스킬 사용 가능\r\n" +
                            "- 수로 2000점 이상 달성시 플래그 면제!");
                        embed.WithColor(Color.Red);
                        break;
                    case 2:
                        embed.WithTitle("2. 보스 파티 분쟁");
                        embed.WithDescription("- 길드원간의 다툼은 관리자 개입 후 융통성 있게 판단 및 조치\r\n" +
                            "- 타 길드원이 속한 보스 파티는 관리자 개입 X, 해당 파티 내부에서 원만하게 해결할 것");
                        embed.WithColor(Color.Orange);
                        break;
                    case 3:
                        embed.WithTitle("3. 타 게임");
                        embed.WithDescription("- 메이플과 타 게임의 주객전도 → 경고 1회 후 추방\r\n" +
                            "- 휴메 선언하신 후 길드원들과 타 게임 → 즉시 추방\r\n" +
                            "- 메할일 다 끝난 경우 플레이 OK!\r\n" +
                            "- 타 게임 관련 이벤트 개최는 상시 환영!");
                        embed.WithColor(new Color(0xFF, 0xFF, 0x00));
                        break;
                    case 4:
                        embed.WithTitle("4. 직업 관련 발언");
                        embed.WithDescription("- 본인 직업도 아닌데 무작정 올려치거나 내려치며 분란 조장 시 추방\r\n");
                        embed.AddField("예시",
                            "- \"○○○ 개사기 직업이네요~ 물론 난 안함 ㅋ\"\r\n" +
                            "- \"○○○ 개날먹 직업 아니에요? ㅋㅋㅋ 전 극딜도 없고 유틸도 없고 그냥 쓰레기 직업인데...\"\r\n\r\n" +
                            "- 단순한 부러움 및 아쉬운것이 아닌 감정이 섞인 발언을, 특히 밸런스 패치 기간에 유의바랍니다.");
                        embed.WithColor(Color.Green);
                        break;
                    case 5:
                        embed.WithTitle("5. 카카오톡 공지방 사용");
                        embed.AddField("게시 가능한 글",
                            "- 길드원이 알아야 할 내용 ex) 썬데이 메이플, 이벤트, 캐시샵 업데이트 등\r\n" +
                            "- 보스 파티 / 부주 구인 구직\r\n" +
                            "- 큐브, 메포 등 아이템 대량 구매 (메소 거래글은 X)\r\n" +
                            "- 이벤트 개최 (개최 전 관리자 승인 필요!)");
                        embed.AddField("게시 불가능한 글",
                            "- 사적 대화\r\n" +
                            "- 메소 거래");
                        embed.WithColor(Color.Blue);
                        break;
                    case 6:
                        embed.WithTitle("6. 친목 관련 주의사항");
                        embed.WithDescription("- 친해지면서 자연스럽게 말을 놓으시거나 서로 편하게 대하시는건 언제나 환영\r\n" +
                            "(단, 본인 혼자 친해졌다 일방적으로 판단 후 말을 놓지 않도록 주의바랍니다.)\r\n" +
                            "- 내로남불 성격을 띄는 행동 절대 금지\r\n" +
                            "- 남미새/여미새 및 여왕벌 절대 금지");
                        embed.WithColor(new Color(25, 25, 112));
                        break;
                    case 7:
                        embed.WithTitle("7. 휴메 및 부캐릭터 가입");
                        embed.WithDescription("- 가입 가능한 부캐릭터 제한 X, 🔗 [길드원(부캐) 시트](https://docs.google.com/spreadsheets/d/1r7NUZKWwUMI82Xe3sFmyw1efBpJp5aCFPY_6VTd0VBE/edit?usp=sharing) 작성 필수!\r\n" +
                            "- \"시트\" 링크를 클릭하여 본인 캐릭터 옆에 부캐릭터 닉네임 작성\r\n" +
                            "- 부캐용 길드로 편곡 길드 또한 운영중입니다.\r\n" +
                            "- 인게임 가입 소개에 본캐 이름과 가입 목적(주보돌이, 유니온 등) 적어서 신청\r\n" +
                            "- 부캐 탈퇴 시 시트에 적힌 이름 본인이 삭제할 것\r\n" +
                            "- 무통보 미접속 10일 초과시 추방 대상입니다. 현생이 바쁘시면 눈치볼 필요 없이 사전에 관리자분들께 연락 바랍니다!");
                        embed.WithColor(Color.Purple);
                        break;
                    case 8:
                        embed.WithTitle("8. 건의 사항");
                        embed.WithDescription("🔗 [작곡 건의방 오픈채팅](https://open.kakao.com/o/gQrfVFVc)\r\n" +
                            "- 익명 제보는 받지 않습니다\r\n" +
                            "- 애로사항과 가능하면 개편 방향성을 포함하여 건의 바랍니다");
                        embed.WithColor(new Color(255, 0, 255));
                        break;
                    case 9:
                        embed.WithTitle("9. 각종 링크");
                        embed.WithDescription("🔗 [오픈채팅 공지방](https://open.kakao.com/o/ggCeMaOc)\r\n" +
                            "🔗 [오픈채팅 수다방](https://open.kakao.com/o/gs56FuAc) 비밀번호: bera2022\r\n" +
                            "🔗 [디스코드 링크](https://discord.gg/PkRaK8DYVj)\r\n" +
                            "🔗 [길드원(부캐) 시트](https://docs.google.com/spreadsheets/d/1r7NUZKWwUMI82Xe3sFmyw1efBpJp5aCFPY_6VTd0VBE/edit?usp=sharing)\r\n" +
                            "🔗 [오픈채팅 검은마법사 연습 구인구직](https://open.kakao.com/o/gGzRuexe)\r\n");
                        embed.WithColor(new Color(152, 251, 152));
                        break;
                    case 10:

                        embed.WithTitle("10. 디스코드 이용 방법");
                        embed.WithDescription("- 디스코드 서버 별명을 식별 가능한 인게임 별명으로 변경 바랍니다.\r\n" +
                            "ex) 빛나는둘기, 둘기\r\n\r\n" +
                            "- `/tmp 원하는 채널명`을 입력하여 음성 채널을 생성\r\n" +
                            "- Iris Player는 유튜브 음악 재생, 몬스터라이프 조합법 검색 등 다양한 명령어를 지원합니다. 사용법 `/help`\r\n" +
                            "- 읽어주셔서 감사합니다! 이제 아래의 이모지를 클릭하여 디스코드 길드원 권한을 부여받을 수 있습니다!\r\n\r\n");
                        embed.WithColor(new Color(245, 245, 220));
                        break;
                }
                await Context.Channel.SendMessageAsync(embed: embed.Build());
                if (i == 10)
                {
                    bool isCustomEmoji = Emote.TryParse(emoji, out Emote customEmoji);
                    await Context.Channel.SendMessageAsync($"Press {customEmoji.ToString()} to Pay Respect...");
                }
            }
        }
    */
    }

}
