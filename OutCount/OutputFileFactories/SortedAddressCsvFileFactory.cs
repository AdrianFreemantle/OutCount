using System.Collections.Generic;
using OutCount.DataObjects;
using OutCount.FileProcessing;

namespace OutCount.OutputFileFactories
{
    public class SortedAddressCsvFileFactory
    {
        private readonly IAddressSorter addressSorter;

        public SortedAddressCsvFileFactory(IAddressSorter addressSorter)
        {
            this.addressSorter = addressSorter;
        }

        public void SaveToFile(string fileName, ICollection<PersonDetail> details)
        {
            CsvFile sortedAddressesFile = new CsvFile();

            foreach (Address address in addressSorter.Sort(details))
            {
                sortedAddressesFile.Add(CsvFileRow.FromValues(address.ToString()));
            }

            sortedAddressesFile.SaveFile(fileName);
        }
    }
}