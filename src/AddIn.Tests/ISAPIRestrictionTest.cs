using NUnit.Framework;

namespace com.github.yukon39.IISAdministration
{
    internal class ISAPIRestrictionTest
    {
        [Test]
        public void Test_Properties()
        {
            // Given
            var config = TestsUtils.ApplicationConfig();
            var serverManager = IISServerManager.ScriptConstructor(config);
            var restrictions = serverManager.ISAPIRestrictions;
            var path = "%ProgramFiles%\\1cv8\\8.3.18.1779\\bin\\wsisapi.dll";

            // When
            var restriction = restrictions.Get(path);

            // Then
            Assert.AreEqual(path, restriction.Path);
            Assert.AreEqual(true, restriction.Allowed);
            Assert.AreEqual("1C:Enterprise 8. wsisapi component", restriction.Description);
        }

        [Test]
        public void Test_SetAllowed()
        {
            // Given
            var config = TestsUtils.ApplicationConfig();
            var serverManager = IISServerManager.ScriptConstructor(config);
            var restrictions = serverManager.ISAPIRestrictions;
            var restriction = restrictions.Get("%ProgramFiles%\\1cv8\\8.3.18.1779\\bin\\wsisapi.dll");

            // When
            restriction.Allowed = false;

            // Then
            Assert.IsFalse(restriction.Allowed);
        }
    }
}
