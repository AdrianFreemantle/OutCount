using System;

namespace OutCount.UnitTests.Sut
{
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