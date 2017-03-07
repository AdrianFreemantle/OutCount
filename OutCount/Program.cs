using System.Collections.Generic;
using OutCount.Sut;

namespace OutCount
{
    class Program
    {
        private static PersonDetailsFileParser personDetailsFileParser;
        private static SortedAddressCsvFileFactory sortedAddressCsvFileFactory;
        private static SortedNamesCsvFileFactory sortedNamesCsvFileFactory;

        static void Main(string[] args)
        {
            Initialize();
            Logo.Print();

            var results = personDetailsFileParser.ParseFile(@".\Data\data.csv");
            sortedNamesCsvFileFactory.SaveToFile("SortedNames.csv", results);
            sortedAddressCsvFileFactory.SaveToFile("SortedAddresses.csv", results);
        }

        private static void Initialize()
        {
            sortedAddressCsvFileFactory = new SortedAddressCsvFileFactory(new AddressSorter());
            sortedNamesCsvFileFactory = new SortedNamesCsvFileFactory(new NameFrequencySorter());
            personDetailsFileParser = new PersonDetailsFileParser(new PersonDetailParser(new AddressParser()));
        }
    }
}
