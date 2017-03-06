using System;

namespace OutCount.UnitTests.Sut
{
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