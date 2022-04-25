using NUnit.Framework;

namespace com.github.yukon39.IISAdministration
{
    internal class IISApplicationCollectionTest
    {
        [Test]
        public void Test_Count()
        {
            // Given
            var config = TestsUtils.ApplicationConfig();
            var serverManager = IISServerManager.ScriptConstructor(config);
            var site = serverManager.Sites.First();
            var applications = site.Applications;

            // When
            var count = applications.Count();

            // Then
            Assert.AreEqual(2, count);
        }

        [Test]
        public void Test_Add()
        {
            // Given
            var config = TestsUtils.ApplicationConfig();
            var serverManager = IISServerManager.ScriptConstructor(config);
            var site = serverManager.Sites.First();
            var applications = site.Applications;
            var applicationPath = "/testApplication";
            var applicationPhysicalPath = "%SystemDrive%\\inetpub\\wwwroot\\testApplication";

            // When
            var application = applications.Add(applicationPath, applicationPhysicalPath);

            // Then
            Assert.AreEqual(3, applications.Count());
            Assert.IsInstanceOf<IISApplication>(application);
            Assert.AreEqual(applicationPath, application.Path);
            Assert.AreEqual(applicationPhysicalPath, application.PhysicalPath);
        }

        [Test]
        public void Test_Get()
        {
            // Given
            var config = TestsUtils.ApplicationConfig();
            var serverManager = IISServerManager.ScriptConstructor(config);
            var site = serverManager.Sites.First();
            var applications = site.Applications;
            var applicationPath = "/infobase";

            // When
            var application = applications.Get(applicationPath);

            // Then
            Assert.IsInstanceOf<IISApplication>(application);
            Assert.AreEqual(applicationPath, application.Path);
        }
    }
}
