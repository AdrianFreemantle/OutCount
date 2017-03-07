using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OutCount.FileProcessing
{
    public class CsvFile : List<CsvFileRow>
    {
        public CsvFile()
        {
        }

        public static CsvFile OpenFile(string filePath, bool includeFirstRow = false)
        {
            Console.WriteLine("Reading file {0}", filePath);
            return new CsvFile(filePath, includeFirstRow);
        }

        protected CsvFile(string filePath, bool includeFirstRow)
        {
            using (StreamReader file = File.OpenText(filePath))
            {
                ReadRowsFromFile(includeFirstRow, file);
            }
        }        

        private void ReadRowsFromFile(bool includeFirstRow, StreamReader file)
        {
            int lineCount = 0;

            while (!file.EndOfStream)
            {
                string row = file.ReadLine();

                if (!includeFirstRow && lineCount++ == 0)
                    continue;
                
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

            Console.WriteLine("\nSaving file {0} with data:", fileName);
            Console.WriteLine(rows);
            
            File.WriteAllText(fileName, rows.ToString());                        
        }
    }
}