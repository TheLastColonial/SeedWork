namespace SeedWork.UnitTests
{
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class EntityUnitTests
    {
        /// <summary>
        /// GivenAnEntityHasAPrimaryKey_WhenContructionWithInt_ThenEntitySuccessfulCreates
        /// </summary>
        [Test]
        public void Construct_WithValidId_ShouldBeSuccessful()
        {
            // Arrange

            // Act
            var entity = new EntityStub(1);

            // Assert
            entity.Should().NotBeNull()
                .And.BeAssignableTo(typeof(Entity<uint>));
            entity.Id.Should().Be(1);
        }
    }

    class EntityStub : Entity<uint>
    {        
        public EntityStub(uint id) : base (id)
        {
        }
    }
}
