namespace AddressRepoLib
{
    public interface IAddressDeserializer
    {
        Address Parse(string addressSerialized);
    }
}
