using TechTalk.SpecFlow;

namespace StronglyTypedContext.Specflow
{
    public class SpecFlowScenarioContext : IScenarioContext
    {
        private readonly ScenarioContext _scenarioContext;

        public SpecFlowScenarioContext(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public object this[string key]
        {
            get { return _scenarioContext[key]; }
        }

        public void Add(string key, object item)
        {
            _scenarioContext.Add(key, item);
        }
    }
}