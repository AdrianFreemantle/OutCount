using System.Linq;
using OutCount.DataObjects;

namespace OutCount.Parsers
{
    public class PersonDetailParser : IPersonDetailParser
    {
        const int FirstNameIndex = 0;
        const int LastNameIndex = 1;
        const int AddressIndex = 2;
        const int PhoneNumberIndex = 3;
    
        private readonly IAddressParser addressParser;

        public PersonDetailParser(IAddressParser addressParser)
        {
            this.addressParser = addressParser;
        }

        public PersonDetail Parse(string data)
        {
            var values = data.Split(',').ToArray();

            var firstName = values[FirstNameIndex];
            var lastName = values[LastNameIndex];
            var phoneNumber = values[PhoneNumberIndex];
            var addressData = values[AddressIndex];

            var address = addressParser.Parse(addressData);

            return new PersonDetail(firstName, lastName, phoneNumber, address);
        }
    }
}