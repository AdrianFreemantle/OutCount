using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutCount.FileProcessing;
using OutCount.OutputFileFactories;
using OutCount.UnitTests.TestStubs;
using Shouldly;

namespace OutCount.UnitTests.FileFactoryTests
{
    [TestClass]
    public class SortedAddressCsvFileFactoryTests
    {
        private const string FileName = "SortedAddressTest.csv";

        private AddressSorterStub addressSorterStub;
        private SortedAddressCsvFileFactory sortedAddressCsvFileFactory;

        [TestInitialize]
        public void Intialize()
        {
            addressSorterStub = new AddressSorterStub();
            sortedAddressCsvFileFactory = new SortedAddressCsvFileFactory(addressSorterStub);

            if (File.Exists(FileName))
                File.Delete(FileName);
        }

        [TestMethod]
        public void A_sorted_csv_file_can_be_created()
        {
            try
            {
                addressSorterStub.SetValueToReturn(TestData.Addresses);

                sortedAddressCsvFileFactory.SaveToFile(FileName, TestData.PersonDetials);

                CsvFile readCsvFile = CsvFile.OpenFile(FileName, includeFirstRow: true);

                readCsvFile[0][0].ShouldBe("32 Peter Road"); //value at row 1 column 1
                readCsvFile[1][0].ShouldBe("99 Jones Road"); //value at row 2 column 1
            }
            finally
            {
                if (File.Exists(FileName))
                    File.Delete(FileName);
            }
        }
    }
}