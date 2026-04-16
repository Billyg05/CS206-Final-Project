using System.Globalization;
using System.Text.RegularExpressions;

namespace HairSalonManagementApp
{
    internal static class Validator
    {
        // Collapse repeated spaces so text stays clean
        public static string NormalizeSpaces(string value)
        {
            return Regex.Replace(value.Trim(), @"\s+", " ");
        }

        // Validate customer name
        public static bool TryGetCustomerName(string input, out string customerName, out string errorMessage)
        {
            customerName = NormalizeSpaces(input);
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(customerName))
            {
                errorMessage = "Enter the customer name.";
                return false;
            }

            if (customerName.Length > 50)
            {
                errorMessage = "Customer name must be 50 characters or less.";
                return false;
            }

            if (!Regex.IsMatch(customerName, @"^[A-Za-z][A-Za-z .'\-]{1,49}$"))
            {
                errorMessage = "Customer name can only use letters, spaces, periods, apostrophes, and hyphens.";
                return false;
            }

            return true;
        }

        // Validate employee name
        public static bool TryGetEmployeeName(string input, out string employeeName, out string errorMessage)
        {
            employeeName = NormalizeSpaces(input);
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(employeeName))
            {
                errorMessage = "Enter the employee name.";
                return false;
            }

            if (employeeName.Length > 50)
            {
                errorMessage = "Employee name must be 50 characters or less.";
                return false;
            }

            if (!Regex.IsMatch(employeeName, @"^[A-Za-z][A-Za-z .'\-]{1,49}$"))
            {
                errorMessage = "Employee name can only use letters, spaces, periods, apostrophes, and hyphens.";
                return false;
            }

            return true;
        }

        // Validate a service name (old)
        public static bool TryGetServiceName(string input, out string serviceName, out string errorMessage)
        {
            serviceName = NormalizeSpaces(input);
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(serviceName))
            {
                errorMessage = "Enter the service name.";
                return false;
            }

            if (serviceName.Length > 50)
            {
                errorMessage = "Service name must be 50 characters or less.";
                return false;
            }

            if (!Regex.IsMatch(serviceName, @"^[A-Za-z0-9][A-Za-z0-9 &'\/\.\-]{1,49}$"))
            {
                errorMessage = "Service name can only use letters, numbers, spaces, apostrophes, slashes, periods, ampersands, and hyphens.";
                return false;
            }

            return true;
        }

        // Validate the username rules
        public static bool TryGetUsername(string input, out string username, out string errorMessage)
        {
            username = input.Trim().ToLowerInvariant();
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(username))
            {
                errorMessage = "Enter a username.";
                return false;
            }

            if (username.Length < 4 || username.Length > 20)
            {
                errorMessage = "Username must be between 4 and 20 characters.";
                return false;
            }

            if (!Regex.IsMatch(username, @"^[a-z0-9_]+$"))
            {
                errorMessage = "Username can only use lowercase letters, numbers, and underscores.";
                return false;
            }

            return true;
        }

        // Validate password rules
        public static bool TryGetPassword(string input, out string password, out string errorMessage)
        {
            password = input;
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(password))
            {
                errorMessage = "Enter a password.";
                return false;
            }

            if (password.Length < 8 || password.Length > 30)
            {
                errorMessage = "Password must be between 8 and 30 characters.";
                return false;
            }

            if (!password.Any(char.IsUpper))
            {
                errorMessage = "Password must include at least one uppercase letter.";
                return false;
            }

            if (!password.Any(char.IsLower))
            {
                errorMessage = "Password must include at least one lowercase letter.";
                return false;
            }

            if (!password.Any(char.IsDigit))
            {
                errorMessage = "Password must include at least one number.";
                return false;
            }

            if (password.Contains(' '))
            {
                errorMessage = "Password cannot contain spaces.";
                return false;
            }

            return true;
        }

        //phone formatting to digits, then rebuild
        public static bool TryGetPhoneNumber(string input, out string phoneNumber, out string errorMessage)
        {
            string digitsOnly = new string(input.Where(char.IsDigit).ToArray());
            errorMessage = string.Empty;
            phoneNumber = string.Empty;

            if (digitsOnly.Length != 10)
            {
                errorMessage = "Enter a 10-digit phone number.";
                return false;
            }

            phoneNumber = string.Format(CultureInfo.InvariantCulture, "({0}) {1}-{2}",
                digitsOnly[..3], digitsOnly.Substring(3, 3), digitsOnly.Substring(6, 4));

            return true;
        }

        // Validate email address if text
        public static bool TryGetEmail(string input, out string emailAddress, out string errorMessage)
        {
            emailAddress = NormalizeSpaces(input).ToLowerInvariant();
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(emailAddress))
            {
                emailAddress = string.Empty;
                return true;
            }

            if (emailAddress.Length > 80)
            {
                errorMessage = "Email address must be 80 characters or less.";
                return false;
            }

            if (!Regex.IsMatch(emailAddress, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                errorMessage = "Enter a valid email address or leave it blank.";
                return false;
            }

            return true;
        }

        // notes rules
        public static bool TryGetNotes(string input, out string notes, out string errorMessage)
        {
            notes = input.Replace('\t', ' ').Trim();
            errorMessage = string.Empty;

            if (notes.Length > 200)
            {
                errorMessage = "Notes must be 200 characters or less.";
                return false;
            }

            return true;
        }

        // validate prices are reasonable
        public static bool TryGetPrice(decimal input, out decimal price, out string errorMessage)
        {
            price = input;
            errorMessage = string.Empty;

            if (price <= 0)
            {
                errorMessage = "Price must be greater than 0.";
                return false;
            }

            if (price > 500)
            {
                errorMessage = "Price must be 500.00 or less.";
                return false;
            }

            price = decimal.Round(price, 2);
            return true;
        }

        //old
        public static bool TryGetOptionalText(string input, string fieldName, int maxLength, out string value, out string errorMessage)
        {
            value = NormalizeSpaces(input);
            errorMessage = string.Empty;

            if (value.Length > maxLength)
            {
                errorMessage = fieldName + " must be " + maxLength + " characters or less.";
                return false;
            }

            return true;
        }

        // Standard popup
        public static void ShowValidationError(string errorMessage, Control control)
        {
            MessageBox.Show(errorMessage, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();

            if (control is TextBoxBase textBoxBase)
            {
                textBoxBase.SelectAll();
            }
        }

        // error popup when saving/loading data fails.
        public static void ShowDataError(string errorMessage)
        {
            MessageBox.Show(errorMessage, "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
