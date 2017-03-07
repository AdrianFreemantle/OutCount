using System.Collections.Generic;
using OutCount.DataObjects;

namespace OutCount.UnitTests.TestStubs
{
    public class NameFrequencySorterStub : INameFrequencySorter
    {
        private ICollection<NameFrequencyDto> returnValue;

        public void SetValueToReturn(ICollection<NameFrequencyDto> returnValue)
        {
            this.returnValue = returnValue;
        }

        public ICollection<NameFrequencyDto> Sort(ICollection<PersonDetail> personDetails)
        {
            return returnValue;
        }
    }
}