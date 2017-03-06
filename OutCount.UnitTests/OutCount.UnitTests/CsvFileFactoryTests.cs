using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace OutCount.UnitTests
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
        public void Csv_file_can_be_opened_and_parsed()
        {
            try
            {
                StringBuilder rows = new StringBuilder();
                rows.AppendLine("Jimmy,Smith,102 Long Lane,29384857");
                rows.AppendLine("Clive,Owen,65 Ambling Way,31214788");

                File.WriteAllText(FileName, rows.ToString());

                CsvFile csvFile = CsvFile.OpenFile(FileName, includeFirstRow: true);

                csvFile[0][0].ShouldBe("Jimmy"); //value at row 1 column 1
                csvFile[1][0].ShouldBe("Clive"); //value at row 2 column 1

                csvFile[0][3].ShouldBe("29384857"); //value at row 1 column 4
                csvFile[1][3].ShouldBe("31214788"); //value at row 2 column 4
            }
            finally
            {
                if (File.Exists(FileName))
                    File.Delete(FileName);
            }
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

    public class CsvFile : List<CsvFileRow>
    {
        public CsvFile()
        {
        }

        protected CsvFile(string filePath, bool includeFirstRow)
        {
            using (StreamReader file = File.OpenText(filePath))
            {
                ReadRowsFromFile(includeFirstRow, file);
            }
        }

        public static CsvFile OpenFile(string filePath, bool includeFirstRow = false)
        {
            return new CsvFile(filePath, includeFirstRow);
        }

        private void ReadRowsFromFile(bool includeFirstRow, StreamReader file)
        {
            int lineCount = 0;

            while (!file.EndOfStream)
            {
                if (includeFirstRow && lineCount++ == 0)
                    continue;

                string row = file.ReadLine();
                Add(new CsvFileRow(row));
            }
        }

        public void Add(string row)
        {
            Add(new CsvFileRow(row));
        }

        public void SaveFile(string fileName)
        {
            StringBuilder rows = new StringBuilder();

            foreach (CsvFileRow row in this)
            {
                rows.AppendLine(row.ToString());
            }

            File.WriteAllText(fileName, rows.ToString());
        }
    }

    public class CsvFileRow : Dictionary<int, string>
    {
        public CsvFileRow(string row)
        {
            int index = 0;

            foreach (var columnValue in row.Split(','))
            {
                Add(index++, columnValue);
            }
        }

        public override string ToString()
        {
            return String.Join(",", Values);
        }
    }
}