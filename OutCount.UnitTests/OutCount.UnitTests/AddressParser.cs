using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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

    public class AddressParser : IAddressParser
    {
        public Address Parse(string rawAddress)
        {
            var firstSpaceCharacterIndex = rawAddress.IndexOf(" ", StringComparison.Ordinal);
            var number = rawAddress.Substring(0, firstSpaceCharacterIndex + 1);
            var street = rawAddress.Substring(firstSpaceCharacterIndex + 1, rawAddress.Length - firstSpaceCharacterIndex - 1);

            var streetNumber = Int32.Parse(number);

            return new Address(streetNumber, street);
        }
    }

    public struct Address
    {
        public int Number { get; private set; }
        public string StreetName { get; private set; }

        public Address(int number, string streetName) : this()
        {
            Number = number;
            StreetName = streetName ?? String.Empty;
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", Number, StreetName);
        }
    }
}