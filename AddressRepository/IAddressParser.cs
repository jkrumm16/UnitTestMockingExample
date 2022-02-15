namespace MyWebClient
{
    public interface IAddressParser
    {
        Address Parse(string addressSerialized);
    }
}
