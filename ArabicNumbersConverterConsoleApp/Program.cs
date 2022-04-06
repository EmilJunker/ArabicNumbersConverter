using ArabicNumbersConverter;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine((64).ToCultureString("en-US"));       // "64"
Console.WriteLine((64.25).ToCultureString("en-US"));    // "64.25"
Console.WriteLine((64.25).ToCultureString("de-DE"));    // "64,25"
Console.WriteLine((-8).ToCultureString("en"));          // "-8"
Console.WriteLine((-8.1).ToCultureString("fr"));        // "-8,1"
Console.WriteLine((64).ToCultureString("ar"));          // "٦٤"
Console.WriteLine((0).ToCultureString("ar-SA"));        // "٠"
Console.WriteLine((1.5).ToCultureString("ar-SA"));      // "١٫٥"
Console.WriteLine((-8).ToCultureString("ar-sa"));       // "-٨"
Console.WriteLine((-8).ToCultureString("ar-ma"));       // "-8"
Console.WriteLine((64).ToCultureString("ks-Arab"));     // "۶۴"
Console.WriteLine((-1.5).ToCultureString("ks-Arab"));   // "-۱٫۵"

Console.WriteLine();

Console.WriteLine("64".ToInteger());                // 64
Console.WriteLine("٦٤".ToInteger());                // 64
Console.WriteLine("۶۴".ToInteger());                // 64
Console.WriteLine("-64".ToLong("en"));              // -64
Console.WriteLine("\u061c-٦٤".ToLong("ar"));        // -64
Console.WriteLine("\u200e-\u200e۶۴".ToLong("ks"));  // -64

Console.WriteLine();

Console.WriteLine("1.5".ToFloat(""));               // 1.5
Console.WriteLine("1,5".ToFloat("de"));             // 1.5
Console.WriteLine("١٫٥".ToDouble("ar"));            // 1.5
Console.WriteLine("۱٫۵".ToDouble("ks"));            // 1.5