namespace Api.Models;

public class Options
{
    public string? ConnectionString { get; set; }
    public JwtOptions Jwt { get; set; }

    public class JwtOptions
    {
        public string Secret { get; set; }
    }
}