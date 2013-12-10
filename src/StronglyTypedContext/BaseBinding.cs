

using StronglyTypedContext.Proxy;
using StronglyTypedContext.Specflow;

namespace StronglyTypedContext
{
    
    public abstract class BaseBinding
    {
        protected BaseBinding()
        {
            var proxyPropertySetter =
                new ProxyPropertySetter(
                    new ProxyFactory(new ProxyInterceptor(new SpecFlowScenarioContext(), new KeyGenerator())),
                    new ScenarioPropertyFetcher());
            proxyPropertySetter.SetupScenarioContextProxies(this);
        }
    }
}