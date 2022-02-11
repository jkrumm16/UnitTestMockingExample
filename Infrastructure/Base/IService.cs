namespace Infrastructure.Base
{
    public interface IService
    {
        void Register(IExtensionService ext);

        int Execute(IServiceOperation operation);

        T GetExtension<T>();
    }
}