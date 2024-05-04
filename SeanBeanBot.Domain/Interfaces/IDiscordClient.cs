using Functional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeanBeanBot.Domain.Models;

namespace SeanBeanBot.Domain.Interfaces
{
    public interface IDiscordClient
    {
        Task<Result<Unit, string>> SendAsync(DiscordMessageDetails message);
    }
}
