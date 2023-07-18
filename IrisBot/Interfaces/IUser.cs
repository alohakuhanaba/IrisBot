using IrisBot;

namespace IrisBot.Interfaces
{
    public interface IUser
    {
        public string NickName { get; }
        public int? Level { get; }
        public string? Job { get; }
        public int? Popularity { get; }
        public int? DojangFloor { get; }
        public int? Union { get; }
        public List<ExpHistory>? ExpHistories { get; }
        public string? Guild { get; }
        public int? GuildRank { get; }
        public int? GuildSize { get; }
        public int Score { get; }
    }
}

