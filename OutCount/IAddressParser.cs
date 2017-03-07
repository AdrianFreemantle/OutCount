using OutCount.DataObjects;

namespace OutCount
{
    public interface IAddressParser
    {
        Address Parse(string rawAddress);
    }
}