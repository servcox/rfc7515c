using ServcoX.Rfc7515C;

var bytes = "Test"u8.ToArray();
var encoded = Rfc7515CEncoder.Encode(bytes);
Console.WriteLine(encoded);

var decoded = Rfc7515CEncoder.Decode(encoded);
