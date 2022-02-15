namespace AddressRepoLib
{
    public interface IAddressParser
    {
        Address Parse(string addressSerialized);
    }
}
