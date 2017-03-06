using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutCount.UnitTests.Sut;
using OutCount.UnitTests.TestStubs;
using Shouldly;

namespace OutCount.UnitTests
{
    [TestClass]
    public class PersonDetailParserTests
    {
        const string DataLine = "Jimmy,Smith,102 Long Lane,29384857";

        private static AddressParserStub addressParser;
        private static PersonDetailParser parser;

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
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
}
