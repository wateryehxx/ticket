using System.Security.Cryptography;
using System.Text;

namespace Domain;

public static class Extensions
{
    public static string ToMd5(this string value)
    {
        using var md5 = MD5.Create();
        var bytes = Encoding.UTF8.GetBytes(value);
        var hash = md5.ComputeHash(bytes);
        return BitConverter.ToString(hash)
            .Replace("-", string.Empty)
            .ToUpper();
    }
}