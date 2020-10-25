using Aircraft.Engines;
using Aircraft.Specifications;
using NUnit.Framework;
using UnityEngine;

namespace TestCore.Physics.ComponentPhysics
{
    public class TestPistonEnginePhysics
    {
        private const float DefaultTolerance = 1e-5f;

        private const float MinRpm = 1000;
        private const float MaxRpm = 2000;
        private const float MinTorque = 100;
        private const float MaxTorque = 400;
        private static readonly AnimationCurve TorqueCurve = AnimationCurve.Linear(0, 0, 1, 1);
        private static readonly PistonEngineSpecification EngineSpec = new PistonEngineSpecification
        {
            MinRpm = MinRpm,
            MaxRpm = MaxRpm,
            MinTorque = MinTorque,
            MaxTorque = MaxTorque,
            NormalizedTorqueCurve = TorqueCurve
        };

        [Test]
        public void TorqueShouldBeCorrectlyCalculatedAtAGivenRpm()
        {
            // Arrange
            const float currentRpm = 1750;
            const float expectedTorque = 325;

            // Act
            var actualTorque = PistonEnginePhysics.CalculateTorque(EngineSpec, currentRpm);

            // Assert
            Assert.AreEqual(expectedTorque, actualTorque, DefaultTolerance);
        }

        [Test]
        public void TorqueShouldBe0IfRpmIsLessThanMinRpm()
        {
            // Arrange
            const float currentRpm = 500;
            const float expectedTorque = 0;

            // Act
            var actualTorque = PistonEnginePhysics.CalculateTorque(EngineSpec, currentRpm);

            // Assert
            Assert.AreEqual(expectedTorque, actualTorque, DefaultTolerance);
        }

        [Test]
        public void TorqueShouldBe0IfRpmIsGreaterThanMaxRpm()
        {
            // Arrange
            const float currentRpm = 2500;
            const float expectedTorque = 0;

            // Act
            var actualTorque = PistonEnginePhysics.CalculateTorque(EngineSpec, currentRpm);

            // Assert
            Assert.AreEqual(expectedTorque, actualTorque, DefaultTolerance);
        }
    }
}
