using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeanBeanBot.Persistence.Dto;
using SeanBeanBot.Domain.Models;
using System.Runtime.CompilerServices;

namespace SeanBeanBot.Persistence.Mapping
{
    internal static class EntityToDiscordMessage
    {
        public static DiscordMessageDetails Map(this DiscordNameMappingEntity entity, CivTurn civTurn)
            => new DiscordMessageDetails(civTurn, entity.DiscordName);
    }
}
