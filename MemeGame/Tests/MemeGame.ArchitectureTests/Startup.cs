using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MemeGame.ArchitectureTests
{
    [SetUpFixture]
    public class Startup
    {
        [OneTimeSetUp]
        public static void Init()
        {                
            _ = Directory
                .EnumerateFiles(@".\", "MemeGame.*.dll")
                .Where(f => !f.Contains("Tests"))
                .Select(Assembly.LoadFrom)
                .ToArray();
        }
    }
}
