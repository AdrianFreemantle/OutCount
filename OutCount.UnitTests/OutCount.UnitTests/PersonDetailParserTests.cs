using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace OutCount.UnitTests
{
    [TestClass]
    public class PersonDetailParserTests
    {
        const string DataLine = "Jimmy,Smith,102 Long Lane,29384857";

        private readonly AddressParserStub addressParser;
        private readonly PersonDetailParser parser;

        public PersonDetailParserTests()
        {
            addressParser = new AddressParserStub();
            parser = new PersonDetailParser(addressParser);
        }

        [TestMethod]
        public void Person_details_can_be_parsed_from_a_data_line()
        {
            addressParser.SetAddressToReturn(new Address(102, "Long Lane"));
            var personDetail = parser.Parse(DataLine);

            personDetail.FirstName.ShouldBe("Jimmy");
            personDetail.LastName.ShouldBe("Smith");
            personDetail.Address.ToString().ShouldBe("102 Long Lane");
            personDetail.PhoneNumber.ShouldBe("29384857");
        }
    }

    public interface IAddressParser
    {
        Address Parse(string rawAddress);
    }

    public class AddressParserStub : IAddressParser
    {
        private Address addressToReturn;

        public void SetAddressToReturn(Address address)
        {
            addressToReturn = address;
        }

        public Address Parse(string rawAddress)
        {
            return addressToReturn;
        }
    }

    public class PersonDetailParser
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

    public struct PersonDetail
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNumber { get; private set; }
        public Address Address { get; private set; }

        public PersonDetail(string firstName, string lastName, string phoneNumber, Address address)
            : this()
        {
            FirstName = firstName ?? String.Empty;
            LastName = lastName ?? String.Empty;
            PhoneNumber = phoneNumber ?? String.Empty;
            Address = address;
        }
    }
}
