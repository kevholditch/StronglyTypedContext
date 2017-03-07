using StronglyTypedContext.Proxy;
using StronglyTypedContext.Specflow;
using TechTalk.SpecFlow;

namespace StronglyTypedContext
{
    public abstract class BaseBinding
    {
        private BaseBinding(IScenarioContext scenarioContext)
        {
            var proxyPropertySetter =
                new ProxyPropertySetter(
                    new ProxyFactory(new ProxyInterceptor(scenarioContext, new KeyGenerator())),
                    new ScenarioPropertyFetcher());
            proxyPropertySetter.SetupScenarioContextProxies(this);
        }

        protected BaseBinding() : this(new SpecFlowCurrentScenarioContext())
        {
        }

        protected BaseBinding(ScenarioContext scenarioContext) : this(new SpecFlowScenarioContext(scenarioContext))
        {
        }
    }
}