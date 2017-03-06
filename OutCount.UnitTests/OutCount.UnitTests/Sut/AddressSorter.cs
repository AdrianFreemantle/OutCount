using System.Collections.Generic;
using System.Linq;

namespace OutCount.UnitTests.Sut
{
    public class AddressSorter
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