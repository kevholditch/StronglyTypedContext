using System;

namespace StronglyTypedContext.Exceptions
{
    public abstract class StronglyTypedContextException : Exception
    {
         protected StronglyTypedContextException(string message) : base(message)
         {
             
         }
    }
}