using ServcoX.Rfc7515C;

var encoded = Rfc7515CEncoder.Encode(new Byte[] { 0xFF, 0xFE, 0xED });
Console.WriteLine(encoded);

var decoded = Rfc7515CEncoder.Decode("__7t");
Console.WriteLine(BitConverter.ToString(decoded));