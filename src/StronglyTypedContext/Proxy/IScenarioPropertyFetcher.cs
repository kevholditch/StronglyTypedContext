using System;
using System.Collections.Generic;
using System.Reflection;

namespace StronglyTypedContext.Proxy
{
    public interface IScenarioPropertyFetcher
    {
        IEnumerable<PropertyInfo> Fetch(Type type);
    }
}