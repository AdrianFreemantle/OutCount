using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutCount.FileProcessing;
using Shouldly;

namespace OutCount.UnitTests.FileProcessingTests
{
    [TestClass]
    public class CsvFileTests
    {
        private const string FileName = "test.csv";

        [TestInitialize]
        public void Initialize()
        {
            if (File.Exists(FileName))
                File.Delete(FileName);
        }

        [TestMethod]
        public void Csv_file_can_be_created_opened_and_parsed()
        {
            try
            {
                var writeCsvFile = new CsvFile
                {
                    "Jimmy,Smith,102 Long Lane,29384857",
                    "Clive,Owen,65 Ambling Way,31214788"
                };

                writeCsvFile.SaveFile(FileName);

                CsvFile readCsvFile = CsvFile.OpenFile(FileName, includeFirstRow: true);

                readCsvFile[0][0].ShouldBe("Jimmy"); //value at row 1 column 1
                readCsvFile[1][0].ShouldBe("Clive"); //value at row 2 column 1

                readCsvFile[0][3].ShouldBe("29384857"); //value at row 1 column 4
                readCsvFile[1][3].ShouldBe("31214788"); //value at row 2 column 4
            }
            finally
            {
                if (File.Exists(FileName))
                    File.Delete(FileName);
            }
        }
    }
}