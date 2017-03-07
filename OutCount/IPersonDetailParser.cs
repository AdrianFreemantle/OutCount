using OutCount.DataObjects;

namespace OutCount
{
    public interface IPersonDetailParser
    {
        PersonDetail Parse(string data);
    }
}