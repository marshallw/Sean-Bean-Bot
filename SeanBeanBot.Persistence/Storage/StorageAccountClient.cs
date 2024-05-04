using Azure;
using Azure.Data.Tables;
using Functional;
using SeanBeanBot.Domain.Models;
using SeanBeanBot.Persistence.ServiceBus;

namespace SeanBeanBot.Persistence.Storage;

public class StorageAccountClient
{
    private TableClient _client { get; init; }

    public StorageAccountClient(StorageAccountClientConfig _config)
    {
        _client = new TableClient(_config.connectionString, _config.table);
    }

    public async Task<Result<Option<TValue>, string>> TryGetRecord<TValue>(string tableName, string id) where TValue : class, ITableEntity
    {
        try
        {
            var response = await _client.GetEntityIfExistsAsync<TValue>("", "");

            return response.HasValue switch
            {
                true => Result.Success(Option.Some(response.Value)),
                false => Result.Success(Option.None<TValue>())
            };
        }
        catch (RequestFailedException ex)
        {
            return Result.Failure(ex.Message);
        }

    }
}