using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace OutCount.UnitTests
{
    [TestClass]
    public class AddressParserTests
    {
        const string AddressText = "102 Long Lane";
        AddressParser addressParser = new AddressParser();


        [TestMethod]
        public void TestMethod1()
        {
            var address = addressParser.Parse(AddressText);

            address.Number.ShouldBe(102);
            address.StreetName.ShouldBe("Long Lane");
            address.ToString().ShouldBe("102 Long Lane");
        }
    }

    public class AddressParser
    {
        public Address Parse(string rawAddress)
        {
            return new Address(0, "");
        }
    }

    public struct Address
    {
        public int Number { get; private set; }
        public string StreetName { get; private set; }

        public Address(int number, string streetName) : this()
        {
            Number = number;
            StreetName = streetName;
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", Number, StreetName);
        }
    }
}