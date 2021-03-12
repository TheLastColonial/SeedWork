namespace SeedWork.UnitTests
{
    using System.Collections.Generic;
    using NUnit.Framework;

    /// <summary>
    /// Unit tests for <see cref="ValueObject"/>
    /// </summary>
    [TestFixture]
    public class ValueObjectUnitTests
    {
        private ValueObject LocationStub { get; set; }

        [SetUp]
        public void Setup()
        {
            this.LocationStub = new LocationStub()
            {
                Latitude = 1.0m,
                Longitude = 2.0m
            };
        }

        [Test]
        public void ComparingSame_Equals_IsTrue()
        {
            Assert.IsTrue(this.LocationStub == this.LocationStub);
            Assert.IsTrue(this.LocationStub.Equals(this.LocationStub));
        }

        [Test]
        public void ComparingSame_NotEqual_IsFalse()
        {
            Assert.IsFalse(this.LocationStub != this.LocationStub);
        }


        [Test]
        public void GetCopy_IsSame()
        {
            var copy = this.LocationStub.GetCopy();
            Assert.AreEqual(this.LocationStub, copy);
        }
    }

    class LocationStub : ValueObject
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return this.Latitude;
            yield return this.Longitude;
        }
    }
}
