using System.Reflection;

namespace StronglyTypedContext.Proxy
{
    public interface IProxyFactory
    {
        object Create(PropertyInfo propertyInfo);
    }
}