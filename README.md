# Arabic Numbers Converter

Convert numerals between Western-Arabic, Eastern-Arabic, Persian, and other number systems.

## Installation

Get it from https://www.nuget.org/packages/ArabicNumbersConverter.

## Usage

Convert numbers to culture-specific strings:

```cs
(64).ToCultureString("en-US");      // "64"
(64).ToCultureString("ar-SA");      // "٦٤"
(64).ToCultureString("ks-Arab");    // "۶۴"

(64.25).ToCultureString("en-us");   // "64.25"
(64.25).ToCultureString("de-de");   // "64,25"
(64.25).ToCultureString("ar-sa");   // "٦٤٫٢٥"

(-1.5).ToCultureString("en");       // "-1.5"
(-1.5).ToCultureString("fr");       // "-1,5"
(-1.5).ToCultureString("ar");       // "-١٫٥"
(-1.5).ToCultureString("ar-ma");    // "-1,5"
(-1.5).ToCultureString("ks");       // "-۱٫۵"

(-1.5).ToCultureString("foo-bar");  // throws CultureNotFoundException
```

Convert number strings from any culture to integers:

```cs
"64".ToInteger();                   // 64
"٦٤".ToInteger();                   // 64
"۶۴".ToInteger("ks");               // 64

"2147483648".ToLong();              // 2147483648
"٢١٤٧٤٨٣٦٤٨".ToLong("ar");          // 2147483648
"۲۱۴۷۴۸۳۶۴۸".ToLong("ks-arab");     // 2147483648

"64".ToInteger("foo-bar");          // throws CultureNotFoundException
"1.5".ToInteger();                  // throws FormatException
"2147483648".ToInteger();           // throws OverflowException
```

Convert number strings from any culture to floating point numbers:

```cs
"-1.5".ToFloat("");                 // -1.5
"\u061c-١٫٥".ToFloat("ar");         // -1.5

"-1,5".ToDouble("de");              // -1.5
"\u200e-\u200e۱٫۵".ToDouble("ks");  // -1.5

"-1.5".ToFloat("foo-bar");          // throws CultureNotFoundException
"-1,5".ToFloat("en-US");            // throws FormatException
```

## License

Distributed under the MIT License. See [LICENSE.txt](https://github.com/EmilJunker/ArabicNumbersConverter/blob/main/LICENSE.txt) for more information.

## Donations

If you find this library useful and would like to support me so I can dedicate more time to open source projects like this, here is my [PayPal link](https://www.paypal.me/EmilJunker) - Thanks!
