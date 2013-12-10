namespace StronglyTypedContext.Tests
{
    public interface ITestContext
    {
        int Value { get; set; }
        void TestMethod(int x);
    }

    public interface ITestContext2
    {
        int OtherValue { get; set; }
    }
}