using Masking.Attributes;

namespace Sample.Models
{
    [Mask]
    public class People
    {
        public People() { }

        public Person_Masked Masked { get; set; }

        public Person_NotMasked NotMasked { get; set; }

    }
}
