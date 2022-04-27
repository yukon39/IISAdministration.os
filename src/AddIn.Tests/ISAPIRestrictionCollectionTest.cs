using NUnit.Framework;

namespace com.github.yukon39.IISAdministration
{
    internal class ISAPIRestrictionCollectionTest
    {
        [Test]
        public void Test_Count()
        {
            // Given
            var config = TestsUtils.ApplicationConfig();
            var serverManager = IISServerManager.ScriptConstructor(config);
            var restrictions = serverManager.ISAPIRestrictions;

            // When
            var count = restrictions.Count();

            // Then
            Assert.AreEqual(2, count);
        }

        [Test]
        public void Test_Get()
        {
            // Given
            var config = TestsUtils.ApplicationConfig();
            var serverManager = IISServerManager.ScriptConstructor(config);
            var restrictions = serverManager.ISAPIRestrictions;
            var path = "%ProgramFiles%\\1cv8\\8.3.18.1779\\bin\\wsisapi.dll";

            // When
            var restriction = restrictions.Get(path);

            // Then
            Assert.IsInstanceOf<ISAPIRestriction>(restriction);
            Assert.AreEqual(path, restriction.Path);
        }

        [Test]
        public void Test_CreateElement()
        {
            // Given
            var config = TestsUtils.ApplicationConfig();
            var serverManager = IISServerManager.ScriptConstructor(config);
            var restrictions = serverManager.ISAPIRestrictions;
            var path = "%ProgramFiles%\\1cv8\\8.3.20.1789\\bin\\wsisapi.dll";

            // When
            var restriction = restrictions.CreateElement(path);

            // Then
            Assert.IsInstanceOf<ISAPIRestriction>(restriction);
            Assert.AreEqual(path, restriction.Path);
        }

        [Test]
        public void Test_Add()
        {
            // Given
            var config = TestsUtils.ApplicationConfig();
            var serverManager = IISServerManager.ScriptConstructor(config);
            var restrictions = serverManager.ISAPIRestrictions;
            var path = "%ProgramFiles%\\1cv8\\8.3.20.1789\\bin\\wsisapi.dll";
            var element = restrictions.CreateElement(path);

            // When
            restrictions.Add(element);

            // Then
            Assert.AreEqual(3, restrictions.Count());
        }

        [Test]
        public void Test_Remove()
        {
            // Given
            var config = TestsUtils.ApplicationConfig();
            var serverManager = IISServerManager.ScriptConstructor(config);
            var restrictions = serverManager.ISAPIRestrictions;
            var path = "%ProgramFiles%\\1cv8\\8.3.18.1779\\bin\\wsisapi.dll";
            var restriction = restrictions.Get(path);

            // When
            restrictions.Remove(restriction);

            // Then
            Assert.AreEqual(1, restrictions.Count());
        }

        [Test]
        public void Test_Clear()
        {
            // Given
            var config = TestsUtils.ApplicationConfig();
            var serverManager = IISServerManager.ScriptConstructor(config);
            var restrictions = serverManager.ISAPIRestrictions;

            // When
            restrictions.Clear();

            // Then
            Assert.AreEqual(0, restrictions.Count());
        }
    }
}
