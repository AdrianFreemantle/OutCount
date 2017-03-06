using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutCount.UnitTests.Sut;
using Shouldly;

namespace OutCount.UnitTests
{
    [TestClass]
    public class ResultsGroupingTests
    {
        private PersonDetail[] testData;

        [TestMethod]
        public void GroupingTest()
        {
            testData = new[]
            {
                new PersonDetail("Matt", "Brown", "0845140900", new Address(22, "Jones Rd")),
                new PersonDetail("Heinrich", "Jones", "0845140901", new Address(12, "Acton St")),
                new PersonDetail("Johnson", "Smith", "0845140902", new Address(12, "Acton St")),
                new PersonDetail("Tim", "Johnson", "0845140903", new Address(9, "Wilkinson Rd")),
            };

            var names = testData.Select(g => g.FirstName).Concat(testData.Select(g => g.LastName));

            var namesCount = names
                .GroupBy(s => s)
                .Select(g => new
                {
                    Name = g.Key,
                    Count = g.Count(s => s == g.Key)
                }).OrderByDescending(g => g.Count).ThenBy(g => g.Name)
                .ToArray();

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
    }
}