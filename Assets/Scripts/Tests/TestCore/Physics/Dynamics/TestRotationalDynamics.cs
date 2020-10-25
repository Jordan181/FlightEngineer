using Core.Physics.Dynamics;
using NUnit.Framework;

namespace TestCore.Physics.Dynamics
{
    public class TestRotationalDynamics
    {
        [Test]
        public void AngularAccelerationShouldBeCalculatedCorrectly()
        {
            // Arrange
            const float torque = 100;
            const float momentOfInertia = 20;

            const float expectedAngularAcceleration = 5;

            // Act
            var actualAngularAcceleration = RotationalDynamics.CalculateAngularAcceleration(torque, momentOfInertia);

            // Assert
            Assert.AreEqual(expectedAngularAcceleration, actualAngularAcceleration, TestHelpers.DefaultTolerance);
        }
    }
}
