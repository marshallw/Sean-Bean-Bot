using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Functional;
using SeanBeanBot.Domain.Models;
using SeanBeanBot.Domain.Interfaces;

namespace SeanBeanBot.Domain.Services;

public class DiscordService : IDiscordMappingService
{
    private IDiscordClient _client {get; init;}
    private IDiscordStorage _storage {get; init;}

    public DiscordService(IDiscordClient client, IDiscordStorage storage) => (_client, _storage) = (client, storage);

    public Task<Result<Unit, string>> SendToDiscord(CivTurn turn) =>
        _storage.TryGetDiscordName(turn)
                .Select(option => option.Match(discordMessage =>  discordMessage, new DiscordMessageDetails()))
                .BindAsync(details => _client.SendAsync(details));
                       
}