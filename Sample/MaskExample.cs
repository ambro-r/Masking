using Masking.Types;
using Newtonsoft.Json;
using Sample.Models;
using System;

namespace Sample
{
    public class MaskExample
    {

        private Person_Masked MaskedPerson;
        private Person_NotMasked NotMaskedPerson;
        private People people;

        public MaskExample() {
            MaskedPerson = new Person_Masked()
            {
                Name = "John",
                Surname = "Smith",
                ContactNumber = "0821234567",
                Email = "john.smith@testdomain.com",
                Address = "59 Hornbill Avenue, South Crater, Mars, 000345",
                IdentityNumber = "7894561230"
            };

            NotMaskedPerson = new Person_NotMasked()
            {
                Name = "Sally",
                Surname = "Sheers",
                ContactNumber = "0719876541",
                Email = "sally.sheers@testdomain.com",
                Address = "59 Hornbill Avenue, South Crater, Mars, 000345",
                IdentityNumber = "0123456789"
            };

            people = new People()
            {
                Masked = MaskedPerson,
                NotMasked = NotMaskedPerson,
            };
        }

        public void RunSimpleExample()
        {
            Console.WriteLine("\nSerialize an object that is not \"masked\":\n");
            Console.WriteLine(string.Format("Direct Serializing: {0}", JsonConvert.SerializeObject(NotMaskedPerson)));
            Console.WriteLine(string.Format("Applying the Mask : {0}", new MaskedType<Person_NotMasked>(NotMaskedPerson).Serialize()));

            Console.WriteLine("\nSerialize an object that is \"masked\":\n"); ;
            Console.WriteLine(string.Format("Direct Serializing: {0}", JsonConvert.SerializeObject(MaskedPerson)));
            Console.WriteLine(string.Format("Applying the Mask : {0}", new MaskedType<Person_Masked>(MaskedPerson).Serialize()));

            Console.WriteLine("\nSerialize an object that contains \"masked\" objects:\n"); ;
            Console.WriteLine(string.Format("Direct Serializing: {0}", JsonConvert.SerializeObject(people)));
            Console.WriteLine(string.Format("Applying the Mask : {0}", new MaskedType<People>(people).Serialize()));
        }

    }
}
