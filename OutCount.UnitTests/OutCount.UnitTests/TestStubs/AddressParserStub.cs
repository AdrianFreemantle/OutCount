using OutCount.UnitTests.Sut;

namespace OutCount.UnitTests.TestStubs
{
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
}