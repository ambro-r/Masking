using Masking.Attributes;
using Newtonsoft.Json;

namespace Sample.Models
{
    [Mask]
    public class Person_Masked
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Surname")]
        public string Surname { get; set; }

        [JsonProperty("ContactNumber")]
        [Mask(MaskingMethod.Mask, @"(?<=.{3}).+(?=.{3})")]
        public string ContactNumber { get; set; }

        [JsonProperty("Email")]
        [Mask(MaskingMethod.Mask, @"(?<=.{1}).+(?<=@)")]
        public string Email { get; set; }
        
        [Mask(MaskingMethod.Trim, @"(?<=.{6}).+(?=.{6})")]
        public string Address { get; set; }
        
        [Mask(MaskingMethod.Replace, @"REPLACED")]
        public string IdentityNumber { get; set; }
    }

}
