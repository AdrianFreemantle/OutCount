using System.Collections.Generic;
using System.Linq;
using OutCount.DataObjects;

namespace OutCount.DataSorters
{
    public class AddressSorter : IAddressSorter
    {
        public ICollection<Address> Sort(ICollection<PersonDetail> personDetails)
        {
            return personDetails
                .OrderBy(g => g.Address.StreetName)  
                .Select(g => g.Address)              
                .ToArray();
        }
    }
}