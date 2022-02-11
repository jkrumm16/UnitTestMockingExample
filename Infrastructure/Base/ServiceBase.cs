using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Base
{
    public abstract class ServiceBase : IService
    {
        private readonly List<IExtensionService> _extensions = new List<IExtensionService>();

        public abstract int Execute(IServiceOperation operation);

        public void Register(IExtensionService ext)
        {
            _extensions.Add(ext);
            ext.Owner = this;
        }

        public T GetExtension<T>()
        {
            var type = typeof(T);

            return (T) _extensions.First(x => x.GetType() == typeof(T));
        }
    }
}