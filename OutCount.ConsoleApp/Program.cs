using System;
using OutCount.DataSorters;
using OutCount.OutputFileFactories;
using OutCount.Parsers;

namespace OutCount.ConsoleApp
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

            Console.WriteLine("\nCompleted. Press any key to exit.");
            Console.ReadKey();
        }

        private static void Initialize()
        {
            sortedAddressCsvFileFactory = new SortedAddressCsvFileFactory(new AddressSorter());
            sortedNamesCsvFileFactory = new SortedNamesCsvFileFactory(new NameFrequencySorter());
            personDetailsFileParser = new PersonDetailsFileParser(new PersonDetailParser(new AddressParser()));
        }
    }
}
