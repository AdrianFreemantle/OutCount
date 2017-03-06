using System.Collections.Generic;

namespace OutCount.Sut
{
    public interface IAddressSorter
    {
        ICollection<Address> Sort(ICollection<PersonDetail> personDetails);
    }
}