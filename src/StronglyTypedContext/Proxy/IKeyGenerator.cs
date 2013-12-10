using System;
using System.Reflection;

namespace StronglyTypedContext.Proxy
{
    public interface IKeyGenerator
    {
        string GenerateKey(Type type, MethodInfo methodInfo);
    }
}