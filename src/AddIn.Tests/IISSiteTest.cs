using NUnit.Framework;

namespace com.github.yukon39.IISAdministration
{
    internal class IISSiteTest
    {
        [Test]
        public void Test_Properties()
        {
            // Given
            var config = TestsUtils.ApplicationConfig();
            var serverManager = IISServerManager.ScriptConstructor(config);
            var sites = serverManager.Sites;

            // When
            var site = sites.First();

            // Then
            Assert.AreEqual(1, site.Id);
            Assert.AreEqual("Default Web Site", site.Name);
        }
    }
}
