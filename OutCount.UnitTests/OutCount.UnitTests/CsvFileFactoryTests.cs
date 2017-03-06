using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace OutCount.UnitTests
{
    [TestClass]
    public class CsvFileTests
    {        
        [TestInitialize]
        public void Initialize()
        {
            
        }

        [TestCleanup]
        public void Cleanup()
        {
            
        }

        [TestMethod]
        public void Test()
        {
            string fileName = "test.csv";

            if (File.Exists(fileName))
                File.Delete(fileName);
                      
            try
            {
                StringBuilder rows = new StringBuilder();
                rows.AppendLine("Jimmy,Smith,102 Long Lane,29384857");
                rows.AppendLine("Clive,Owen,65 Ambling Way,31214788");

                File.WriteAllText(fileName, rows.ToString());

                CsvFile csvFile = CsvFile.OpenFile(fileName, includeFirstRow: true);

                csvFile[0][0].ShouldBe("Jimmy"); //value at row 1 column 1
                csvFile[1][0].ShouldBe("Clive"); //value at row 2 column 1

                csvFile[0][3].ShouldBe("29384857"); //value at row 1 column 4
                csvFile[1][3].ShouldBe("31214788"); //value at row 2 column 4
            }
            finally
            {
                if (File.Exists(fileName))
                    File.Delete(fileName);
            }
        }
    }

    public class CsvFile : List<CsvFileRow>
    {
        protected CsvFile(string filePath, bool includeFirstRow)
        {
            using (StreamReader file = File.OpenText(filePath))
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
        }

        public static CsvFile OpenFile(string filePath, bool includeFirstRow = false)
        {
            return new CsvFile(filePath, includeFirstRow);
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
    }
}