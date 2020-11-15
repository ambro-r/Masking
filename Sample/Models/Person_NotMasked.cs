using Newtonsoft.Json;

namespace Sample.Models
{
    public class Person_NotMasked
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Surname")]
        public string Surname { get; set; }

        [JsonProperty("ContactNumber")]        
        public string ContactNumber { get; set; }

        [JsonProperty("Email")]        
        public string Email { get; set; }
        
        public string Address { get; set; }

        public string IdentityNumber { get; set; }
    }
}
