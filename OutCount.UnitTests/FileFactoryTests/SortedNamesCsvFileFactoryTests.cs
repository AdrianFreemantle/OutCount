using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutCount.FileProcessing;
using OutCount.OutputFileFactories;
using OutCount.UnitTests.TestStubs;
using Shouldly;

namespace OutCount.UnitTests.FileFactoryTests
{
    [TestClass]
    public class SortedNamesCsvFileFactoryTests
    {
        private const string FileName = "SortedNamesTest.csv";

        private NameFrequencySorterStub nameFrequencySorterStub;
        private SortedNamesCsvFileFactory sortedNamesCsvFileFactory;

        [TestInitialize]
        public void Intialize()
        {
            nameFrequencySorterStub  = new NameFrequencySorterStub();
            sortedNamesCsvFileFactory = new SortedNamesCsvFileFactory(nameFrequencySorterStub);

            if (File.Exists(FileName))
                File.Delete(FileName);
        }

        [TestMethod]
        public void A_sorted_csv_file_can_be_created()
        {
            try
            {
                nameFrequencySorterStub.SetValueToReturn(TestData.NameFrequecies);
                
                sortedNamesCsvFileFactory.SaveToFile(FileName, TestData.PersonDetials); 

                CsvFile readCsvFile = CsvFile.OpenFile(FileName, includeFirstRow: true);

                readCsvFile[0][0].ShouldBe("Adrian"); //value at row 1 column 1
                readCsvFile[1][0].ShouldBe("Freemantle"); //value at row 2 column 1

                readCsvFile[0][1].ShouldBe("2"); //value at row 1 column 2
                readCsvFile[1][1].ShouldBe("1"); //value at row 2 column 2
            }
            finally
            {
                if (File.Exists(FileName))
                    File.Delete(FileName);
            }
        }
    }
}