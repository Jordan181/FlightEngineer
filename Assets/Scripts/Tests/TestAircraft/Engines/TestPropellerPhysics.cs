using Aircraft.Engines;
using NUnit.Framework;

namespace TestCore.Physics.ComponentPhysics
{
    public class TestPropellerPhysics
    {
        private const float DefaultTolerance = 1e-5f;

        [Test]
        public void AdvanceRatioShouldBeCalculatedCorrectlyForAcceptableValues()
        {
            // Arrange
            const float airSpeed = 50;
            const float revsPerSecond = 40;
            const float diameter = 2;

            const float expectedAdvanceRatio = 0.625f;

            // Act
            var actualAdvanceRatio = PropellerPhysics.CalculateAdvanceRatio(airSpeed, revsPerSecond, diameter);

            // Assert
            Assert.AreEqual(expectedAdvanceRatio, actualAdvanceRatio, DefaultTolerance);
        }

        [Test]
        public void AdvanceRatioShouldReturn0For0Rps()
        {
            // Arrange
            const float airSpeed = 50;
            const float revsPerSecond = 0;
            const float diameter = 2;

            const float expectedAdvanceRatio = 0f;

            // Act
            var actualAdvanceRatio = PropellerPhysics.CalculateAdvanceRatio(airSpeed, revsPerSecond, diameter);

            // Assert
            Assert.AreEqual(expectedAdvanceRatio, actualAdvanceRatio, DefaultTolerance);
        }

        [Test]
        public void AdvanceRatioShouldReturn0For0Diameter()
        {
            // Arrange
            const float airSpeed = 50;
            const float revsPerSecond = 40;
            const float diameter = 0;

            const float expectedAdvanceRatio = 0f;

            // Act
            var actualAdvanceRatio = PropellerPhysics.CalculateAdvanceRatio(airSpeed, revsPerSecond, diameter);

            // Assert
            Assert.AreEqual(expectedAdvanceRatio, actualAdvanceRatio, DefaultTolerance);
        }
    }
}
