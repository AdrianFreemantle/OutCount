using System.Collections.Generic;
using OutCount.DataObjects;

namespace OutCount.UnitTests.TestStubs
{
    public class AddressSorterStub : IAddressSorter
    {
        private ICollection<Address> returnValue;

        public void SetValueToReturn(ICollection<Address> returnValue)
        {
            this.returnValue = returnValue;
        }

        public ICollection<Address> Sort(ICollection<PersonDetail> personDetails)
        {
            return returnValue;
        }
    }
}