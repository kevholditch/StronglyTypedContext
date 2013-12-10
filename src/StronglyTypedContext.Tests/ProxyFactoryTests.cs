using NUnit.Framework;
using StronglyTypedContext.Proxy;
using System.Linq;
using FluentAssertions;

namespace StronglyTypedContext.Tests
{
    [TestFixture]    
    public class ProxyFactoryTests
    {
        [Test]
        public void Create_CreatesAProxyForPropertyType()
        {
            // Arrange
            var proxyFactory = new ProxyFactory();
            var propertyInfo = typeof (ClassWithProperty).GetProperties().First(p => p.Name == "Context");

            // Act
            var result = proxyFactory.Create(propertyInfo);

            // Assert
            var valueProperty = result.GetType().GetProperties().First(p => p.Name == "Value");
            valueProperty.PropertyType.Should().Be<int>();

            var somethingProperty = result.GetType().GetProperties().First(p => p.Name == "Something");
            somethingProperty.PropertyType.Should().Be<string>();

        }
    }

    public class ClassWithProperty
    {
        [ScenarioContext]
        public virtual IContext Context { get; set; }
    }

    public interface IContext
    {
        int Value { get; set; }
        string Something { get; set; }
    }


}