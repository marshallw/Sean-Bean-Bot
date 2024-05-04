using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functional;
using SeanBeanBot.Domain.Interfaces;
using SeanBeanBot.Domain.Models;
using SeanBeanBot.Persistence.Dto;
using SeanBeanBot.Persistence.Mapping;

namespace SeanBeanBot.Persistence.Storage
{
    public class DiscordStorage : IDiscordStorage
    {
        private IStorageAccountClient _client { get; init; }
        private readonly string _tableName = "DiscordNameMapping";

        public DiscordStorage(IStorageAccountClient client) => _client = client;

        public async Task<Result<Option<DiscordMessageDetails>, string>> TryGetDiscordName(CivTurn turn) =>
            await _client.TryGetRecord<DiscordNameMappingEntity>(_tableName, turn.SteamName)
                   .Select(option => option.Select(entity => entity.Map(turn)));
    }
}
