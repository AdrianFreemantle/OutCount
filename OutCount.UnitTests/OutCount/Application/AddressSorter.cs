using System.Collections.Generic;
using System.Linq;

namespace OutCount.Sut
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