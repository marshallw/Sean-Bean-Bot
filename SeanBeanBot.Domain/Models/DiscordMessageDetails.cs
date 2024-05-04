namespace SeanBeanBot.Domain.Models;
public record struct DiscordMessageDetails
{
    public string DiscordName { get; init; }
    public string GameName { get; init; }
    public int TurnNumber { get; init; }

    public DiscordMessageDetails(CivTurn turn, string discordName) => 
        (DiscordName, GameName, TurnNumber) = (discordName, turn.GameName, turn.Turn);
}