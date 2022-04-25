using NUnit.Framework;

namespace com.github.yukon39.IISAdministration
{
    internal class IISSiteCollectionTest
    {
        [Test]
        public void Count_Test()
        {
            // Given
            var config = TestsUtils.ApplicationConfig();
            var serverManager = IISServerManager.ScriptConstructor(config);
            var sites = serverManager.Sites;

            // When
            var count = sites.Count();

            // Then
            Assert.AreEqual(1, count);
        }

        [Test]
        public void First_Test()
        {
            // Given
            var config = TestsUtils.ApplicationConfig();
            var serverManager = IISServerManager.ScriptConstructor(config);
            var sites = serverManager.Sites;

            // When
            var site = sites.First();

            // Then
            Assert.IsInstanceOf<IISSite>(site);
            Assert.AreEqual(1, site.Id);
        }

        [Test]
        public void GetByName_Test()
        {
            // Given
            var config = TestsUtils.ApplicationConfig();
            var serverManager = IISServerManager.ScriptConstructor(config);
            var sites = serverManager.Sites;
            var siteName = "Default Web Site";

            // When
            var site = sites.Get(siteName);

            // Then
            Assert.IsInstanceOf<IISSite>(site);
            Assert.AreEqual(siteName, site.Name);
        }

        [Test]
        public void GetById_Test()
        {
            // Given
            var config = TestsUtils.ApplicationConfig();
            var serverManager = IISServerManager.ScriptConstructor(config);
            var sites = serverManager.Sites;
            var siteId = 1;

            // When
            var site = sites.Get(siteId);

            // Then
            Assert.IsInstanceOf<IISSite>(site);
            Assert.AreEqual(siteId, site.Id);
        }
    }
}
