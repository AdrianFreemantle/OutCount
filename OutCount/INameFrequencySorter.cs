using System.Collections.Generic;
using OutCount.DataObjects;

namespace OutCount
{
    public interface INameFrequencySorter
    {
        ICollection<NameFrequencyDto> Sort(ICollection<PersonDetail> personDetails);
    }
}