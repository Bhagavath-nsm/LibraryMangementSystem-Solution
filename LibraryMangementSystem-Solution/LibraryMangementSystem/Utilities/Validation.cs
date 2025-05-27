using System;
using System.Text.RegularExpressions;

namespace LibraryManagementSystem
{
    public static class Validation
    {
        /// <summary>
        /// Validates ISBN (4 to 5 digit number).
        /// </summary>
        public static bool IsValidISBN(string isbn)
        {
            return Regex.IsMatch(isbn, @"^\d{4,5}$");
        }

       
        /// Validates that input contains only letters, numbers, and spaces.
        /// Disallows special characters. Returns false for null or whitespace.
        
        public static bool IsValidText(string input)
        {
            return !string.IsNullOrWhiteSpace(input) &&
                   Regex.IsMatch(input, @"^[A-Za-z0-9\s]+$");
        }

        /// <summary>
        /// Validates that input is a valid past or present date in any recognizable format.
        /// Returns true if valid and not a future date.
        /// </summary>
        public static bool IsValidPastDate(string input, out DateTime result)
        {
            if (DateTime.TryParse(input, out result))
            {
                return result <= DateTime.Today;
            }
            return false;
        }
    }
}
