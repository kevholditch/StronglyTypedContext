﻿using TechTalk.SpecFlow;

namespace StronglyTypedContext.Specflow
{
    public class SpecFlowScenarioContext : IScenarioContext
    {
        public object this[string key]
        {
            get { return ScenarioContext.Current[key]; }
        }

        public void Add(string key, object item)
        {
            ScenarioContext.Current.Add(key, item);
        }
    }
}