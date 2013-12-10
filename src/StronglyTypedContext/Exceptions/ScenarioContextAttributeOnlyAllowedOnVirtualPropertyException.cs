namespace StronglyTypedContext.Exceptions
{
    public class ScenarioContextAttributeOnlyAllowedOnVirtualPropertyException :StronglyTypedContextException
    {
        public ScenarioContextAttributeOnlyAllowedOnVirtualPropertyException()
            : base(
                "[ScenarioContext] Attribute must be placed on public virtual properties, did you forget to mark the property as virtual?"
                )
        {
            
        }
    }
}