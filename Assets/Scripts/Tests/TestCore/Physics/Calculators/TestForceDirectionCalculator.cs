using Core.Physics.Calculators;
using NUnit.Framework;
using UnityEngine;

namespace TestCore.Physics.Calculators
{
    public class TestForceDirectionCalculator
    {
        #region Vertical Lift Direction Tests

        [Test]
        public void VerticalLiftDirectionShouldBeDirectlyUpForLevelAircraftWithLevelFlightPathTowardsZ()
        {
            // Arrange
            var velocity = new Vector3(0, 0, 2);
            var rotation = Quaternion.Euler(0, 0, 0);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            var expectedLiftDirection = new Vector3(0, 1, 0);

            // Act
            var actualLiftDirection = ForceDirectionCalculator.CalculateVerticalLiftDirection(transform, velocity);

            // Assert
            AssertVectorsAreEqual(expectedLiftDirection, actualLiftDirection);
        }

        [Test]
        public void VerticalLiftDirectionShouldBeDirectlyUpForLevelAircraftWithLevelFlightPathTowardsX()
        {
            // Arrange
            var velocity = new Vector3(2, 0, 0);
            var rotation = Quaternion.Euler(0, 90, 0);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            var expectedLiftDirection = new Vector3(0, 1, 0);

            // Act
            var actualLiftDirection = ForceDirectionCalculator.CalculateVerticalLiftDirection(transform, velocity);

            // Assert
            AssertVectorsAreEqual(expectedLiftDirection, actualLiftDirection);
        }

        [Test]
        public void VerticalLiftDirectionShouldBeTowardsNegativeZForVerticalAircraftWithFlightPathTowardsY()
        {
            // Arrange
            var velocity = new Vector3(0, 2, 0);
            var rotation = Quaternion.Euler(-90, 0, 0);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            var expectedLiftDirection = new Vector3(0, 0, -1);

            // Act
            var actualLiftDirection = ForceDirectionCalculator.CalculateVerticalLiftDirection(transform, velocity);

            // Assert
            AssertVectorsAreEqual(expectedLiftDirection, actualLiftDirection);
        }

        [Test]
        public void VerticalLiftDirectionShouldBeTowardsNegativeXForSidewaysAircraftWithLocalXUpAndFlightPathTowardsZ()
        {
            // Arrange
            var velocity = new Vector3(0, 0, 2);
            var rotation = Quaternion.Euler(0, 0, 90);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            var expectedLiftDirection = new Vector3(-1, 0, 0);

            // Act
            var actualLiftDirection = ForceDirectionCalculator.CalculateVerticalLiftDirection(transform, velocity);

            // Assert
            AssertVectorsAreEqual(expectedLiftDirection, actualLiftDirection);
        }

        [Test]
        public void VerticalLiftDirectionShouldBeTowardsPositiveXForSidewaysAircraftWithLocalXDownAndFlightPathTowardsZ()
        {
            // Arrange
            var velocity = new Vector3(0, 0, 2);
            var rotation = Quaternion.Euler(0, 0, -90);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            var expectedLiftDirection = new Vector3(1, 0, 0);

            // Act
            var actualLiftDirection = ForceDirectionCalculator.CalculateVerticalLiftDirection(transform, velocity);

            // Assert
            AssertVectorsAreEqual(expectedLiftDirection, actualLiftDirection);
        }

        [Test]
        public void VerticalLiftDirectionShouldBeTowardsPositiveZForVerticalAircraftWithFlightPathTowardsNegativeY()
        {
            // Arrange
            var velocity = new Vector3(0, -2, 0);
            var rotation = Quaternion.Euler(90, 0, 0);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            var expectedLiftDirection = new Vector3(0, 0, 1);

            // Act
            var actualLiftDirection = ForceDirectionCalculator.CalculateVerticalLiftDirection(transform, velocity);

            // Assert
            AssertVectorsAreEqual(expectedLiftDirection, actualLiftDirection);
        }

        [Test]
        public void VerticalLiftDirectionShouldBeAtCorrectAngleForInclinedFlightPath()
        {
            // Arrange
            var velocity = new Vector3(0, 1, 1);
            var rotation = Quaternion.Euler(-45, 0, 0);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            var expectedLiftDirection = new Vector3(0, 1, -1).normalized;

            // Act
            var actualLiftDirection = ForceDirectionCalculator.CalculateVerticalLiftDirection(transform, velocity);

            // Assert
            AssertVectorsAreEqual(expectedLiftDirection, actualLiftDirection);
        }

        [Test]
        public void VerticalLiftDirectionShouldBeDirectlyUpForPositiveAngleOfAttackAndFlightPathTowardsZ()
        {
            // Arrange
            var velocity = new Vector3(0, 0, 1);
            var rotation = Quaternion.Euler(25, 0, 0);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            var expectedLiftDirection = new Vector3(0, 1, 0).normalized;

            // Act
            var actualLiftDirection = ForceDirectionCalculator.CalculateVerticalLiftDirection(transform, velocity);

            // Assert
            AssertVectorsAreEqual(expectedLiftDirection, actualLiftDirection);
        }

        [Test]
        public void VerticalLiftDirectionShouldBeDirectlyDownForInvertedAircraftWithFlightPathTowardsZ()
        {
            // Arrange
            var velocity = new Vector3(0, 0, 2);
            var rotation = Quaternion.Euler(0, 0, 180);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            var expectedLiftDirection = new Vector3(0, -1, 0);

            // Act
            var actualLiftDirection = ForceDirectionCalculator.CalculateVerticalLiftDirection(transform, velocity);

            // Assert
            AssertVectorsAreEqual(expectedLiftDirection, actualLiftDirection);
        }
        #endregion

        #region Horizontal Lift Direction Tests

        [Test]
        public void HorizontalLiftDirectionShouldBeDirectlyRightForLevelAircraftWithLevelFlightPathTowardsZ()
        {
            // Arrange
            var velocity = new Vector3(0, 0, 2);
            var rotation = Quaternion.Euler(0, 0, 0);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            var expectedLiftDirection = new Vector3(1, 0, 0);

            // Act
            var actualLiftDirection = ForceDirectionCalculator.CalculateHorizontalLiftDirection(transform, velocity);

            // Assert
            AssertVectorsAreEqual(expectedLiftDirection, actualLiftDirection);
        }

        [Test]
        public void HorizontalLiftDirectionShouldBeTowardsNegativeZForLevelAircraftWithLevelFlightPathTowardsX()
        {
            // Arrange
            var velocity = new Vector3(2, 0, 0);
            var rotation = Quaternion.Euler(0, 90, 0);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            var expectedLiftDirection = new Vector3(0, 0, -1);

            // Act
            var actualLiftDirection = ForceDirectionCalculator.CalculateHorizontalLiftDirection(transform, velocity);

            // Assert
            AssertVectorsAreEqual(expectedLiftDirection, actualLiftDirection);
        }

        [Test]
        public void HorizontalLiftDirectionShouldBeTowardsXForVerticalAircraftWithFlightPathTowardsY()
        {
            // Arrange
            var velocity = new Vector3(0, 2, 0);
            var rotation = Quaternion.Euler(-90, 0, 0);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            var expectedLiftDirection = new Vector3(1, 0, 0);

            // Act
            var actualLiftDirection = ForceDirectionCalculator.CalculateHorizontalLiftDirection(transform, velocity);

            // Assert
            AssertVectorsAreEqual(expectedLiftDirection, actualLiftDirection);
        }

        [Test]
        public void HorizontalLiftDirectionShouldBeTowardsPositiveYForSidewaysAircraftWithLocalXUpAndFlightPathTowardsZ()
        {
            // Arrange
            var velocity = new Vector3(0, 0, 2);
            var rotation = Quaternion.Euler(0, 0, 90);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            var expectedLiftDirection = new Vector3(0, 1, 0);

            // Act
            var actualLiftDirection = ForceDirectionCalculator.CalculateHorizontalLiftDirection(transform, velocity);

            // Assert
            AssertVectorsAreEqual(expectedLiftDirection, actualLiftDirection);
        }

        [Test]
        public void HorizontalLiftDirectionShouldBeTowardsNegativeYForSidewaysAircraftWithLocalXDownAndFlightPathTowardsZ()
        {
            // Arrange
            var velocity = new Vector3(0, 0, 2);
            var rotation = Quaternion.Euler(0, 0, -90);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            var expectedLiftDirection = new Vector3(0, -1, 0);

            // Act
            var actualLiftDirection = ForceDirectionCalculator.CalculateHorizontalLiftDirection(transform, velocity);

            // Assert
            AssertVectorsAreEqual(expectedLiftDirection, actualLiftDirection);
        }

        [Test]
        public void HorizontalLiftDirectionShouldBeTowardsPositiveXForVerticalAircraftWithFlightPathTowardsNegativeY()
        {
            // Arrange
            var velocity = new Vector3(0, -2, 0);
            var rotation = Quaternion.Euler(90, 0, 0);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            var expectedLiftDirection = new Vector3(1, 0, 0);

            // Act
            var actualLiftDirection = ForceDirectionCalculator.CalculateHorizontalLiftDirection(transform, velocity);

            // Assert
            AssertVectorsAreEqual(expectedLiftDirection, actualLiftDirection);
        }

        [Test]
        public void HorizontalLiftDirectionShouldBeTowardsPositiveXForInclinedAircraftWithFlightPathTowardsZ()
        {
            // Arrange
            var velocity = new Vector3(0, 0, 2);
            var rotation = Quaternion.Euler(30, 0, 0);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            var expectedLiftDirection = new Vector3(1, 0, 0);

            // Act
            var actualLiftDirection = ForceDirectionCalculator.CalculateHorizontalLiftDirection(transform, velocity);

            // Assert
            AssertVectorsAreEqual(expectedLiftDirection, actualLiftDirection);
        }

        [Test]
        public void HorizontalLiftDirectionShouldBeAtCorrectAngleForAircraftTurnedAndFlyingStraight()
        {
            // Arrange
            var velocity = new Vector3(1, 0, 1);
            var rotation = Quaternion.Euler(0, 45, 0);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            var expectedLiftDirection = new Vector3(1, 0, -1).normalized;

            // Act
            var actualLiftDirection = ForceDirectionCalculator.CalculateHorizontalLiftDirection(transform, velocity);

            // Assert
            AssertVectorsAreEqual(expectedLiftDirection, actualLiftDirection);
        }

        [Test]
        public void HorizontalLiftDirectionShouldBeCorrectForAircraftTurnedIntoFlightPath()
        {
            // Arrange
            var velocity = new Vector3(0, 0, 1);
            var rotation = Quaternion.Euler(0, 45, 0);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            var expectedLiftDirection = new Vector3(1, 0, 0).normalized;

            // Act
            var actualLiftDirection = ForceDirectionCalculator.CalculateHorizontalLiftDirection(transform, velocity);

            // Assert
            AssertVectorsAreEqual(expectedLiftDirection, actualLiftDirection);
        }

        [Test]
        public void HorizontalLiftDirectionShouldBeTowardsNegativeXForInvertedAircraftWithFlightPathTowardsZ()
        {
            // Arrange
            var velocity = new Vector3(0, 0, 2);
            var rotation = Quaternion.Euler(0, 0, 180);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            var expectedLiftDirection = new Vector3(-1, 0, 0);

            // Act
            var actualLiftDirection = ForceDirectionCalculator.CalculateHorizontalLiftDirection(transform, velocity);

            // Assert
            AssertVectorsAreEqual(expectedLiftDirection, actualLiftDirection);
        }
        #endregion

        [Test]
        public void LinearDragDirectionShouldBeOppositeOfVelocityDirection()
        {
            // Arrange
            var velocity = new Vector3(2, 3, 6);
            var expectedDirection = new Vector3(-2, -3, -6) / 7;

            // Act
            var actualDirection = ForceDirectionCalculator.CalculateLinearDragDirection(velocity);

            // Assert
            AssertVectorsAreEqual(expectedDirection, actualDirection);
        }

        [Test]
        public void AngularDragDirectionShouldBeOppositeOfAngularVelocityDirection()
        {
            // Arrange
            var angularVelocity = new Vector3(2, 3, 6);
            var expectedDirection = new Vector3(-2, -3, -6) / 7;

            // Act
            var actualDirection = ForceDirectionCalculator.CalculateAngularDragDirection(angularVelocity);

            // Assert
            AssertVectorsAreEqual(expectedDirection, actualDirection);
        }

        private static void AssertVectorsAreEqual(Vector3 expected, Vector3 actual)
        {
            Assert.AreEqual(expected.x, actual.x, TestHelpers.DefaultTolerance);
            Assert.AreEqual(expected.y, actual.y, TestHelpers.DefaultTolerance);
            Assert.AreEqual(expected.z, actual.z, TestHelpers.DefaultTolerance);
        }
    }
}
