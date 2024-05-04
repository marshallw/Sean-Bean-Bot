using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functional;
using SeanBeanBot.Domain.Models;

namespace SeanBeanBot.Domain.Interfaces
{
    public interface IDiscordStorage
    {
        Task<Result<Option<DiscordMessageDetails>, string>> TryGetDiscordName(CivTurn name);
    }
}
