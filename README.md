# ServcoX.RFC7515C
ServcoX RFC7515C is an alternative Base64 encoding that uses URL-safe characters according to  [RFC7515 Appendix C](https://datatracker.ietf.org/doc/html/rfc7515#appendix-C).

For instance, encoding 0xFFFEED using Base64 yields "//7t". This is a problem if you'd like to use it in a URL,
since it contains the illegal character "/". You can see the problem in the URL `https://blah.com?id=//7t`.
Encoding the same value using RFC7515C yields "__7t", which is perfectly acceptable to use (`https://blah.com?id=__7t`).

## How to make it go?
Encode like this:
```c#
var encoded = Rfc7515CEncoder.Encode(new Byte[] { 0xFF, 0xFE, 0xED });
Console.WriteLine(encoded); // Outputs "__7t";
```

Decoding is straight forward like this:
```c#
var decoded = Rfc7515CEncoder.Decode("__7t");
Console.WriteLine(BitConverter.ToString(decoded)); // Outputs "FF-FE-ED"
```