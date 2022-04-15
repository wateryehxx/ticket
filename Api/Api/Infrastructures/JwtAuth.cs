using Api.Models;
using JWT.Algorithms;
using JWT.Builder;

namespace Api.Infrastructures;

public class JwtAuth : IJwtAuth
{
    private readonly Options _options;

    public JwtAuth(Microsoft.Extensions.Options.IOptions<Options> options)
    {
        _options = options.Value;
    }

    public Guid UserId { get; set; }
    public int RoleId { get; set; }

    public void Decode(string bearer)
    {
        var payload = JwtBuilder.Create()
            .WithAlgorithm(new HMACSHA256Algorithm())
            .WithSecret(_options.Jwt.Secret)
            .MustVerifySignature()
            .Decode<IDictionary<string, object>>(bearer);
        UserId = Guid.Parse(payload[nameof(UserId)].ToString() ?? string.Empty);
        RoleId = int.Parse(payload[nameof(RoleId)].ToString() ?? string.Empty);
    }
}