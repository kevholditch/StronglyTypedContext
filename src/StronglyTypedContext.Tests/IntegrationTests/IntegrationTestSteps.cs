using TechTalk.SpecFlow;
using FluentAssertions;

namespace StronglyTypedContext.Tests.IntegrationTests
{
    [Binding]
    public class IntegrationTestSteps : BaseBinding
    {
        [ScenarioContext]
        public virtual IIntegreationTestContext TestContext { get; set; }

        [Given(@"I have a step definiton with a strongly typed scenario context")]
        public void GivenIHaveAStepDefinitonWithAStronglyTypedScenarioContext()
        {
            // empty step
        }

        [When(@"I set properties on the scenario context")]
        public void WhenISetPropertiesOnTheScenarioContext()
        {
            TestContext.TestString = "hello";
            TestContext.TestValue = 42;
        }

        [Then(@"the properties are persisted")]
        public void ThenThePropertiesArePersisted()
        {
            TestContext.TestString.Should().Be("hello");
            TestContext.TestValue.Should().Be(42);
        }

    }

    public interface IIntegreationTestContext
    {
        int TestValue { get; set; }
        string TestString { get; set; }
    }
}