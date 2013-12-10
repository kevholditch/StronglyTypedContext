namespace StronglyTypedContext.Exceptions
{
    public class MethodsNotSupportOnInterfaceException : StronglyTypedContextException
    {
        public MethodsNotSupportOnInterfaceException() 
            : base(string.Format("Only public get; set; properties are supported on interfaces"))
        {
        }
    }
}