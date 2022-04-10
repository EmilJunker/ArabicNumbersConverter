using System;
using System.Globalization;
using System.Linq;

namespace ArabicNumbersConverter
{
    /// <summary>
    /// Convert numerals between Western-Arabic, Eastern-Arabic, Persian, and other number systems.
    /// </summary>
    public static class ArabicNumbers
    {
        /// <summary>
        /// Converts a number to a culture-specific string.
        /// </summary>
        /// <param name="number">An integer or floating point number.</param>
        /// <param name="culture">A culture identifier string.</param>
        /// <returns>A culture-specific string representation of the number.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="CultureNotFoundException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        private static string ToCultureString<T>(T number, string culture) where T : IFormattable
        {
            CultureInfo cultureInfo = CultureInfo.GetCultureInfo(culture);
            string[] cultureDigits = cultureInfo.NumberFormat.NativeDigits;
            string result = String.Join(String.Empty, number.ToString(null, cultureInfo).Select(
                c => Char.IsDigit(c) ? cultureDigits[(byte)Char.GetNumericValue(c)] : c.ToString()));
            return result;
        }

        /// <summary>
        /// Converts a decimal floating point number to a culture-specific string.
        /// </summary>
        /// <param name="number">A decimal floating point number.</param>
        /// <param name="culture">A culture identifier string.</param>
        /// <returns>A culture-specific string representation of the number.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="CultureNotFoundException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static string ToCultureString(this decimal number, string culture)
        {
            return ToCultureString<decimal>(number, culture);
        }

        /// <summary>
        /// Converts a double floating point number to a culture-specific string.
        /// </summary>
        /// <param name="number">A double floating point number.</param>
        /// <param name="culture">A culture identifier string.</param>
        /// <returns>A culture-specific string representation of the number.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="CultureNotFoundException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static string ToCultureString(this double number, string culture)
        {
            return ToCultureString<double>(number, culture);
        }

        /// <summary>
        /// Converts a floating point number to a culture-specific string.
        /// </summary>
        /// <param name="number">A floating point number.</param>
        /// <param name="culture">A culture identifier string.</param>
        /// <returns>A culture-specific string representation of the number.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="CultureNotFoundException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static string ToCultureString(this float number, string culture)
        {
            return ToCultureString<float>(number, culture);
        }

        /// <summary>
        /// Converts a long integer number to a culture-specific string.
        /// </summary>
        /// <param name="number">A long integer number.</param>
        /// <param name="culture">A culture identifier string.</param>
        /// <returns>A culture-specific string representation of the number.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="CultureNotFoundException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static string ToCultureString(this long number, string culture)
        {
            return ToCultureString<long>(number, culture);
        }

        /// <summary>
        /// Converts an unsigned long integer number to a culture-specific string.
        /// </summary>
        /// <param name="number">An unsigned long integer number.</param>
        /// <param name="culture">A culture identifier string.</param>
        /// <returns>A culture-specific string representation of the number.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="CultureNotFoundException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static string ToCultureString(this ulong number, string culture)
        {
            return ToCultureString<ulong>(number, culture);
        }

        /// <summary>
        /// Converts an integer number to a culture-specific string.
        /// </summary>
        /// <param name="number">An integer number.</param>
        /// <param name="culture">A culture identifier string.</param>
        /// <returns>A culture-specific string representation of the number.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="CultureNotFoundException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static string ToCultureString(this int number, string culture)
        {
            return ToCultureString<int>(number, culture);
        }

        /// <summary>
        /// Converts an unsigned integer number to a culture-specific string.
        /// </summary>
        /// <param name="number">An unsigned integer number.</param>
        /// <param name="culture">A culture identifier string.</param>
        /// <returns>A culture-specific string representation of the number.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="CultureNotFoundException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static string ToCultureString(this uint number, string culture)
        {
            return ToCultureString<uint>(number, culture);
        }

        /// <summary>
        /// Converts a short integer number to a culture-specific string.
        /// </summary>
        /// <param name="number">A short integer number.</param>
        /// <param name="culture">A culture identifier string.</param>
        /// <returns>A culture-specific string representation of the number.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="CultureNotFoundException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static string ToCultureString(this short number, string culture)
        {
            return ToCultureString<short>(number, culture);
        }

        /// <summary>
        /// Converts an unsigned short integer number to a culture-specific string.
        /// </summary>
        /// <param name="number">An unsigned short integer number.</param>
        /// <param name="culture">A culture identifier string.</param>
        /// <returns>A culture-specific string representation of the number.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="CultureNotFoundException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static string ToCultureString(this ushort number, string culture)
        {
            return ToCultureString<ushort>(number, culture);
        }

        /// <summary>
        /// Converts a signed byte number to a culture-specific string.
        /// </summary>
        /// <param name="number">A signed byte number.</param>
        /// <param name="culture">A culture identifier string.</param>
        /// <returns>A culture-specific string representation of the number.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="CultureNotFoundException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static string ToCultureString(this sbyte number, string culture)
        {
            return ToCultureString<sbyte>(number, culture);
        }

        /// <summary>
        /// Converts a byte number to a culture-specific string.
        /// </summary>
        /// <param name="number">A byte number.</param>
        /// <param name="culture">A culture identifier string.</param>
        /// <returns>A culture-specific string representation of the number.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="CultureNotFoundException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static string ToCultureString(this byte number, string culture)
        {
            return ToCultureString<byte>(number, culture);
        }

        /// <summary>
        /// Converts all digits in a string to Western-Arabic numerals.
        /// </summary>
        /// <param name="numberString">The input string.</param>
        /// <returns>The input string where all numbers are replaced by Western-Arabic numbers.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        private static string ToWesternArabicString(this string numberString)
        {
            string result = String.Join(String.Empty, numberString.Select(
                c => Char.IsDigit(c) ? Char.GetNumericValue(c).ToString() : c.ToString()));
            return result;
        }

        /// <summary>
        /// Converts a number string from any culture to an integer.
        /// </summary>
        /// <param name="numberString">A string representation of an integer number.</param>
        /// <returns>The integer number represented by the string.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static int ToInteger(this string numberString)
        {
            return Int32.Parse(ToWesternArabicString(numberString));
        }

        /// <summary>
        /// Converts a number string from the specified culture to an integer.
        /// </summary>
        /// <param name="numberString">A string representation of an integer number.</param>
        /// <param name="culture">A culture identifier string.</param>
        /// <returns>The integer number represented by the string.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="CultureNotFoundException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static int ToInteger(this string numberString, string culture)
        {
            CultureInfo cultureInfo = CultureInfo.GetCultureInfo(culture);
            return Int32.Parse(ToWesternArabicString(numberString), cultureInfo);
        }

        /// <summary>
        /// Converts a number string from any culture to a long integer.
        /// </summary>
        /// <param name="numberString">A string representation of a long integer number.</param>
        /// <returns>The long integer number represented by the string.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static long ToLong(this string numberString)
        {
            return Int64.Parse(ToWesternArabicString(numberString));
        }

        /// <summary>
        /// Converts a number string from the specified culture a long integer.
        /// </summary>
        /// <param name="numberString">A string representation of a long integer number.</param>
        /// <param name="culture">A culture identifier string.</param>
        /// <returns>The long integer number represented by the string.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="CultureNotFoundException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static long ToLong(this string numberString, string culture)
        {
            CultureInfo cultureInfo = CultureInfo.GetCultureInfo(culture);
            return Int64.Parse(ToWesternArabicString(numberString), cultureInfo);
        }

        /// <summary>
        /// Converts a number string from the specified culture to a floating point number.
        /// </summary>
        /// <param name="numberString">A string representation of a floating point number.</param>
        /// <param name="culture">A culture identifier string.</param>
        /// <returns>The floating point number represented by the string.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="CultureNotFoundException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static float ToFloat(this string numberString, string culture)
        {
            CultureInfo cultureInfo = CultureInfo.GetCultureInfo(culture);
            return float.Parse(ToWesternArabicString(numberString), cultureInfo);
        }

        /// <summary>
        /// Converts a number string from the specified culture to a double floating point number.
        /// </summary>
        /// <param name="numberString">A string representation of a double floating point number.</param>
        /// <param name="culture">A culture identifier string.</param>
        /// <returns>The double floating point number represented by the string.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="CultureNotFoundException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static double ToDouble(this string numberString, string culture)
        {
            CultureInfo cultureInfo = CultureInfo.GetCultureInfo(culture);
            return double.Parse(ToWesternArabicString(numberString), cultureInfo);
        }
    }
}
