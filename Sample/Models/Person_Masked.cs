using Masking.Attributes;

namespace Sample.Models
{
    [Mask]
    public class Person_Masked
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        [Mask(MaskingMethod.Mask, @"(?<=.{3}).+(?=.{3})")]
        public string ContactNumber { get; set; }

        [Mask(MaskingMethod.Mask, @"(?<=.{1}).+(?<=@)")]
        public string Email { get; set; }

        [Mask(MaskingMethod.Trim, @"(?<=.{6}).+(?=.{6})")]
        public string Address { get; set; }

        [Mask(MaskingMethod.Replace, @"REPLACED")]
        public string IdentityNumber { get; set; }
    }

}
