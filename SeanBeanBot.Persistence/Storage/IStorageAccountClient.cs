using Azure.Data.Tables;
using Functional;

namespace SeanBeanBot.Persistence.Storage;

public interface IStorageAccountClient
{
    Task<Result<Option<TValue>, string>> TryGetRecord<TValue>(string tableName, string steamName) where TValue : ITableEntity;
}