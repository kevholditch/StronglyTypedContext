using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.Core.Internal;
using StronglyTypedContext.Exceptions;

namespace StronglyTypedContext.Proxy
{
    public class ScenarioPropertyFetcher : IScenarioPropertyFetcher
    {
        public IEnumerable<PropertyInfo> Fetch(Type type)
        {
            foreach (var property in type.GetProperties()
                                 .Where(p => p.GetAttributes<ScenarioContextAttribute>().Any()))
            {
                if (!property.GetGetMethod().IsVirtual)
                    throw new ScenarioContextAttributeOnlyAllowedOnVirtualPropertyException();

                yield return property;
            }                
        }
    }


}