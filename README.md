# Arabic Numbers Converter

Convert numerals between Western-Arabic, Eastern-Arabic, Persian, and other number systems.

## Installation

Get it from https://www.nuget.org/packages/ArabicNumbersConverter.

## Usage

Convert numbers to culture-specific strings:

```cs
(64).ToCultureString("en-US");      // "64"
(64.25).ToCultureString("en-US");   // "64.25"
(64.25).ToCultureString("de-DE");   // "64,25"
(-8).ToCultureString("en");         // "-8"
(-8.1).ToCultureString("fr");       // "-8,1"
(64).ToCultureString("ar");         // "٦٤"
(0).ToCultureString("ar-SA");       // "٠"
(1.5).ToCultureString("ar-SA");     // "١٫٥"
(-8).ToCultureString("ar-sa");      // "-٨"
(-8).ToCultureString("ar-ma");      // "-8"
(64).ToCultureString("ks-Arab");    // "۶۴"
(-1.5).ToCultureString("ks-Arab");  // "-۱٫۵"

(-1.5).ToCultureString("foo-bar");  // throws CultureNotFoundException
```

Convert number strings from any culture to integers:

```cs
"64".ToInteger();                   // 64
"٦٤".ToInteger();                   // 64
"۶۴".ToInteger();                   // 64
"-64".ToLong("en");                 // -64
"\u061c-٦٤".ToLong("ar");           // -64
"\u200e-\u200e۶۴".ToLong("ks");     // -64

"64".ToInteger("foo-bar");          // throws CultureNotFoundException
"1.5".ToInteger();                  // throws FormatException
"2147483648".ToInteger();           // throws OverflowException
```

Convert number strings from any culture to floating point numbers:

```cs
"1.5".ToFloat("");                  // 1.5
"1,5".ToFloat("de");                // 1.5
"١٫٥".ToDouble("ar");               // 1.5
"۱٫۵".ToDouble("ks");               // 1.5

"1.5".ToFloat("foo-bar");           // throws CultureNotFoundException
"1,5".ToFloat("en-US");             // throws FormatException
```

## License

Distributed under the MIT License. See [LICENSE.txt](https://github.com/EmilJunker/ArabicNumbersConverter/blob/main/LICENSE.txt) for more information.

## Donations

If you find this library useful and would like to support me so I can dedicate more time to open source projects like this, here is my [PayPal link](https://www.paypal.me/EmilJunker) - Thanks!
