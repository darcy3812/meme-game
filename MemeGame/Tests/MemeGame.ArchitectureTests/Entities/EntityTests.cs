using MemeGame.ArchitectureTests.Extensions;
using MemeGame.Domain.Common;
using NetArchTest.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
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
