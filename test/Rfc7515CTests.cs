using FluentAssertions;

namespace ServcoX.Rfc7515C.Test;

public class Rfc7515CTests
{
    public static IEnumerable<object[]> Data =>
        new List<Object[]>
        {
            new Object[] { new Byte[] { }, "" },
            new Object[] { new Byte[] { 1 }, "AQ" },
            new Object[] { new Byte[] { 1, 2, 3 }, "AQID" },
            new Object[] { new Byte[] { 1, 2, 3, 4 }, "AQIDBA" },
            new Object[] { new Byte[] { 0xFF }, "_w" },
            new Object[] { new Byte[] { 0xFA }, "-g" },
            new Object[]
            {
                new Byte[] { 0x3c, 0x09, 0xc2, 0xa0, 0xa6, 0xa4, 0x41, 0x06, 0xa0, 0x7b, 0x14, 0xac, 0x3b, 0x4f, 0xb1, 0x83 }, "PAnCoKakQQagexSsO0-xgw"
            },
        };

    [Theory]
    [MemberData(nameof(Data))]
    public void CanEncode(Byte[] input, String output) => Rfc7515CEncoder.Encode(input).Should().Be(output);

    [Theory]
    [MemberData(nameof(Data))]
    public void CanDecode(Byte[] output, String input) => Rfc7515CEncoder.Decode(input).Should().BeEquivalentTo(output);
}