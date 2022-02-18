namespace PhoneNumberValidator.Helpers
{
    public interface IPhoneNumberParser
    {
        public string Clean(string prefix, string code, string phone);
        public bool IsValidPhone(string phone);
        public string Format(string prefix, string phone);
    }
}