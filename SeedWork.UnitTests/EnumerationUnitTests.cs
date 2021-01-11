namespace SeedWork.UnitTests
{
    using System;
    using FluentAssertions;
    using NUnit.Framework;

    /// <summary>
    /// Unit tests for <see cref="Enumeration"/>
    /// </summary>
    [TestFixture]
    public class EnumerationUnitTests
    {
        /// <summary>
        /// Given an <see cref="Enumeration"/> exists
        /// When getting all examples
        /// Then a list of all are returned
        /// </summary>
        [Test]
        public void GivenEnumerationExists_WhenGetAllExamples_ThenReturnListOfAllEnumerations()
        {
            // Act
            var examples = Enumeration.GetAll<ColourEnum>();

            // Assert
            examples.Should().HaveCount(3)
                .And.OnlyHaveUniqueItems();
        }

        /// <summary>
        /// Given an <see cref="Enumeration"/> exists
        /// When instanticating the specific <see cref="Enumeration"/>
        /// Then it should construct successfully
        /// </summary>
        /// <param name="id">Reference</param>
        /// <param name="name">Matching description</param>
        [Test]
        [TestCase(1, "Red")]
        [TestCase(2, "Blue")]
        [TestCase(3, "Green")]
        public void GivenEnumerationExists_WhenInstantiatingAnEnumeration_ThenConstructsSuccessfully(int id, string name)
        {
            // Arrange 

            // Act
            var fromValue = Enumeration.FromValue<ColourEnum>(id);
            var fromName = Enumeration.FromDisplayName<ColourEnum>(name);

            // Assert
            fromName.Should().BeSameAs(fromValue);
            fromValue.Should().BeSameAs(fromName);
            fromValue.Should().BeAssignableTo<Enumeration>();
        }

        /// <summary>
        /// Given an <see cref="Enumeration"/> exists
        /// When instantiating a non-existent <see cref="Enumeration"/>
        /// Then an exception should be thrown
        /// </summary>
        /// <param name="id">Invalid Reference</param>
        /// <param name="name">Invalid Description</param>
        [Test]
        public void GivenEnumerationExists_WhenInstantiatingAnNonExsitentEnumeration_ThenThrowException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Enumeration.FromValue<ColourEnum>(-1);
            });

            Assert.Throws<InvalidOperationException>(() =>
            {
                Enumeration.FromDisplayName<ColourEnum>("Brown");
            });
        }
    }

    /// <summary>
    /// Test Stub for <see cref="Enumeration"/> representing random colours.
    /// </summary>
    public class ColourEnum : Enumeration
    {

        public static ColourEnum Red = new ColourEnum(1, "Red");
        public static ColourEnum Blue = new ColourEnum(2, "Blue");
        public static ColourEnum Green = new ColourEnum(3, "Green");

        public ColourEnum(int id, string name) : base(id, name)
        {
        }
    }
}
