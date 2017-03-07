using OutCount.Sut;

namespace OutCount.UnitTests
{
    public static class TestData
    {
        public static readonly PersonDetail[] PersonDetials = 
        {
            new PersonDetail("Matt", "Brown", "0845140900", new Address(22, "Jones Rd")),
            new PersonDetail("Heinrich", "Jones", "0845140901", new Address(12, "Acton St")),
            new PersonDetail("Johnson", "Smith", "0845140902", new Address(31, "Clifton Rd")),
            new PersonDetail("Tim", "Johnson", "0845140903", new Address(9, "Wilkinson Rd")),
        };
    }
}