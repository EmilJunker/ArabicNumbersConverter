using ArabicNumbersConverter;
using System;
using System.Globalization;
using Xunit;

namespace ArabicNumbersConverterUnitTests
{
    public class NumberToCultureStringTests
    {
        [Fact]
        public void ByteToWesternArabic()
        {
            byte number = 64;
            string result = number.ToCultureString("en-US");
            Assert.Equal("64", result);
        }

        [Fact]
        public void UshortToEasternArabic()
        {
            ushort number = 64;
            string result = number.ToCultureString("ar-SA");
            Assert.Equal("٦٤", result);
        }

        [Fact]
        public void UintToPersoArabic()
        {
            uint number = 64;
            string result = number.ToCultureString("ks-Arab");
            Assert.Equal("۶۴", result);
        }

        [Fact]
        public void UlongToInvariantCulture()
        {
            ulong number = 64;
            string result = number.ToCultureString("");
            Assert.Equal("64", result);
        }

        [Fact]
        public void NegativeSbyteToWesternArabic()
        {
            sbyte number = -64;
            string result = number.ToCultureString("ar-MA");
            Assert.Equal("\u200e-64", result);
        }

        [Fact]
        public void NegativeShortToEasternArabic()
        {
            short number = -64;
            string result = number.ToCultureString("ar-SA");
            Assert.Equal("\u061c-٦٤", result);
        }

        [Fact]
        public void NegativeIntToPersoArabic()
        {
            int number = -64;
            string result = number.ToCultureString("ks-Arab");
            Assert.Equal("\u200e-\u200e۶۴", result);
        }

        [Fact]
        public void NegativeLongToInvariantCulture()
        {
            long number = -64;
            string result = number.ToCultureString("");
            Assert.Equal("-64", result);
        }

        [Fact]
        public void FloatToWesternArabic()
        {
            float number = 8.95F;
            string result = number.ToCultureString("en-US");
            Assert.Equal("8.95", result);
        }

        [Fact]
        public void NegativeFloatToEasternArabic()
        {
            float number = -8.95F;
            string result = number.ToCultureString("ar-SA");
            Assert.Equal("\u061c-٨٫٩٥", result);
        }

        [Fact]
        public void DoubleToPersoArabic()
        {
            double number = 8.95;
            string result = number.ToCultureString("ks-Arab-IN");
            Assert.Equal("۸٫۹۵", result);
        }

        [Fact]
        public void NegativeDoubleToWesternArabic()
        {
            double number = -8.95;
            string result = number.ToCultureString("ar-MA");
            Assert.Equal("\u200e-8,95", result);
        }

        [Fact]
        public void DecimalToEasternArabic()
        {
            decimal number = new(8.95);
            string result = number.ToCultureString("ar-SA");
            Assert.Equal("٨٫٩٥", result);
        }

        [Fact]
        public void NegativeDecimalToPersoArabic()
        {
            decimal number = new(-8.95);
            string result = number.ToCultureString("ks-Arab-IN");
            Assert.Equal("\u200e-\u200e۸٫۹۵", result);
        }

        [Fact]
        public void InvalidCulture()
        {
            Assert.Throws<CultureNotFoundException>(() => ArabicNumbers.ToCultureString(64, "foo-bar"));
        }

        [Fact]
        public void ArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(() => ArabicNumbers.ToCultureString(64, null));
        }
    }

    public class StringToIntegerTests
    {
        [Fact]
        public void WesternArabicToInteger()
        {
            int result = "64".ToInteger();
            Assert.Equal(64, result);
        }

        [Fact]
        public void EasternArabicToInteger()
        {
            int result = "٦٤".ToInteger();
            Assert.Equal(64, result);
        }

        [Fact]
        public void PersoArabicToInteger()
        {
            int result = "۶۴".ToInteger();
            Assert.Equal(64, result);
        }

        [Fact]
        public void NegativeWesternArabicToInteger()
        {
            int result = "-64".ToInteger("en");
            Assert.Equal(-64, result);
        }

        [Fact]
        public void NegativeEasternArabicToInteger()
        {
            int result = "\u061c-٦٤".ToInteger("ar");
            Assert.Equal(-64, result);
        }

        [Fact]
        public void NegativePersoArabicToInteger()
        {
            int result = "\u200e-\u200e۶۴".ToInteger("ks");
            Assert.Equal(-64, result);
        }

        [Fact]
        public void WesternArabicMaxValueToInteger()
        {
            int result = ArabicNumbers.ToInteger("2147483647");
            Assert.Equal(2147483647, result);
        }

        [Fact]
        public void EasternArabicMaxValueToInteger()
        {
            int result = ArabicNumbers.ToInteger("٢١٤٧٤٨٣٦٤٧");
            Assert.Equal(2147483647, result);
        }

        [Fact]
        public void PersoArabicMaxValueToInteger()
        {
            int result = ArabicNumbers.ToInteger("۲۱۴۷۴۸۳۶۴۷");
            Assert.Equal(2147483647, result);
        }

        [Fact]
        public void WesternArabicIntegerOverflow()
        {
            Assert.Throws<OverflowException>(() => ArabicNumbers.ToInteger("2147483648"));
        }

        [Fact]
        public void EasternArabicIntegerOverflow()
        {
            Assert.Throws<OverflowException>(() => ArabicNumbers.ToInteger("٢١٤٧٤٨٣٦٤٨"));
        }

        [Fact]
        public void PersoArabicIntegerOverflow()
        {
            Assert.Throws<OverflowException>(() => ArabicNumbers.ToInteger("۲۱۴۷۴۸۳۶۴۸"));
        }

        [Fact]
        public void WesternArabicNotAnInteger()
        {
            Assert.Throws<FormatException>(() => ArabicNumbers.ToInteger("64.5"));
        }

        [Fact]
        public void EasternArabicNotAnInteger()
        {
            Assert.Throws<FormatException>(() => ArabicNumbers.ToInteger("٦٤٫٥"));
        }

        [Fact]
        public void PersoArabicNotAnInteger()
        {
            Assert.Throws<FormatException>(() => ArabicNumbers.ToInteger("۶۴٫۵"));
        }

        [Fact]
        public void EmptyString()
        {
            Assert.Throws<FormatException>(() => ArabicNumbers.ToInteger(""));
        }

        [Fact]
        public void ArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(() => ArabicNumbers.ToInteger(null));
        }

        [Fact]
        public void CultureArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(() => ArabicNumbers.ToInteger("64", null));
        }
    }

    public class StringToLongTests
    {
        [Fact]
        public void WesternArabicToLong()
        {
            long result = "64".ToLong();
            Assert.Equal(64, result);
        }

        [Fact]
        public void EasternArabicToLong()
        {
            long result = "٦٤".ToLong();
            Assert.Equal(64, result);
        }

        [Fact]
        public void PersoArabicToLong()
        {
            long result = "۶۴".ToLong();
            Assert.Equal(64, result);
        }

        [Fact]
        public void NegativeWesternArabicToLong()
        {
            long result = "\u200e-64".ToLong("ar-MA");
            Assert.Equal(-64, result);
        }

        [Fact]
        public void NegativeEasternArabicToLong()
        {
            long result = "\u061c-٦٤".ToLong("ar-SA");
            Assert.Equal(-64, result);
        }

        [Fact]
        public void NegativePersoArabicToLong()
        {
            long result = "\u200e-\u200e۶۴".ToLong("ks-Arab");
            Assert.Equal(-64, result);
        }

        [Fact]
        public void WesternArabicMaxValueToLong()
        {
            long result = ArabicNumbers.ToLong("9223372036854775807");
            Assert.Equal(9223372036854775807, result);
        }

        [Fact]
        public void EasternArabicMaxValueToLong()
        {
            long result = ArabicNumbers.ToLong("٩٢٢٣٣٧٢٠٣٦٨٥٤٧٧٥٨٠٧");
            Assert.Equal(9223372036854775807, result);
        }

        [Fact]
        public void PersoArabicMaxValueToLong()
        {
            long result = ArabicNumbers.ToLong("۹۲۲۳۳۷۲۰۳۶۸۵۴۷۷۵۸۰۷");
            Assert.Equal(9223372036854775807, result);
        }

        [Fact]
        public void WesternArabicLongOverflow()
        {
            Assert.Throws<OverflowException>(() => ArabicNumbers.ToLong("9223372036854775808"));
        }

        [Fact]
        public void EasternArabicLongOverflow()
        {
            Assert.Throws<OverflowException>(() => ArabicNumbers.ToLong("٩٢٢٣٣٧٢٠٣٦٨٥٤٧٧٥٨٠٨"));
        }

        [Fact]
        public void PersoArabicLongOverflow()
        {
            Assert.Throws<OverflowException>(() => ArabicNumbers.ToLong("۹۲۲۳۳۷۲۰۳۶۸۵۴۷۷۵۸۰۸"));
        }

        [Fact]
        public void WesternArabicNotALong()
        {
            Assert.Throws<FormatException>(() => ArabicNumbers.ToLong("64.5"));
        }

        [Fact]
        public void EasternArabicNotALong()
        {
            Assert.Throws<FormatException>(() => ArabicNumbers.ToLong("٦٤٫٥"));
        }

        [Fact]
        public void PersoArabicNotALong()
        {
            Assert.Throws<FormatException>(() => ArabicNumbers.ToLong("۶۴٫۵"));
        }

        [Fact]
        public void EmptyString()
        {
            Assert.Throws<FormatException>(() => ArabicNumbers.ToLong(""));
        }

        [Fact]
        public void ArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(() => ArabicNumbers.ToLong(null));
        }

        [Fact]
        public void CultureArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(() => ArabicNumbers.ToLong("64", null));
        }
    }

    public class StringToFloatTests
    {
        [Fact]
        public void WesternArabicToFloat()
        {
            float result = "1,5".ToFloat("de-DE");
            Assert.Equal(1.5, result);
        }

        [Fact]
        public void EasternArabicToFloat()
        {
            float result = "١٫٥".ToFloat("ar-SA");
            Assert.Equal(1.5, result);
        }

        [Fact]
        public void PersoArabicToFloat()
        {
            float result = "۱٫۵".ToFloat("ks-Arab");
            Assert.Equal(1.5, result);
        }

        [Fact]
        public void NegativeWesternArabicToFloat()
        {
            float result = "-1.5".ToFloat("");
            Assert.Equal(-1.5, result);
        }

        [Fact]
        public void NegativeEasternArabicToFloat()
        {
            float result = "\u061c-١٫٥".ToFloat("ar");
            Assert.Equal(-1.5, result);
        }

        [Fact]
        public void NegativePersoArabicToFloat()
        {
            float result = "\u200e-\u200e۱٫۵".ToFloat("ks");
            Assert.Equal(-1.5, result);
        }

        [Fact]
        public void WesternArabicNotAFloat()
        {
            Assert.Throws<FormatException>(() => ArabicNumbers.ToFloat("64%", "en"));
        }

        [Fact]
        public void EasternArabicNotAFloat()
        {
            Assert.Throws<FormatException>(() => ArabicNumbers.ToFloat("٦٤%", "ar"));
        }

        [Fact]
        public void PersoArabicNotAFloat()
        {
            Assert.Throws<FormatException>(() => ArabicNumbers.ToFloat("۶۴%", "ks"));
        }

        [Fact]
        public void EmptyString()
        {
            Assert.Throws<FormatException>(() => ArabicNumbers.ToFloat("", ""));
        }

        [Fact]
        public void ArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(() => ArabicNumbers.ToFloat(null, ""));
        }

        [Fact]
        public void CultureArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(() => ArabicNumbers.ToFloat("1.5", null));
        }
    }

    public class StringToDoubleTests
    {
        [Fact]
        public void WesternArabicToDouble()
        {
            double result = "1,5".ToDouble("de-DE");
            Assert.Equal(1.5, result);
        }

        [Fact]
        public void EasternArabicToDouble()
        {
            double result = "١٫٥".ToDouble("ar-SA");
            Assert.Equal(1.5, result);
        }

        [Fact]
        public void PersoArabicToDouble()
        {
            double result = "۱٫۵".ToDouble("ks-Arab");
            Assert.Equal(1.5, result);
        }

        [Fact]
        public void NegativeWesternArabicToDouble()
        {
            double result = "-1.5".ToDouble("");
            Assert.Equal(-1.5, result);
        }

        [Fact]
        public void NegativeEasternArabicToDouble()
        {
            double result = "\u061c-١٫٥".ToDouble("ar");
            Assert.Equal(-1.5, result);
        }

        [Fact]
        public void NegativePersoArabicToDouble()
        {
            double result = "\u200e-\u200e۱٫۵".ToDouble("ks");
            Assert.Equal(-1.5, result);
        }

        [Fact]
        public void WesternArabicNotADouble()
        {
            Assert.Throws<FormatException>(() => ArabicNumbers.ToDouble("64 Hello", "en"));
        }

        [Fact]
        public void EasternArabicNotADouble()
        {
            Assert.Throws<FormatException>(() => ArabicNumbers.ToDouble("٦٤ Hello", "ar"));
        }

        [Fact]
        public void PersoArabicNotADouble()
        {
            Assert.Throws<FormatException>(() => ArabicNumbers.ToDouble("۶۴ Hello", "ks"));
        }

        [Fact]
        public void EmptyString()
        {
            Assert.Throws<FormatException>(() => ArabicNumbers.ToDouble("", ""));
        }

        [Fact]
        public void ArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(() => ArabicNumbers.ToDouble(null, ""));
        }

        [Fact]
        public void CultureArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(() => ArabicNumbers.ToDouble("1.5", null));
        }
    }
}
