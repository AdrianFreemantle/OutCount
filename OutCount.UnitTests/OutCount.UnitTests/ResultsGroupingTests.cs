using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutCount.UnitTests.Sut;
using Shouldly;

namespace OutCount.UnitTests
{
    [TestClass]
    public class ResultsGroupingTests
    {
        private static PersonDetail[] testData;
        private static NameFrequencySorter nameFrequencySorter;
        private static AddressSorter addressSorter;

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            nameFrequencySorter = new NameFrequencySorter();
            addressSorter = new AddressSorter();

            testData = new[]
            {
                new PersonDetail("Matt", "Brown", "0845140900", new Address(22, "Jones Rd")),
                new PersonDetail("Heinrich", "Jones", "0845140901", new Address(12, "Acton St")),
                new PersonDetail("Johnson", "Smith", "0845140902", new Address(31, "Clifton Rd")),
                new PersonDetail("Tim", "Johnson", "0845140903", new Address(9, "Wilkinson Rd")),
            };
        }

        [TestMethod]
        public void Results_can_be_grouped_by_name_frequency()
        {
            var namesCount = nameFrequencySorter.Sort(testData).ToArray();

            namesCount[0].Name.ShouldBe("Johnson");
            namesCount[0].Count.ShouldBe(2);

            namesCount[1].Name.ShouldBe("Brown");
            namesCount[1].Count.ShouldBe(1);

            namesCount[2].Name.ShouldBe("Heinrich");
            namesCount[2].Count.ShouldBe(1);

            namesCount[3].Name.ShouldBe("Jones");
            namesCount[3].Count.ShouldBe(1);

            namesCount[4].Name.ShouldBe("Matt");
            namesCount[4].Count.ShouldBe(1);

            namesCount[5].Name.ShouldBe("Smith");
            namesCount[5].Count.ShouldBe(1);

            namesCount[6].Name.ShouldBe("Tim");
            namesCount[6].Count.ShouldBe(1);
        }

        [TestMethod]
        public void Results_can_be_grouped_by_address_frequency()
        {
            Address[] streets = addressSorter.Sort(testData).ToArray();

            streets[0].ToString().ShouldBe("12 Acton St");
            streets[1].ToString().ShouldBe("31 Clifton Rd");
            streets[2].ToString().ShouldBe("22 Jones Rd");
            streets[3].ToString().ShouldBe("9 Wilkinson Rd");
        }
    }
}