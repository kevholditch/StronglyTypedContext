using System;
using System.Reflection;
using Castle.DynamicProxy;
using FakeItEasy;
using NUnit.Framework;
using StronglyTypedContext.Exceptions;
using StronglyTypedContext.Proxy;
using StronglyTypedContext.Specflow;
using FluentAssertions;

namespace StronglyTypedContext.Tests
{
    [TestFixture]    
    public class ProxyInterceptorTests
    {

        private IScenarioContext _fakeScenarioContext;
        private IKeyGenerator _fakeKeyGenerator;
        private ProxyInterceptor _proxyInterceptor;
        private ProxyGenerator _proxyGenerator;

        [SetUp]
        public void Setup()
        {
            _fakeScenarioContext = A.Fake<IScenarioContext>();
            _fakeKeyGenerator = A.Fake<IKeyGenerator>();
            A.CallTo(() => _fakeKeyGenerator.GenerateKey(A<Type>.Ignored, A<MethodInfo>.Ignored)).Returns("testkey");
            _proxyInterceptor = new ProxyInterceptor(_fakeScenarioContext, _fakeKeyGenerator);
            _proxyGenerator = new ProxyGenerator();

        }

        [Test]
        public void SetProperty_SetsThePropertyInTheScenarioContext()
        {
            // Arrange                        
            var proxy = _proxyGenerator.CreateInterfaceProxyWithoutTarget<ITestContext>(_proxyInterceptor);

            // Act
            proxy.Value = 43;

            // Assert
            A.CallTo(() => _fakeScenarioContext.Add("testkey", A<object>.Ignored))
                .WhenArgumentsMatch(args => (string)args[0] == "testkey" && (int)args[1] == 43)
                .MustHaveHappened(Repeated.Exactly.Once);

        }

        [Test]
        public void GetProperty_GetsThePropertyFromTheScenarioContext()
        {
            // Arrange                        
            A.CallTo(() => _fakeScenarioContext["testkey"]).Returns(43);
            var proxy = _proxyGenerator.CreateInterfaceProxyWithoutTarget<ITestContext>(_proxyInterceptor);

            // Act
            var result = (int)proxy.Value;

            // Assert
            result.Should().Be(43);
        }

        [Test]
        public void Throws_MethodsNotSupportedExceptionWhenMethodCalledOnInterface()
        {
            // Arrange                                    
            var proxy = _proxyGenerator.CreateInterfaceProxyWithoutTarget<ITestContext>(_proxyInterceptor);

            // Act & Assert
            Assert.Throws<MethodsNotSupportOnInterfaceException>(() => proxy.TestMethod(43));
            
        }

    }
}