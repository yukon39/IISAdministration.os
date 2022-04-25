using NUnit.Framework;

namespace com.github.yukon39.IISAdministration
{
    internal class IISServerManagerTest
    {
        [Test]
        public void Test_ApplicationPools()
        {
            // Given
            var config = TestsUtils.ApplicationConfig();
            var serverManager = IISServerManager.ScriptConstructor(config);

            // When
            var pools = serverManager.ApplicationPools;

            // Then
            Assert.IsInstanceOf<IISApplicationPoolCollection>(pools);
        }

        [Test]
        public void Test_Sites()
        {
            // Given
            var config = TestsUtils.ApplicationConfig();
            var serverManager = IISServerManager.ScriptConstructor(config);

            // When
            var sites = serverManager.Sites;

            // Then
            Assert.IsInstanceOf<IISSiteCollection>(sites);
        }
    }
}
