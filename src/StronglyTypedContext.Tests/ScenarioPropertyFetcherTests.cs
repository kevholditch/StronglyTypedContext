using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using StronglyTypedContext.Exceptions;
using StronglyTypedContext.Proxy;

namespace StronglyTypedContext.Tests
{
    [TestFixture]
    public class ScenarioPropertyFetcherTests
    {

        private ScenarioPropertyFetcher _scenarioPropertyFetcher;

        [SetUp]
        public void Setup()
        {
            _scenarioPropertyFetcher = new ScenarioPropertyFetcher();
        }
       

        [Test]
        public void GetScenarioContextProperties_ReturnsOnePropertyWithAttribute()
        {
            // Arrange
            var type = typeof (TestClassWithOneContext);
            

            // Act
            var result = _scenarioPropertyFetcher.Fetch(type).ToList();

            // Assert
            result.Count.Should().Be(1);
            result[0].Name.Should().Be("TestContext");
        }

        [Test]
        public void GetScenarioContextProperties_ReturnsTwoPropertiesWithAttribute()
        {
            // Arrange
            var type = typeof(TestClassWithTwoContexts);

            // Act
            var result = _scenarioPropertyFetcher.Fetch(type).ToList();

            // Assert
            result.Count.Should().Be(2);
            result.Count(r => r.Name == "TestContext").Should().Be(1);
            result.Count(r => r.Name == "TestContext2").Should().Be(1);
        }

        [Test]
        public void GetScenarioContextProperties_ThrowsWhenAttributeOnNonVirtualProperty()
        {
            // Arrange
            var type = typeof(TestClassContextNotMarkedAsVirtual);

            // Act & Assert
            Assert.Throws<ScenarioContextAttributeOnlyAllowedOnVirtualPropertyException>(
                () => _scenarioPropertyFetcher.Fetch(type).ToList());
            
        }

        [Test]
        public void GetScenarioContextProperties_ReturnsNothingWhenAttributeNotUsed()
        {
            // Arrange
            var type = typeof(TestClassNoScenarioContexts);

            // Act
            var result = _scenarioPropertyFetcher.Fetch(type).ToList();

            // Assert
            result.Count.Should().Be(0);           
        }
    }

    public class TestClassWithOneContext
    {
        [ScenarioContext]
        public virtual ITestContext TestContext { get; set; }

    }

    public class TestClassWithTwoContexts
    {
        [ScenarioContext]
        public virtual ITestContext TestContext { get; set; }

        [ScenarioContext]
        public virtual ITestContext2 TestContext2 { get; set; }
    }

    public class TestClassContextNotMarkedAsVirtual
    {
        [ScenarioContext]
        public ITestContext TestContext { get; set; }

    }

    public class TestClassNoScenarioContexts
    {
        public ITestContext SomeProperty { get; set; }

        public ITestContext2 SomeOtherProperty { get; set; }
    }
}