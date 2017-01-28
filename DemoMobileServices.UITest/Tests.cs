using NUnit.Framework;
using Xamarin.UITest;

namespace DemoMobileServices.UITest
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            app.WaitForElement(a=> a.Id("button"));
            app.Screenshot("First screen.");
        }
    }
}

