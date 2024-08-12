using MemeGame.ArchitectureTests.Extensions;
using NetArchTest.Rules;
using System.Collections.Generic;
using System.Linq;
using static MemeGame.ArchitectureTests.Consts.Layers;

namespace MemeGame.ArchitectureTests.Layers
{
    [TestFixture]
    public class LayerDependencyTests
    {
        private static readonly Dictionary<string, string[]> _allowedDependencies = new Dictionary<string, string[]>
        {
            [MemeGameDomain] = [MemeGameDomainCommon, MemeGameCommon],
            [MemeGameApplication] = [MemeGameDomainCommon, MemeGameDomain, MemeGameCommon],
            [MemeGameInfrastructure] = [MemeGameDomainCommon, MemeGameDomain, MemeGameApplication, MemeGameCommon],
            [MemeGameAPI] = [MemeGameDomainCommon, MemeGameDomain, MemeGameApplication, MemeGameInfrastructure, MemeGameCommon]
        };

        private static readonly string[] _allMemeGameLayers = _allowedDependencies.Keys.ToArray();

        [TestCaseSource(nameof(_allMemeGameLayers))]
        public void InnerLayer_ShouldNotHaveDependencyOn_ExternalLayer(string innerNamespace)
        {
            var forbiddenDependencies = Types
                .InCurrentDomain()
                .That()
                .ResideInNamespace(Consts.Layers.MemeGame)
                .And()
                .DoNotResideInNamespace(innerNamespace);

            foreach (var allowedDependency in _allowedDependencies[innerNamespace])
            {
                forbiddenDependencies = forbiddenDependencies.And().DoNotResideInNamespace(allowedDependency);
            }

            var forbiddenTypes = forbiddenDependencies
                .GetTypes()
                .Select(t => t.FullName)
                .ToArray();

            Types
                .InCurrentDomain()
                .That()
                .ResideInNamespace(innerNamespace)
                .ShouldNot()
                .HaveDependencyOnAny(forbiddenTypes)
                .ShoudBeMeet();
        }
    }
}