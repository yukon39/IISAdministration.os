using NUnit.Framework;

namespace com.github.yukon39.IISAdministration
{
    internal class IISServerManagerTest
    {
        [Test]
        public void TestApplicationPools()
        {
            // Given
            var config = TestsUtils.FixturePath("applicationHost.config");
            var serverManager = IISServerManager.ScriptConstructor(config);

            // When
            var pools = serverManager.ApplicationPools;

            // Then
            Assert.IsInstanceOf<IISApplicationPoolCollection>(pools);
        }
    }
}
