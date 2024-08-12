using MemeGame.ArchitectureTests.Extensions;
using MemeGame.Domain.Common;
using NetArchTest.Rules;
using static MemeGame.ArchitectureTests.Consts.Layers;


namespace MemeGame.ArchitectureTests.Entities
{
    [TestFixture]
    public class EntityTests
    {
        [Test]
        public void Entity_ShouldBe_ResideInDomain()
        {
            Types
            .InCurrentDomain()
                .That()
                .ImplementInterface(typeof(IEntity))
                .Should()
                .ResideInNamespace(MemeGameDomain)
                .ShoudBeMeet();
        }
    }
}
