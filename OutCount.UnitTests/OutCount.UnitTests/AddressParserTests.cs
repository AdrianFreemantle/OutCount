using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutCount.UnitTests.Sut;
using Shouldly;

namespace OutCount.UnitTests
{
    [TestClass]
    public class AddressParserTests
    {
        const string AddressText = "102 Long Lane";
        private readonly AddressParser addressParser = new AddressParser();

        [TestMethod]
        public void Address_can_be_parsed_from_text_data()
        {
            var address = addressParser.Parse(AddressText);

            address.Number.ShouldBe(102);
            address.StreetName.ShouldBe("Long Lane");
            address.ToString().ShouldBe("102 Long Lane");
        }
    }
}