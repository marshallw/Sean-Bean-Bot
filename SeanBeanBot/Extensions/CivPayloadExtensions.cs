using SeanBeanBot.Contracts;
using SeanBeanBot.Domain.Models;

namespace SeanBeanBot.Extensions
{
    public static class CivPayloadExtensions
    {
        public static CivTurn ToModel(this CivPayload payload) =>
            new CivTurn() { GameName = payload.value1, SteamName = payload.value2, Turn = payload.value3 };
    }
}
