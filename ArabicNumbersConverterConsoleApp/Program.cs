using ArabicNumbersConverter;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine((64).ToCultureString("en-US"));       // "64"
Console.WriteLine((64).ToCultureString("ar-SA"));       // "٦٤"
Console.WriteLine((64).ToCultureString("ks-Arab"));     // "۶۴"
Console.WriteLine((64.25).ToCultureString("en-us"));    // "64.25"
Console.WriteLine((64.25).ToCultureString("de-de"));    // "64,25"
Console.WriteLine((64.25).ToCultureString("ar-sa"));    // "٦٤٫٢٥"
Console.WriteLine((-1.5).ToCultureString("en"));        // "-1.5"
Console.WriteLine((-1.5).ToCultureString("fr"));        // "-1,5"
Console.WriteLine((-1.5).ToCultureString("ar"));        // "-١٫٥"
Console.WriteLine((-1.5).ToCultureString("ar-ma"));     // "-1,5"
Console.WriteLine((-1.5).ToCultureString("ks"));        // "-۱٫۵"

Console.WriteLine();

Console.WriteLine("64".ToInteger());                    // 64
Console.WriteLine("٦٤".ToInteger());                    // 64
Console.WriteLine("۶۴".ToInteger("ks"));                // 64
Console.WriteLine("2147483648".ToLong());               // 2147483648
Console.WriteLine("٢١٤٧٤٨٣٦٤٨".ToLong("ar"));           // 2147483648
Console.WriteLine("۲۱۴۷۴۸۳۶۴۸".ToLong("ks-arab"));      // 2147483648

Console.WriteLine();

Console.WriteLine("-1.5".ToFloat(""));                  // -1.5
Console.WriteLine("\u061c-١٫٥".ToFloat("ar"));          // -1.5
Console.WriteLine("-1,5".ToDouble("de"));               // -1.5
Console.WriteLine("\u200e-\u200e۱٫۵".ToDouble("ks"));   // -1.5
