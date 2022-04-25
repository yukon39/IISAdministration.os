using NUnit.Framework;

namespace com.github.yukon39.IISAdministration
{
    internal class IISApplicationTest
    {
        [Test]
        public void Test_Properties()
        {
            // Given
            var config = TestsUtils.ApplicationConfig();
            var serverManager = IISServerManager.ScriptConstructor(config);
            var site = serverManager.Sites.First();

            // When
            var application = site.Applications.Get("/infobase");

            // Then
            Assert.AreEqual("/infobase", application.Path);
            Assert.AreEqual("%SystemDrive%\\inetpub\\wwwroot\\infobase", application.PhysicalPath);
            Assert.AreEqual("EnterpriseAppPool", application.ApplicationPoolName);
        }

        [Test]
        public void Test_ApplicationPoolName()
        {
            // Given
            var config = TestsUtils.ApplicationConfig();
            var serverManager = IISServerManager.ScriptConstructor(config);
            var site = serverManager.Sites.First();
            var application = site.Applications.Get("/infobase");
            var applicationPoolName = "DefaultAppPool";

            // When
            application.ApplicationPoolName = applicationPoolName;

            // Then
            Assert.AreEqual(applicationPoolName, application.ApplicationPoolName);
        }
    }
}
