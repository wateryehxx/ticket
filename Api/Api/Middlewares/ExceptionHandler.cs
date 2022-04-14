using System.Net.Mime;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace Api.Middlewares;

internal class ExceptionHandler
{
    private readonly RequestDelegate _next;

    public ExceptionHandler(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            var response = context.Response;
            response.ContentType = MediaTypeNames.Application.Json;
            response.StatusCode = StatusCodes.Status400BadRequest;

            await response.WriteAsync(JsonSerializer.Serialize(exception.ToString(), new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.CjkUnifiedIdeographs),
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            }));
        }
    }
}