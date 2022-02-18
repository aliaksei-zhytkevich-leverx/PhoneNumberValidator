namespace PhoneNumberValidator.Helpers
{
    public class PhonesNumberParsersManager
    {
        private readonly string _regionPrefix;
        private readonly IPhoneNumberParser _parser;

        private static Dictionary<string, IPhoneNumberParser> _parsers = new();

        static PhonesNumberParsersManager()
        {
            //register parsers
            _parsers.Add(PrefixConstants.SwitzPrefix, new SwitzNumberParser());
        }

        public PhonesNumberParsersManager(string regionPrefix)
        {
            _regionPrefix = regionPrefix;
            if (_parsers.ContainsKey(regionPrefix))
            {
                _parser = _parsers[regionPrefix];
            }
            else
            {
                throw new NotImplementedException("Prefix not supported");
            }
        }

        public string Parse(string regionCode, string phone)
        {
            phone = _parser.Clean(_regionPrefix, regionCode, phone);
            if (_parser.IsValidPhone(phone))
            {
                return _parser.Format(_regionPrefix, phone);
            }
            else
            {
                throw new ArgumentException("Invalid phone number");
            }
        }
    }
}