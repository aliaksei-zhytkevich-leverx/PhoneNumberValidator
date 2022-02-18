using System.Text.RegularExpressions;

namespace PhoneNumberValidator.Helpers
{
    public class SwitzNumberParser : IPhoneNumberParser
    {
        private const string ClearRegex = "\\(|\\)|\\s+|-|\\/";
        private const string PhoneRegex = @"^(\d{9})?$";

        public string Clean(string prefix, string code, string phone)
        {
            if (!string.IsNullOrEmpty(phone))
            {
                phone = Regex.Replace(phone, ClearRegex, string.Empty);

                if (phone.StartsWith(code))
                {
                    phone = new Regex(Regex.Escape(code)).Replace(phone, string.Empty, 1);
                }

                if (phone.StartsWith(prefix))
                {
                    phone = new Regex(Regex.Escape(prefix)).Replace(phone, string.Empty, 1);
                }
            }

            return phone;
        }

        public bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone) || phone.Length >= 10)
            {
                return false;
            }
            return Regex.IsMatch(phone, PhoneRegex);
        }

        public string Format(string prefix, string phone)
        {
            return $"{prefix}{phone}";
        }
    }
}