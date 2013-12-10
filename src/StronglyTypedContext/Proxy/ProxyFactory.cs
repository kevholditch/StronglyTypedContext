using System.Reflection;
using Castle.DynamicProxy;

namespace StronglyTypedContext.Proxy
{
    public class ProxyFactory : IProxyFactory
    {
        private readonly IInterceptor [] _interceptors;

        public ProxyFactory(params IInterceptor [] interceptors)        
        {
            _interceptors = interceptors;
        }

        public object Create(PropertyInfo propertyInfo)
        {
            var generator = new ProxyGenerator();            
            var proxy = generator.CreateInterfaceProxyWithoutTarget(propertyInfo.PropertyType, _interceptors);
            return proxy;
        }
    }

        
}