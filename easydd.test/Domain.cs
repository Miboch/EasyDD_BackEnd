using System;
using easydd.core.model;
using Xunit;

namespace easydd.test
{
    public class Domain
    {
        [Fact]
        public void Model_Implement_Entity()
        {
            // arrange
            Assert.True(typeof(EasyImage).IsSubclassOf(typeof(Entity)));
            Assert.True(typeof(EasyUser).IsSubclassOf(typeof(Entity)));
            Assert.True(typeof(Tag).IsSubclassOf(typeof(Entity)));
        }

        [Fact]
        public void Entity_Has_Id_And_Created()
        {
            Assert.True(typeof(Entity).GetProperty("Id") != null);
            Assert.True(typeof(Entity).GetProperty("Created") != null);
        }

    }
}
