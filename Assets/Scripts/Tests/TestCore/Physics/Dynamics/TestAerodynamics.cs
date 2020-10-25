using Core.Physics.Dynamics;
using NUnit.Framework;
using UnityEngine;

namespace TestCore.Physics.Dynamics
{
    public class TestAerodynamics
    {
        #region Angular Drag Tests

        [Test]
        public void AngularDragShouldBeCorrectForHorizontalPlateRotatingAboutZAxis()
        {
            // Arrange
            var angularVelocity = new Vector3(0, 0, 2);
            var surfaceNormal = new Vector3(0, 1, 0);
            const float distanceFromPivot = 1.5f;
            const float area = 1f;
            const float airDensity = 1f;
            const float dragCoefficient = 2;

            const float expectedAngularDrag = 9f;

            // Act
            var actualAngularDrag = Aerodynamics.CalculateFlatPlateAngularDrag(angularVelocity, surfaceNormal, distanceFromPivot, area, airDensity, dragCoefficient);

            // Assert
            Assert.AreEqual(expectedAngularDrag, actualAngularDrag, TestHelpers.DefaultTolerance);
        }

        [Test]
        public void AngularDragShouldBeCorrectForHorizontalPlateRotatingAboutXAxis()
        {
            // Arrange
            var angularVelocity = new Vector3(2, 0, 0);
            var surfaceNormal = new Vector3(0, 1, 0);
            const float distanceFromPivot = 1.5f;
            const float area = 1f;
            const float airDensity = 1f;
            const float dragCoefficient = 2;

            const float expectedAngularDrag = 9f;

            // Act
            var actualAngularDrag = Aerodynamics.CalculateFlatPlateAngularDrag(angularVelocity, surfaceNormal, distanceFromPivot, area, airDensity, dragCoefficient);

            // Assert
            Assert.AreEqual(expectedAngularDrag, actualAngularDrag, TestHelpers.DefaultTolerance);
        }

        [Test]
        public void AngularDragShouldBeZeroForHorizontalPlateRotatingAboutYAxis()
        {
            // Arrange
            var angularVelocity = new Vector3(0, 2, 0);
            var surfaceNormal = new Vector3(0, 1, 0);
            const float distanceFromPivot = 1.5f;
            const float area = 1f;
            const float airDensity = 1f;
            const float dragCoefficient = 2;

            const float expectedAngularDrag = 0f;

            // Act
            var actualAngularDrag = Aerodynamics.CalculateFlatPlateAngularDrag(angularVelocity, surfaceNormal, distanceFromPivot, area, airDensity, dragCoefficient);

            // Assert
            Assert.AreEqual(expectedAngularDrag, actualAngularDrag, TestHelpers.DefaultTolerance);
        }

        [Test]
        public void AngularDragShouldBeCorrectForVerticalPlateRotatingAboutYAxis()
        {
            // Arrange
            var angularVelocity = new Vector3(0, 2, 0);
            var surfaceNormal = new Vector3(1, 0, 0);
            const float distanceFromPivot = 1.5f;
            const float area = 1f;
            const float airDensity = 1f;
            const float dragCoefficient = 2;

            const float expectedAngularDrag = 9f;

            // Act
            var actualAngularDrag = Aerodynamics.CalculateFlatPlateAngularDrag(angularVelocity, surfaceNormal, distanceFromPivot, area, airDensity, dragCoefficient);

            // Assert
            Assert.AreEqual(expectedAngularDrag, actualAngularDrag, TestHelpers.DefaultTolerance);
        }

        #endregion

        [Test]
        public void DynamicPressureShouldBeCalculatedCorrectly()
        {
            // Arrange
            const float airDensity = 1f;
            const float relativeAirSpeed = 100f;

            const float expectedPressure = 5000f;

            // Act
            var actualPressure = Aerodynamics.CalculateDynamicPressure(airDensity, relativeAirSpeed);

            // Assert
            Assert.AreEqual(expectedPressure, actualPressure, TestHelpers.DefaultTolerance);
        }

        [Test]
        public void AerodynamicForceShouldBeCalculatedCorrectly()
        {
            // Arrange
            const float dynamicPressure = 5000f;
            const float characteristicArea = 2f;
            const float dimensionlessCoefficient = 0.1f;

            const float expectedForce = 1000f;

            // Act
            var actualForce = Aerodynamics.CalculateAerodynamicForce(dynamicPressure, characteristicArea, dimensionlessCoefficient);

            // Assert
            Assert.AreEqual(expectedForce, actualForce, TestHelpers.DefaultTolerance);
        }
    }
}
