using System.ComponentModel.DataAnnotations;

namespace PhoneNumberValidator.Dtos
{
    public class ValidateRequestDto
    {
        [Required(ErrorMessage = "Phone number cannot be null.")]
        public string PhoneNumber { get; set; } = string.Empty;

        private string _prefix;
        public string Prefix
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_prefix))
                {
                    _prefix = PrefixConstants.SwitzPrefix;
                }
                return _prefix;
            }
            set => _prefix = value;
        }

        public string RegionCode { get; set; }
    }
}
