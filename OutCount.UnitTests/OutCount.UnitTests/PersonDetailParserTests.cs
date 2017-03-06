using System;
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
        public PersonDetail Parse(string data)
        {
            throw new NotImplementedException();
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
