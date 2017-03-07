using System;
using OutCount.DataObjects;

namespace OutCount.Parsers
{
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
}