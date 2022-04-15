using Api.Models;
using DbContext.Ticket.Tables;
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

    public string Encrypt(User user)
    {
        return JwtBuilder.Create()
            .WithAlgorithm(new HMACSHA256Algorithm())
            .WithSecret(_options.Jwt.Secret)
            .AddClaim("exp", DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds())
            .AddClaim(nameof(user.UserId), user.UserId)
            .AddClaim(nameof(user.RoleId), user.RoleId)
            .Encode();
    }
}