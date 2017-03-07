using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutCount.DataObjects;
using OutCount.DataSorters;
using Shouldly;

namespace OutCount.UnitTests.SortingTests
{
    [TestClass]
    public class SorterTests
    {
        private static NameFrequencySorter nameFrequencySorter;
        private static AddressSorter addressSorter;

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            nameFrequencySorter = new NameFrequencySorter();
            addressSorter = new AddressSorter();
        }

        [TestMethod]
        public void Results_can_be_grouped_by_name_frequency()
        {
            var namesCount = nameFrequencySorter.Sort(TestData.PersonDetials).ToArray();

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
            Address[] streets = addressSorter.Sort(TestData.PersonDetials).ToArray();

            streets[0].ToString().ShouldBe("12 Acton St");
            streets[1].ToString().ShouldBe("31 Clifton Rd");
            streets[2].ToString().ShouldBe("22 Jones Rd");
            streets[3].ToString().ShouldBe("9 Wilkinson Rd");
        }
    }
}