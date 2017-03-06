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
        PersonDetailParser parser = new PersonDetailParser();

        [TestMethod]
        public void TestMethod1()
        {
            var personDetail = parser.Parse(DataLine);

            personDetail.FirstName.ShouldBe("Jimmy");
            personDetail.LastName.ShouldBe("Smith");
            personDetail.Address.ShouldBe("102 Long Lane");
            personDetail.PhoneNumber.ShouldBe("29384857");
        }
    }

    public class PersonDetailParser
    {
        const int FirstNameIndex = 0;
        const int LastNameIndex = 1;
        const int AddressIndex = 2;
        const int PhoneNumberIndex = 3;

        public PersonDetail Parse(string data)
        {
            var values = data.Split(',').ToArray();

            return new PersonDetail(values[FirstNameIndex], values[LastNameIndex], values[PhoneNumberIndex], values[AddressIndex]);
        }
    }

    public struct PersonDetail
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Address { get; private set; }

        public PersonDetail(string firstName, string lastName, string phoneNumber, string address)
            : this()
        {
            FirstName = firstName ?? String.Empty;
            LastName = lastName ?? String.Empty;
            PhoneNumber = phoneNumber ?? String.Empty;
            Address = address ?? String.Empty;
        }
    }
}
