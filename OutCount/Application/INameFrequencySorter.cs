using System.Collections.Generic;

namespace OutCount.Sut
{
    public interface INameFrequencySorter
    {
        ICollection<NameFrequencyDto> Sort(ICollection<PersonDetail> personDetails);
    }
}