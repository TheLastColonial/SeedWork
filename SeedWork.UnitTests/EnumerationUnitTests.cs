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
        /// When constructing a <see cref="Enumeration"/> with an empty <see cref="Enumeration.Name"/>
        /// Throws an <see cref="ArgumentNullException"/> 
        /// </summary>
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void Construction_WithEmptyName_ThrowsException(string name)
        {
            // Act
            Assert.Throws<ArgumentNullException>(() => { new ColourEnum(4, name); });
        }

        /// <summary>
        /// Given an <see cref="Enumeration"/>
        /// When calling <see cref="Enumeration.ToString"/>
        /// Return <see cref="Enumeration.Name"/>
        /// </summary>
        [Test]
        public void GivenEnumeration_WhenGettingString_ThenReturnName()
        {
            var colour = ColourEnum.Red.ToString();
            colour.Should().BeSameAs(nameof(ColourEnum.Red));
        }

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

        /// <summary>
        /// Given two different <see cref="Enumeration"/>
        /// When calling <see cref="Enumeration.AbsoluteDifference(Enumeration, Enumeration)"/>
        /// Then return the correct absolute difference between them
        /// </summary>
        [Test]
        public void GivenTwoDifferentEnumerations_WhenComparingAbsoluteDifference_ThenCorrectDifferenceIsReturned()
        {
            // Act
            int result = ColourEnum.AbsoluteDifference(ColourEnum.Red, ColourEnum.Blue);

            // Assert
            result.Should().Be(1);
        }

        /// <summary>
        /// Given two different <see cref="Enumeration"/>
        /// When calling <see cref="Enumeration.CompareTo(object)"/>
        /// Then return comparison bit
        /// </summary>
        [Test]
        public void GivenTwoDifferentEnumerations_WhenComparing_ThenReturnCorrectSortingBit()
        {
            // Act
            int result = ColourEnum.Blue.CompareTo(ColourEnum.Red);

            // Assert
            result.Should().Be(1);
        }

        /// <summary>
        /// Given two of the same <see cref="Enumeration"/>
        /// When comparing for equality with <see cref="Enumeration.Equals(object)"/>
        /// Return <see cref="true"/>
        /// </summary>
        [Test]
        public void GivenTwoOfTheSameEnumerations_WhenCallingEquals_ThenReturnTrue()
        {
            // Act
            var result = ColourEnum.Red.Equals(ColourEnum.Red);

            // Assert
            result.Should().BeTrue();
        }

        /// <summary>
        /// Given two different <see cref="Enumeration"/>
        /// When comparing for equality with <see cref="Enumeration.Equals(object)"/>
        /// Return <see cref="false"/>
        /// </summary>
        [Test]
        public void GivenTwoDifferentEnumerations_WhenCallingEquals_ThenReturnFalse()
        {
            // Act
            var result = ColourEnum.Red.Equals(ColourEnum.Blue);

            // Assert
            result.Should().BeFalse();
        }

        /// <summary>
        /// Given one <see cref="Enumeration"/> and one other <see cref="object"/>
        /// When comparing for equality with <see cref="Enumeration.Equals(object)"/>
        /// Return <see cref="false"/>
        /// </summary>
        [Test]
        public void GivenAnEnumerationAndAnotherObject_WhenCallingEquals_ThenReturnFalse()
        {
            // Act
            var result = ColourEnum.Red.Equals(new { Name = "Name" });

            // Assert
            result.Should().BeFalse();
        }

        /// <summary>
        /// Given one <see cref="Enumeration"/> and one other <see cref="object"/>
        /// When calling <see cref="Enumeration.CompareTo(object)"/>
        /// Then throw <see cref="InvalidOperationException"/> as they aren't compareable
        /// </summary>
        [Test]
        [Ignore("Reflection on each comparison may not be performant?")]
        public void GivenAnEnumerationAndAnotherObject_WhenComparing_ThenThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => { ColourEnum.Red.CompareTo(new { Name = "Name" }); });
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
