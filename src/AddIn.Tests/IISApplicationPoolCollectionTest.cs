using NUnit.Framework;

namespace com.github.yukon39.IISAdministration
{
    internal class IISApplicationPoolCollectionTest
    {
        [Test]
        public void Test_Count()
        {
            // Given
            var config = TestsUtils.FixturePath("applicationHost.config");
            var serverManager = IISServerManager.ScriptConstructor(config);
            var pools = serverManager.ApplicationPools;

            // When
            var count = pools.Count();

            // Then
            Assert.AreEqual(2, count);
        }

        [Test]
        public void Test_Get()
        {
            // Given
            var config = TestsUtils.FixturePath("applicationHost.config");
            var serverManager = IISServerManager.ScriptConstructor(config); ;
            var pools = serverManager.ApplicationPools;
            var poolName = "EnterpriseAppPool";

            // When
            var pool = pools.Get(poolName);

            // Then
            Assert.IsInstanceOf<IISApplicationPool>(pool);
            Assert.AreEqual(poolName, pool.Name);
        }

        [Test]
        public void Test_Add()
        {
            // Given
            var config = TestsUtils.FixturePath("applicationHost.config");
            var serverManager = IISServerManager.ScriptConstructor(config);
            var pools = serverManager.ApplicationPools;
            var poolName = "TestApplicationPool";

            // When
            var pool = pools.Add(poolName);

            // Then
            Assert.IsInstanceOf<IISApplicationPool>(pool);
            Assert.AreEqual(poolName, pool.Name);
            Assert.AreEqual(3, pools.Count());
        }

        [Test]
        public void Test_Remove()
        {
            // Given
            var config = TestsUtils.FixturePath("applicationHost.config");
            var serverManager = IISServerManager.ScriptConstructor(config);
            var pools = serverManager.ApplicationPools;
            var pool = pools.Get("EnterpriseAppPool");

            // When
            pools.Remove(pool);

            // Then
            Assert.AreEqual(1, pools.Count());
        }
    }
}
