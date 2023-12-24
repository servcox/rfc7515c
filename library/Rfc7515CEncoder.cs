namespace ServcoX.Rfc7515C;

/// <summary>
/// Implementation of URL-safe short base64 encoding https://datatracker.ietf.org/doc/html/rfc7515#appendix-C
/// </summary>
public static class Rfc7515CEncoder
{
    private const Char FirstExtendedInitial = '+';
    private const Char SecondExtendedInitial = '/';
    private const Char FirstExtendedEncoded = '-';
    private const Char SecondExtendedEncoded = '_';
    private const String Padding = "=";

    public static String Encode(Byte[] bytes)
    {
        ArgumentNullException.ThrowIfNull(bytes);
        
        var base64 = Convert.ToBase64String(bytes);
        var rfc7515 = base64
            .Replace(Padding, String.Empty, StringComparison.InvariantCulture)
            .Replace(FirstExtendedInitial, FirstExtendedEncoded)
            .Replace(SecondExtendedInitial, SecondExtendedEncoded);
        return rfc7515;
    }

    public static Byte[] Decode(String rfc7515)
    {
        ArgumentNullException.ThrowIfNull(rfc7515);
        var padding = (rfc7515.Length % 4) switch
        {
            0 => String.Empty,
            2 => Padding + Padding,
            3 => Padding,
            _ => throw new InvalidOperationException("Invalid RFC7515C data, (`len % 4` must not be 1)"),
        };
        var base64 = rfc7515
            .Replace(FirstExtendedEncoded, FirstExtendedInitial)
            .Replace(SecondExtendedEncoded, SecondExtendedInitial) + padding;
        var bytes = Convert.FromBase64String(base64);
        return bytes;
    }
}