using System.Collections.Generic;
using OutCount.DataObjects;
using OutCount.FileProcessing;

namespace OutCount.OutputFileFactories
{
    public class SortedNamesCsvFileFactory
    {
        private readonly INameFrequencySorter nameFrequencySorter;

        public SortedNamesCsvFileFactory(INameFrequencySorter nameFrequencySorter)
        {
            this.nameFrequencySorter = nameFrequencySorter;
        }

        public void SaveToFile(string fileName, ICollection<PersonDetail> details)
        {
            CsvFile sortedNamesFile = new CsvFile();

            foreach (NameFrequencyDto nameFrequencyDto in nameFrequencySorter.Sort(details))
            {
                string name = nameFrequencyDto.Name;
                string count = nameFrequencyDto.Count.ToString();

                sortedNamesFile.Add(CsvFileRow.FromValues(name, count));
            }

            sortedNamesFile.SaveFile(fileName);
        }
    }
}