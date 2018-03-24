using chllngr.Functions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void expect_to_be_greeted()
        {
            Assert.AreEqual("Hello, Johan", new GreetingService().Greet("Johan").Greeting);
        }
    }
}
