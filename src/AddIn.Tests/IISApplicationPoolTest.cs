using NUnit.Framework;

namespace com.github.yukon39.IISAdministration
{
    internal class IISApplicationPoolTest
    {
        [Test]
        public void Test_Rename()
        {
            // Given
            var config = TestsUtils.ApplicationConfig();
            var serverManager = IISServerManager.ScriptConstructor(config);
            var pools = serverManager.ApplicationPools;
            var pool = pools.Get("EnterpriseAppPool");
            var poolName = "TestApplicationPool";

            // When
            pool.Rename(poolName);

            // Then
            Assert.AreEqual(poolName, pool.Name);
        }
    }
}
