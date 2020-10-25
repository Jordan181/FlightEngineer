using Core.Physics.Calculators;
using NUnit.Framework;
using UnityEngine;

namespace TestCore.Physics.Calculators
{
    public class TestAngleCalculator
    {
        #region Angle Of Attack Tests

        [Test]
        public void AngleOfAttackShouldBeCorrectForInclinedAircraftWithLevelFlightPathTowardsZ()
        {
            // Arrange
            var rotation = Quaternion.Euler(-15, 0, 0);
            var velocity = new Vector3(0, 0, 1);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            const float expectedAngleOfAttack = 15f;

            // Act
            var actualAngleOfAttack = AngleCalculator.CalculateAngleOfAttack(transform, velocity);

            // Assert
            Assert.AreEqual(expectedAngleOfAttack, actualAngleOfAttack, TestHelpers.DefaultTolerance);
        }

        [Test]
        public void AngleOfAttackShouldBeCorrectForDeclinedAircraftWithLevelFlightPathTowardsZ()
        {
            // Arrange
            var rotation = Quaternion.Euler(15, 0, 0);
            var velocity = new Vector3(0, 0, 1);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            const float expectedAngleOfAttack = -15f;

            // Act
            var actualAngleOfAttack = AngleCalculator.CalculateAngleOfAttack(transform, velocity);

            // Assert
            Assert.AreEqual(expectedAngleOfAttack, actualAngleOfAttack, TestHelpers.DefaultTolerance);
        }

        [Test]
        public void AngleOfAttackShouldBeCorrectForLevelAircraftWithLevelFlightPathTowardsZ()
        {
            // Arrange
            var rotation = Quaternion.Euler(0, 0, 0);
            var velocity = new Vector3(0, 0, 1);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            const float expectedAngleOfAttack = 0f;

            // Act
            var actualAngleOfAttack = AngleCalculator.CalculateAngleOfAttack(transform, velocity);

            // Assert
            Assert.AreEqual(expectedAngleOfAttack, actualAngleOfAttack, TestHelpers.DefaultTolerance);
        }

        [Test]
        public void AngleOfAttackShouldBeCorrectForLevelAircraftWithInclinedFlightPathTowardsZ()
        {
            // Arrange
            var rotation = Quaternion.Euler(0, 0, 0);
            var velocity = new Vector3(0, 1, 2);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            const float expectedAngleOfAttack = -26.56505118f;

            // Act
            var actualAngleOfAttack = AngleCalculator.CalculateAngleOfAttack(transform, velocity);

            // Assert
            Assert.AreEqual(expectedAngleOfAttack, actualAngleOfAttack, TestHelpers.DefaultTolerance);
        }

        [Test]
        public void AngleOfAttackShouldBeCorrectForLevelAircraftWithDeclinedFlightPathTowardsZ()
        {
            // Arrange
            var rotation = Quaternion.Euler(0, 0, 0);
            var velocity = new Vector3(0, -1, 1);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            const float expectedAngleOfAttack = 45f;

            // Act
            var actualAngleOfAttack = AngleCalculator.CalculateAngleOfAttack(transform, velocity);

            // Assert
            Assert.AreEqual(expectedAngleOfAttack, actualAngleOfAttack, TestHelpers.DefaultTolerance);
        }

        [Test]
        public void AngleOfAttackShouldBeCorrectForInclinedAircraftWithLevelFlightPathTowardsX()
        {
            // Arrange
            var rotation = Quaternion.Euler(-15, 90, 0);
            var velocity = new Vector3(1, 0, 0);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            const float expectedAngleOfAttack = 15f;

            // Act
            var actualAngleOfAttack = AngleCalculator.CalculateAngleOfAttack(transform, velocity);

            // Assert
            Assert.AreEqual(expectedAngleOfAttack, actualAngleOfAttack, TestHelpers.DefaultTolerance);
        }

        [Test]
        public void AngleOfAttackShouldBeCorrectForInclinedAircraftWithLevelFlightPathTowardsY()
        {
            // Arrange
            var rotation = Quaternion.Euler(-105, 0, 0);
            var velocity = new Vector3(0, 1, 0);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            const float expectedAngleOfAttack = 15f;

            // Act
            var actualAngleOfAttack = AngleCalculator.CalculateAngleOfAttack(transform, velocity);

            // Assert
            Assert.AreEqual(expectedAngleOfAttack, actualAngleOfAttack, TestHelpers.DefaultTolerance);
        }

        [Test]
        public void AngleOfAttackShouldBeCorrectForInvertedInclinedAircraftWithLevelFlightPathTowardsY()
        {
            // Arrange
            var rotation = Quaternion.Euler(-105, 0, 180);
            var velocity = new Vector3(0, 1, 0);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            const float expectedAngleOfAttack = -15f;

            // Act
            var actualAngleOfAttack = AngleCalculator.CalculateAngleOfAttack(transform, velocity);

            // Assert
            Assert.AreEqual(expectedAngleOfAttack, actualAngleOfAttack, TestHelpers.DefaultTolerance);
        }

        [Test]
        public void AngleOfAttackShouldBeCorrectForDeclinedAircraftWithLevelFlightPathTowardsY()
        {
            // Arrange
            var rotation = Quaternion.Euler(-75, 0, 0);
            var velocity = new Vector3(0, 1, 0);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            const float expectedAngleOfAttack = -15f;

            // Act
            var actualAngleOfAttack = AngleCalculator.CalculateAngleOfAttack(transform, velocity);

            // Assert
            Assert.AreEqual(expectedAngleOfAttack, actualAngleOfAttack, TestHelpers.DefaultTolerance);
        }

        [Test]
        public void AngleOfAttackShouldBeCorrectForInvertedDeclinedAircraftWithLevelFlightPathTowardsY()
        {
            // Arrange
            var rotation = Quaternion.Euler(-75, 0, 180);
            var velocity = new Vector3(0, 1, 0);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            const float expectedAngleOfAttack = 15f;

            // Act
            var actualAngleOfAttack = AngleCalculator.CalculateAngleOfAttack(transform, velocity);

            // Assert
            Assert.AreEqual(expectedAngleOfAttack, actualAngleOfAttack, TestHelpers.DefaultTolerance);
        }

        [Test]
        public void AngleOfAttackShouldBeCorrectForInclinedAircraftWithHLevelFlightPathTowardsNegativeZ()
        {
            // Arrange
            var rotation = Quaternion.Euler(-15, 180, 0);
            var velocity = new Vector3(0, 0, -1);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            const float expectedAngleOfAttack = 15f;

            // Act
            var actualAngleOfAttack = AngleCalculator.CalculateAngleOfAttack(transform, velocity);

            // Assert
            Assert.AreEqual(expectedAngleOfAttack, actualAngleOfAttack, TestHelpers.DefaultTolerance);
        }

        [Test]
        public void AngleOfAttackShouldBeCorrectForInclinedInvertedAircraftWithLevelFlightPathTowardsZ()
        {
            // Arrange
            var rotation = Quaternion.Euler(-15, 0, 180);
            var velocity = new Vector3(0, 0, 1);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            const float expectedAngleOfAttack = -15f;

            // Act
            var actualAngleOfAttack = AngleCalculator.CalculateAngleOfAttack(transform, velocity);

            // Assert
            Assert.AreEqual(expectedAngleOfAttack, actualAngleOfAttack, TestHelpers.DefaultTolerance);
        }

        [Test]
        public void AngleOfAttackShouldBeCorrectForInclinedSidewaysAircraftWithLocalXUpAndLevelFlightPathTowardsZ()
        {
            // Arrange
            var rotation = Quaternion.Euler(0, -15, 90);
            var velocity = new Vector3(0, 0, 1);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            const float expectedAngleOfAttack = 15f;

            // Act
            var actualAngleOfAttack = AngleCalculator.CalculateAngleOfAttack(transform, velocity);

            // Assert
            Assert.AreEqual(expectedAngleOfAttack, actualAngleOfAttack, TestHelpers.DefaultTolerance);
        }

        [Test]
        public void AngleOfAttackShouldBeCorrectForDeclinedSidewaysAircraftWithLocalXUpAndLevelFlightPathTowardsZ()
        {
            // Arrange
            var rotation = Quaternion.Euler(0, 15, 90);
            var velocity = new Vector3(0, 0, 1);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            const float expectedAngleOfAttack = -15f;

            // Act
            var actualAngleOfAttack = AngleCalculator.CalculateAngleOfAttack(transform, velocity);

            // Assert
            Assert.AreEqual(expectedAngleOfAttack, actualAngleOfAttack, TestHelpers.DefaultTolerance);
        }

        [Test]
        public void AngleOfAttackShouldBeCorrectForInclinedSidewaysAircraftWithLocalXDownAndLevelFlightPathTowardsZ()
        {
            // Arrange
            var rotation = Quaternion.Euler(0, 15, -90);
            var velocity = new Vector3(0, 0, 1);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            const float expectedAngleOfAttack = 15f;

            // Act
            var actualAngleOfAttack = AngleCalculator.CalculateAngleOfAttack(transform, velocity);

            // Assert
            Assert.AreEqual(expectedAngleOfAttack, actualAngleOfAttack, TestHelpers.DefaultTolerance);
        }

        [Test]
        public void AngleOfAttackShouldBeCorrectForDeclinedSidewaysAircraftWithLocalXDownAndLevelFlightPathTowardsZ()
        {
            // Arrange
            var rotation = Quaternion.Euler(0, -15, -90);
            var velocity = new Vector3(0, 0, 1);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            const float expectedAngleOfAttack = -15f;

            // Act
            var actualAngleOfAttack = AngleCalculator.CalculateAngleOfAttack(transform, velocity);

            // Assert
            Assert.AreEqual(expectedAngleOfAttack, actualAngleOfAttack, TestHelpers.DefaultTolerance);
        }

        [Test]
        public void AngleOfAttackShouldBeCorrectForInclinedSidewaysAircraftWithLevelFlightPathTowardsX()
        {
            // Arrange
            var rotation = Quaternion.Euler(0, 105, -90);
            var velocity = new Vector3(1, 0, 0);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            const float expectedAngleOfAttack = 15f;

            // Act
            var actualAngleOfAttack = AngleCalculator.CalculateAngleOfAttack(transform, velocity);

            // Assert
            Assert.AreEqual(expectedAngleOfAttack, actualAngleOfAttack, TestHelpers.DefaultTolerance);
        }

        [Test]
        public void AngleOfAttackShouldBeCorrectForDeclinedSidewaysAircraftWithLevelFlightPathTowardsX()
        {
            // Arrange
            var rotation = Quaternion.Euler(0, 75, -90);
            var velocity = new Vector3(1, 0, 0);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            const float expectedAngleOfAttack = -15f;

            // Act
            var actualAngleOfAttack = AngleCalculator.CalculateAngleOfAttack(transform, velocity);

            // Assert
            Assert.AreEqual(expectedAngleOfAttack, actualAngleOfAttack, TestHelpers.DefaultTolerance);
        }

        [Test]
        public void AngleOfAttackShouldBe0ForInclinedAircraftIntoDirectionOfVelocity()
        {
            // Arrange
            var rotation = Quaternion.Euler(-45, 0, 0);
            var velocity = new Vector3(0, 1, 1);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            const float expectedAngleOfAttack = 0f;

            // Act
            var actualAngleOfAttack = AngleCalculator.CalculateAngleOfAttack(transform, velocity);

            // Assert
            Assert.AreEqual(expectedAngleOfAttack, actualAngleOfAttack, TestHelpers.DefaultTolerance);
        }

        [Test]
        public void AngleOfAttackShouldBeCorrectForInvertedInclinedAircraftWithFlightPathTowardsX()
        {
            // Arrange
            var rotation = Quaternion.Euler(-15, 90, 180);
            var velocity = new Vector3(1, 0, 0);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            const float expectedAngleOfAttack = -15f;

            // Act
            var actualAngleOfAttack = AngleCalculator.CalculateAngleOfAttack(transform, velocity);

            // Assert
            Assert.AreEqual(expectedAngleOfAttack, actualAngleOfAttack, TestHelpers.DefaultTolerance);
        }

        #endregion

        #region Yaw Angle Tests

        [Test]
        public void YawAngleShouldBeCorrectWhenTurnedRightWithFlightPathTowardsZ()
        {
            // Arrange
            var rotation = Quaternion.Euler(0, 15, 0);
            var velocity = new Vector3(0, 0, 1);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            const float expectedYawAngle = 15f;

            // Act
            var actualYawAngle = AngleCalculator.CalculateYawAngle(transform, velocity);

            // Assert
            Assert.AreEqual(expectedYawAngle, actualYawAngle, TestHelpers.DefaultTolerance);
        }

        [Test]
        public void YawAngleShouldBeCorrectWhenTurnedLeftWithFlightPathTowardsZ()
        {
            // Arrange
            var rotation = Quaternion.Euler(0, -15, 0);
            var velocity = new Vector3(0, 0, 1);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            const float expectedYawAngle = -15f;

            // Act
            var actualYawAngle = AngleCalculator.CalculateYawAngle(transform, velocity);

            // Assert
            Assert.AreEqual(expectedYawAngle, actualYawAngle, TestHelpers.DefaultTolerance);
        }

        [Test]
        public void YawAngleShouldBe0WhenTurnedLeftIntoDirectionOfVelocity()
        {
            // Arrange
            var rotation = Quaternion.Euler(0, 45, 0);
            var velocity = new Vector3(1, 0, 1);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            const float expectedYawAngle = 0f;

            // Act
            var actualYawAngle = AngleCalculator.CalculateYawAngle(transform, velocity);

            // Assert
            Assert.AreEqual(expectedYawAngle, actualYawAngle, TestHelpers.DefaultTolerance);
        }

        [Test]
        public void YawAngleShouldBeCorrectWhenTurnedRightWithFlightPathTowardsX()
        {
            // Arrange
            var rotation = Quaternion.Euler(0, 105, 0);
            var velocity = new Vector3(1, 0, 0);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            const float expectedYawAngle = 15f;

            // Act
            var actualYawAngle = AngleCalculator.CalculateYawAngle(transform, velocity);

            // Assert
            Assert.AreEqual(expectedYawAngle, actualYawAngle, TestHelpers.DefaultTolerance);
        }

        [Test]
        public void YawAngleShouldBeCorrectWhenTurnedRightWithFlightPathTowardsNegativeZ()
        {
            // Arrange
            var rotation = Quaternion.Euler(0, 195, 0);
            var velocity = new Vector3(0, 0, -1);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            const float expectedYawAngle = 15f;

            // Act
            var actualYawAngle = AngleCalculator.CalculateYawAngle(transform, velocity);

            // Assert
            Assert.AreEqual(expectedYawAngle, actualYawAngle, TestHelpers.DefaultTolerance);
        }

        [Test]
        public void YawAngleShouldBeCorrectForSidewaysAircraftTurnedIntoFlightPathTowardsZ()
        {
            // Arrange
            var rotation = Quaternion.Euler(15, 0, -90);
            var velocity = new Vector3(0, 0, 1);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            const float expectedYawAngle = 15f;

            // Act
            var actualYawAngle = AngleCalculator.CalculateYawAngle(transform, velocity);

            // Assert
            Assert.AreEqual(expectedYawAngle, actualYawAngle, TestHelpers.DefaultTolerance);
        }

        [Test]
        public void YawAngleShouldBeCorrectForAircraftTurnedIntoFlightPathTowardsY()
        {
            // Arrange
            var rotation = Quaternion.Euler(-105, -90, 90);
            var velocity = new Vector3(0, 1, 0);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            const float expectedYawAngle = 15f;

            // Act
            var actualYawAngle = AngleCalculator.CalculateYawAngle(transform, velocity);

            // Assert
            Assert.AreEqual(expectedYawAngle, actualYawAngle, TestHelpers.DefaultTolerance);
        }

        [Test]
        public void YawAngleShouldBeCorrectForInvertedAircraftTurnedIntoFlightPathTowardsZ()
        {
            // Arrange
            var rotation = Quaternion.Euler(0, 15, 180);
            var velocity = new Vector3(0, 0, 1);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            const float expectedYawAngle = -15f;

            // Act
            var actualYawAngle = AngleCalculator.CalculateYawAngle(transform, velocity);

            // Assert
            Assert.AreEqual(expectedYawAngle, actualYawAngle, TestHelpers.DefaultTolerance);
        }
        #endregion

        #region Angle Of Incidence Tests

        [Test]
        public void IncidenceAngleShouldBeZeroIfWingAndPlaneBodyAreHorizontal()
        {
            // Arrange
            var parentRotation = Quaternion.Euler(0, 0, 0);
            var parentTransform = TestHelpers.CreateGameObject(parentRotation).transform;

            var rotation = Quaternion.Euler(0, 0, 0);
            var transform = TestHelpers.CreateGameObject(rotation).transform;
            transform.parent = parentTransform;

            const float expectedIncidenceAngle = 0;

            // Act
            var actualIncidenceAngle = AngleCalculator.CalculateAngleOfIncidence(transform);

            // Assert
            Assert.AreEqual(expectedIncidenceAngle, actualIncidenceAngle, TestHelpers.DefaultTolerance);
        }

        [Test]
        public void IncidenceAngleShouldBeZeroIfWingAndPlaneBodyAreAtTheSameAngle()
        {
            // Arrange
            var parentRotation = Quaternion.Euler(-15, 0, 0);
            var parentTransform = TestHelpers.CreateGameObject(parentRotation).transform;

            var rotation = Quaternion.Euler(-15, 0, 0);
            var transform = TestHelpers.CreateGameObject(rotation).transform;
            transform.parent = parentTransform;

            const float expectedIncidenceAngle = 0;

            // Act
            var actualIncidenceAngle = AngleCalculator.CalculateAngleOfIncidence(transform);

            // Assert
            Assert.AreEqual(expectedIncidenceAngle, actualIncidenceAngle, TestHelpers.DefaultTolerance);
        }

        [Test]
        public void IncidenceAngleShouldBePositiveIfWingIsInclinedRelativeToPlaneBody()
        {
            // Arrange
            var parentRotation = Quaternion.Euler(0, 0, 0);
            var parentTransform = TestHelpers.CreateGameObject(parentRotation).transform;

            var rotation = Quaternion.Euler(-5, 0, 0);
            var transform = TestHelpers.CreateGameObject(rotation).transform;
            transform.parent = parentTransform;

            const float expectedIncidenceAngle = 5;

            // Act
            var actualIncidenceAngle = AngleCalculator.CalculateAngleOfIncidence(transform);

            // Assert
            Assert.AreEqual(expectedIncidenceAngle, actualIncidenceAngle, 1e-4);
        }

        [Test]
        public void IncidenceAngleShouldBeNegativeIfWingIsDeclinedRelativeToPlaneBody()
        {
            // Arrange
            var parentRotation = Quaternion.Euler(0, 0, 0);
            var parentTransform = TestHelpers.CreateGameObject(parentRotation).transform;

            var rotation = Quaternion.Euler(5, 0, 0);
            var transform = TestHelpers.CreateGameObject(rotation).transform;
            transform.parent = parentTransform;

            const float expectedIncidenceAngle = -5;

            // Act
            var actualIncidenceAngle = AngleCalculator.CalculateAngleOfIncidence(transform);

            // Assert
            Assert.AreEqual(expectedIncidenceAngle, actualIncidenceAngle, 1e-4);
        }

        #endregion

        [Test]
        public void YawAndAttackAnglesShouldBeCorrectForInclinedAircraftTurnedIntoFlightPathTowardsZ()
        {
            // Arrange
            var rotation = Quaternion.Euler(-15, 30, 0);
            var velocity = new Vector3(0, 0, 1);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            const float expectedAttackAngle = 15f;
            const float expectedYawAngle = 30f;

            // Act
            var actualAttackAngle = AngleCalculator.CalculateAngleOfAttack(transform, velocity);
            var actualYawAngle = AngleCalculator.CalculateYawAngle(transform, velocity);

            // Assert
            Assert.AreEqual(expectedAttackAngle, actualAttackAngle, TestHelpers.DefaultTolerance, "Attack");
            Assert.AreEqual(expectedYawAngle, actualYawAngle, TestHelpers.DefaultTolerance, "Yaw");
        }

        [Test]
        public void YawAndAttackAnglesShouldBeCorrectForInvertedDeclinedAircraftTurnedIntoFlightPathTowardsZ()
        {
            // Arrange
            var rotation = Quaternion.Euler(15, 15, 180);
            var velocity = new Vector3(0, 0, 1);
            var transform = TestHelpers.CreateGameObject(rotation).transform;

            const float expectedAttackAngle = 15f;
            const float expectedYawAngle = -15f;

            // Act
            var actualAttackAngle = AngleCalculator.CalculateAngleOfAttack(transform, velocity);
            var actualYawAngle = AngleCalculator.CalculateYawAngle(transform, velocity);

            // Assert
            Assert.AreEqual(expectedAttackAngle, actualAttackAngle, TestHelpers.DefaultTolerance, "Attack");
            Assert.AreEqual(expectedYawAngle, actualYawAngle, TestHelpers.DefaultTolerance, "Yaw");
        }
    }
}
