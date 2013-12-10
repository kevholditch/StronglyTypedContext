using Castle.DynamicProxy;

namespace StronglyTypedContext.Proxy
{
    public class ProxyPropertySetter
    {
        private readonly IProxyFactory _proxyFactory;
        private readonly IScenarioPropertyFetcher _scenarioPropertyFetcher;

        public ProxyPropertySetter(IProxyFactory proxyFactory, IScenarioPropertyFetcher scenarioPropertyFetcher)
        {
            _proxyFactory = proxyFactory;
            _scenarioPropertyFetcher = scenarioPropertyFetcher;
        }

        public void SetupScenarioContextProxies(object item)
        {
            foreach (var property in _scenarioPropertyFetcher.Fetch(item.GetType()))
            {
                var proxy = _proxyFactory.Create(property);
                property.SetValue(item, proxy);
            }
        }
    }
}