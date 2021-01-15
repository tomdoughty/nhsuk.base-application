using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace nhsuk.base_application.ViewModels
{
    public sealed class AddressViewModel : IValidatableObject
    {
        readonly Regex postcodeRegex = new Regex(@"^([a-zA-Z]{1,2}\d[a-zA-Z\d]? ?\d[a-zA-Z]{2}|GIR ?0A{2})$");
        private string _postcode = string.Empty;

        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Postcode
        {
            get => _postcode;
            set => _postcode = value != null ? value.Trim() : string.Empty;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Line1))
            {
                yield return new ValidationResult("Your address must include a building and street", new[] { "Line1" });
            }

            if (string.IsNullOrWhiteSpace(Town))
            {
                yield return new ValidationResult("Your address must include a town or city", new[] { "Town" });
            }

            if (string.IsNullOrWhiteSpace(Postcode))
            {
                yield return new ValidationResult("Your address must include a postcode", new[] { "Postcode" });
            }
            else if (!postcodeRegex.IsMatch(Postcode))
            {
                yield return new ValidationResult("Please enter a valid postcode", new[] { "Postcode" });
            }
        }
    }
}
