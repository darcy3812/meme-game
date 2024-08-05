using System.IO;
using System.Linq;
using System.Reflection;

namespace MemeGame.ArchitectureTests
{
    [SetUpFixture]
    public class Startup
    {
        [OneTimeSetUp]
        public static void Init()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _ = Directory
                .EnumerateFiles(path, "MemeGame.*.dll")
                .Where(f => !f.Contains("Tests"))
                .Select(Assembly.LoadFrom)
                .ToArray();
        }
    }
}
