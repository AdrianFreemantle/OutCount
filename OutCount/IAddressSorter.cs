using System.Collections.Generic;
using OutCount.DataObjects;

namespace OutCount
{
    public interface IAddressSorter
    {
        ICollection<Address> Sort(ICollection<PersonDetail> personDetails);
    }
}