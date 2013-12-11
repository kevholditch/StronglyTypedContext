using TechTalk.SpecFlow;
using FluentAssertions;

namespace StronglyTypedContext.Tests.IntegrationTests.MultipleStepDefinitions
{

    public interface ISharedContext
    {
        int CustomerId { get; set; }
    }

    [Binding]
    public class MultipleStepDefinitionsOne : BaseBinding
    {
        [ScenarioContext]
        public virtual ISharedContext Context { get; set; }

        [Given(@"I have a step definition file with a scenario context property")]
        public void GivenIHaveAStepDefinitionFileWithAScenarioContextProperty()
        {
            // empty step
        }

        [When(@"I set the property in one step definition class")]
        public void WhenISetThePropertyInOneStepDefinitionClass()
        {
            Context.CustomerId = 1234;
        }


    }

    [Binding]
    public class MultipleStepDefinitionsTwo : BaseBinding
    {
        [ScenarioContext]
        public virtual ISharedContext Context { get; set; }

        [Then(@"I can read the property in a different step definition class")]
        public void ThenICanReadThePropertyInADifferentStepDefinitionClass()
        {
            Context.CustomerId.Should().Be(1234);
        }

    }
}
