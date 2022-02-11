namespace Infrastructure.Base
{
    public abstract class ExtensionsServiceBase : IExtensionService
    {
        private IService _owner;
        public IService Owner
        {
            get => _owner;
            set => _owner = value;
        }
    }
}