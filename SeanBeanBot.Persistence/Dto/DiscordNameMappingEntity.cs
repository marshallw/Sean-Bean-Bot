using Azure;
using Azure.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeanBeanBot.Persistence.Dto;

public record DiscordNameMappingEntity : ITableEntity
{
    public string GameName { get; init; }
    public string DiscordName { get; init; }
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }
}