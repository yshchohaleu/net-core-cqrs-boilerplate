using System;

namespace CqrsBoilerplate.Tests
{
    public class TestContext
    {
        public TestContext()
        { }

        public static TestContext Current { get; } = new TestContext();

        public IServiceProvider ServiceProvider
        {
            get; set;
        }
    }
}
