using System;
using System.Collections.Generic;
using System.Reflection;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using StronglyTypedContext.Proxy;
using StronglyTypedContext.Specflow;
using System.Linq;

namespace StronglyTypedContext.Tests
{
    [TestFixture]
    public class ProxyPropertySetterTests
    {
        [Test]
        public void SetProperties_SetsAllPropertiesToTypeReturnedByProxyFactory()
        {
            // Arrange
            var testProperties = typeof (TestClass).GetProperties().Where(p => p.Name.StartsWith("TestProperty")).ToArray();
            var fakeScenarioPropertyFetcher = A.Fake<IScenarioPropertyFetcher>();
            A.CallTo(() => fakeScenarioPropertyFetcher.Fetch(A<Type>.Ignored))
             .Returns(testProperties);

            var fakeProxyFactory = A.Fake<IProxyFactory>();
            A.CallTo(() => fakeProxyFactory.Create(testProperties[0]))
             .Returns(11);
            A.CallTo(() => fakeProxyFactory.Create(testProperties[1]))
             .Returns(52);

            var proxyPropertySetter = new ProxyPropertySetter(fakeProxyFactory, fakeScenarioPropertyFetcher);
            var testClass = new TestClass();

            // Act
            proxyPropertySetter.SetupScenarioContextProxies(testClass);

            // Assert
            testClass.TestProperty1.Should().Be(11);
            testClass.TestProperty2.Should().Be(52);

        }

    }
    
    public class TestClass 
    {        
        public virtual int TestProperty1 { get; set; }

        public virtual int TestProperty2 { get; set; }  
    }

  

    
}