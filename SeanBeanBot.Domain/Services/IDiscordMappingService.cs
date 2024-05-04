using Functional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeanBeanBot.Domain.Models;

namespace SeanBeanBot.Domain.Services
{
    public interface IDiscordMappingService
    {
        Task<Result<Unit, string>> SendToDiscord(CivTurn turn);
    }
}
