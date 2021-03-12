namespace SeedWork.UnitTests
{
    using System;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class EntityUnitTests
    {
        /// <summary>
        /// Given an <see cref="Entity{T}"/> has a <see cref="Entity{T}.Id"/>
        /// When contruction with <see cref="string"/>
        /// Then <see cref="Entity{T}"/> successful creates itself
        /// </summary>
        [Test]
        public void Construct_WithValidId_ShouldBeSuccessful()
        {
            // Act
            var entity = new PersonStub("1");

            // Assert
            entity.Should().NotBeNull()
                .And.BeAssignableTo(typeof(Entity<string>));
            entity.Id.Should().Be("1");
        }

        /// <summary>
        /// Given an <see cref="Entity{T}"/> is implimented
        /// When constucting with <see cref="null"/> <see cref="Entity{T}.Id"/>
        /// Then an <see cref="ArgumentNullException"/> should be thrown
        /// </summary>
        [Test]
        public void Constuct_WithEmptyId_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => { new PersonStub(null); });
        }
    }

    class PersonStub : Entity<string>
    {        
        public PersonStub(string id) : base (id)
        {
        }
    }
}
