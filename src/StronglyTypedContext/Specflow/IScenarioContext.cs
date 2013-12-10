namespace StronglyTypedContext.Specflow
{
    public interface IScenarioContext
    {
        object this[string key] { get; }
        void Add(string key, object item);
    }
}