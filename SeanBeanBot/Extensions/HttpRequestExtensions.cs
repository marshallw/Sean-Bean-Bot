using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SeanBeanBot.Contracts;
using Functional;

public static class HttpRequestExtensions
{
    public static async Task<Result<CivPayload, string>> ToCivPayload(this HttpRequest request) =>
        await request.GetBody()
        .Bind(body => Result.Try(() => JsonConvert.DeserializeObject<CivPayload>(body), 
                            exception => exception.Message));

    private static async Task<Result<string, string>> GetBody(this HttpRequest request) => 
        await Result.SuccessAsync<string, string>(new StreamReader(request.Body).ReadToEndAsync());
}