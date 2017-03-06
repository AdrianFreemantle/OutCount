using System;
using System.Collections.Generic;
using System.Linq;

namespace OutCount.Sut
{
    public class CsvFileRow : Dictionary<int, string>
    {
        public static CsvFileRow FromValues(params string[] values)
        {
            var row = String.Join(",", values);
            return new CsvFileRow(row);
        }

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