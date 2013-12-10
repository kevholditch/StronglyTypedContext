using System;
using System.Reflection;

namespace StronglyTypedContext.Proxy
{
    public class KeyGenerator : IKeyGenerator
    {
        public string GenerateKey(Type type, MethodInfo methodInfo)
        {
            return string.Concat(type.FullName, methodInfo.Name.Replace("set_", "").Replace("get_", ""));        
        }
    }
}