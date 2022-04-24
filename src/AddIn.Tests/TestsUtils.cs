using NUnit.Framework;
using System.IO;

namespace com.github.yukon39.IISAdministration
{
    internal static class TestsUtils
    {
        public static string FixturePath(string path)
            => Path.Combine(TestContext.CurrentContext.TestDirectory, "fixtures", path);
    }
}
