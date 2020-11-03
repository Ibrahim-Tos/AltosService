using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Altos.Util.Extensions
{
    /// <summary>
    /// Extension methods for working with strings.
    /// </summary>
    public static class StringExtensions
    {
        //we use EmailValidator from FluentValidation. So let's keep them sync - https://github.com/JeremySkinner/FluentValidation/blob/master/src/FluentValidation/Validators/EmailValidator.cs
        private const string _emailExpression = @"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-||_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+([a-z]+|\d|-|\.{0,1}|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])?([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))$";
        private static readonly Regex _emailRegex = new Regex(_emailExpression);

        private const string _simpleChars = "abcdefghijklmnopqrstuvwxyz";
        private const string _complexChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz!@#$%^&*()_+";
        private const string _digitChars = "1234567890";

        /// <summary>
        /// Verifies that a string is in valid e-mail format
        /// </summary>
        /// <param name="email">Email to verify</param>
        /// <returns>true if the string is a valid e-mail address and false if it's not</returns>
        public static bool IsValidEmail(this string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }

            email = email.Trim();

            return _emailRegex.IsMatch(email);
        }

        /// <summary>
        /// Checks to be sure a phone number contains 10 digits as per American phone numbers.  
        /// If 'IsRequired' is true, then an empty string will return False. 
        /// If 'IsRequired' is false, then an empty string will return True.
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="isRequired"></param>
        /// <returns></returns>
        public static bool ValidatePhoneNumber(this string phone, bool isRequired)
        {
            if (string.IsNullOrEmpty(phone) & !isRequired)
                return true;

            if (string.IsNullOrEmpty(phone) & isRequired)
                return false;

            var cleaned = phone.RemoveNonNumeric();
            if (isRequired)
            {
                if (cleaned.Length == 10)
                    return true;
                else
                    return false;
            }
            else
            {
                if (cleaned.Length == 0)
                    return true;
                else if (cleaned.Length > 0 & cleaned.Length < 10)
                    return false;
                else if (cleaned.Length == 10)
                    return true;
                else
                    return false; // should never get here
            }
        }

        /// <summary>
        /// Removes all non numeric characters from a string
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static string RemoveNonNumeric(this string phone)
        {
            return Regex.Replace(phone, @"[^0-9]+", "");
        }

        /// <summary>
        /// Returns a random string of characters using the specified length
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string ComplexRandomString(int length)
        {
            var _rd = new Random();
            var chars = new char[length];
            for (var i = 0; i < length; i++)
            {
                chars[i] = _complexChars[_rd.Next(0, _complexChars.Length)];
            }

            var s = new string(chars);
            return s;
        }

        /// <summary>
        /// Returns a random string of characters using the specified length
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string SimpleRandomString(int length)
        {
            var _rd = new Random();
            var chars = new char[length];
            for (var i = 0; i < length; i++)
            {
                chars[i] = _simpleChars[_rd.Next(0, _simpleChars.Length)];
            }

            var s = new string(chars);
            return s;
        }

        /// <summary>
        /// Returns a random string containing only numbers
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string NumericRandomString(int length)
        {
            var _rd = new Random();
            var chars = new char[length];
            for (var i = 0; i < length; i++)
            {
                chars[i] = _digitChars[_rd.Next(0, _digitChars.Length)];
            }

            var s = new string(chars);
            return s;
        }

        /// <summary>
        /// Converts the specified string to title case
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToTitleCase(this string s)
        {
            if (s.IsNullOrEmpty())
                return s;

            return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(s);
        }

        /// <summary>
        /// Ensure that a string doesn't exceed maximum allowed length
        /// </summary>
        /// <param name="str">Input string</param>
        /// <param name="maxLength">Maximum length</param>
        /// <param name="postfix">A string to add to the end if the original string was shorten</param>
        /// <returns>Input string if its length is OK; otherwise, truncated input string with optional post fix attached</returns>
        public static string Truncate(this string str, int maxLength, string postfix = null)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            if (str.Length <= maxLength)
            {
                return str;
            }

            var pLen = postfix?.Length ?? 0;

            var result = str.Substring(0, maxLength - pLen);
            if (!string.IsNullOrEmpty(postfix))
            {
                result += postfix;
            }

            return result;
        }

        /// <summary>
        /// Returns a copy of this string converted to lowercase if it is not null or empty, otherwise returns the original string value.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToLowerIf(this string s)
        {
            if (!s.IsNullOrEmpty())
            {
                return s.ToLower();
            }

            return s;
        }

        /// <summary>
        /// Removes all trailing and leading whitespace characters 
        /// from the specified string value if it is not null or empty.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string TrimIf(this string s)
        {
            if (!s.IsNullOrEmpty())
            {
                return s.Trim();
            }

            return s;
        }

        /// <summary>
        /// Checks if the specified string is empty, null or whitespace.
        /// </summary>
        /// <param name="s">Input string</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }

        /// <summary>
        /// Returns a new string in which all occurrences of a specified string in the current
        /// instance are replaced with another specified string.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string ReplaceIgnoreCase(this string s, string b, string c)
        {
            if (s == null)
                return s;

            return s.Replace(b, c, StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool EqualsIgnoreCase(this string s, string b)
        {
            if (s == b)
                return true;
            if (s == null || b == null)
                return false;
            if (s == null && b == null) //redundant check
                return true;

            return string.Equals(s.TrimIf(), b.TrimIf(), StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool ContainsIgnoreCase(this string s, string b)
        {
            if (s.EqualsIgnoreCase(b))
                return true;

            if (s.IsNullOrEmpty())
                s = string.Empty;
            if (b.IsNullOrEmpty())
                b = string.Empty;

            return s.TrimIf().ToLowerIf().Contains(b.TrimIf().ToLowerIf());
        }

        public static bool ContainsIgnoreCase(this string s, params string[] values)
        {
            foreach (var item in values)
            {
                if (s.ContainsIgnoreCase(item))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool StartsWithIgnoreCase(this string s, string b)
        {
            if (s == null || b == null)
                return false;

            return s.StartsWith(b, StringComparison.InvariantCultureIgnoreCase);
        }

        public static string GetEnumValue(this Enum s)
        {
            return s.ToString().Replace("_", " ");
        }

        static public string TruncateIfGreaterThan(string var, int length)
        {
            if (var != null)
            {
                if (var.Length > length)
                    return var.Substring(0, length - 2) + "...";
                else
                    return var;
            }
            else
                return "";
        }

        public static int ToNumber(this string s)
        {
            if (s.IsNullOrEmpty())
                return 0;

            s = s ?? string.Empty;
            var result = new string(s.Where(p => char.IsDigit(p)).ToArray());
            if (result.Length == 0)
                return 0;
            else
                return int.Parse(result);
        }

        public static string TrimAllWhitespaceIf(this string s)
        {
            if (s.IsNullOrEmpty())
                return s;
            if (s.Length == 0)
                return s;

            var cArr = s.ToCharArray()
                .Where(c => !char.IsWhiteSpace(c))
                .ToArray();
            var result = new string(cArr);
            return result;
        }

        /// <summary>
        /// Parses the text representing a single JSON value into an instance of the type
        /// specified by a generic type parameter.
        /// </summary>
        /// <typeparam name="T">The target type of the JSON value.</typeparam>
        /// <param name="s">The JSON text to parse.</param>
        /// <returns>A T representation of the JSON value.</returns>
        public static T Deserialize<T>(this string s)
        {
            var obj = JsonConvert.DeserializeObject<T>(s);
            return obj;
        }

        /// <summary>
        /// Removes all url invalid chars associated with the specified string value.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Slugify(this string s)
        {
            string str = s.ToLowerIf();
            str = Regex.Replace(str, @"[^a-z0-9\s-]", ""); // Remove all non valid chars          
            str = Regex.Replace(str, @"\s+", " ").TrimIf(); // convert multiple spaces into one space  
            str = Regex.Replace(str, @"\s", "-"); // //Replace spaces by dashes
            return str;
        }
    }
}
