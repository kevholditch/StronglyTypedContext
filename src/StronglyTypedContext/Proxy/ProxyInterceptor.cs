using Castle.DynamicProxy;
using StronglyTypedContext.Exceptions;
using StronglyTypedContext.Specflow;

namespace StronglyTypedContext.Proxy
{
    public class ProxyInterceptor : IInterceptor
    {
        private readonly IScenarioContext _scenarioContext;
        private readonly IKeyGenerator _keyGenerator;

        public ProxyInterceptor(IScenarioContext scenarioContext, IKeyGenerator keyGenerator)
        {
            _scenarioContext = scenarioContext;
            _keyGenerator = keyGenerator;
        }

        public ProxyInterceptor() : this(new SpecFlowScenarioContext(), new KeyGenerator())
        {            
        }


        public void Intercept(IInvocation invocation)
        {
            
            if (invocation.Method == null || !invocation.Method.IsSpecialName)
                throw new MethodsNotSupportOnInterfaceException();
            
            var method = invocation.Method;
            var key = _keyGenerator.GenerateKey(invocation.Method.DeclaringType, method);

            if (method.ReturnType == typeof (void))
            {
                _scenarioContext.Add(key, invocation.Arguments[0]);
            }
            else
            {
                invocation.ReturnValue = _scenarioContext[key];
            }

            
        }
    }
}