using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeanBeanBot.Contracts
{
    public record struct CivPayload
    {
        public required string value1 { get; init; }
        public required string value2 { get; init; }
        public required int value3 { get; init; }

        [SetsRequiredMembers]
        public CivPayload(string value1, string value2, int value3) =>
            (this.value1, this.value2, this.value3) = (value1, value2, value3);
    }
}
