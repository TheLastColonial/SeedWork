namespace SeedWork.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class EntityUnitTests
    {
        [Test]
        public void GivenAnEntityHasAPrimaryKey_WhenContructionWithInt_ThenEntitySuccessfulCreates()
        {
            // Arrange

            // Act
            var entity = new Entity<int>(1);

            // Assert
            entity.Should().NotBeNull()
                .And.BeOfType(typeof(Entity<int>));
            entity.Id.Should().Be(1);
        }
    }
}
