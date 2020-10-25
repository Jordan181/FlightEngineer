using Core.Maths;
using NUnit.Framework;
using UnityEngine;

namespace TestCore.Maths
{
    public class TestIntegration
    {
        [Test]
        public void EulerStepShouldBeCalculatedCorrectlyForPositiveGradient()
        {
            // Arrange
            const float currentValue = 1;
            const float gradient = 2;
            const float step = 0.1f;

            const float expectedNextValue = 1.2f;

            // Act
            var actualNextValue = Integration.EulerStep(currentValue, gradient, step);

            // Assert
            Assert.IsTrue(Mathf.Approximately(expectedNextValue, actualNextValue));
        }

        [Test]
        public void EulerStepShouldBeCalculatedCorrectlyForNegativeGradient()
        {
            // Arrange
            const float currentValue = 1;
            const float gradient = -2;
            const float step = 0.1f;

            const float expectedNextValue = 0.8f;

            // Act
            var actualNextValue = Integration.EulerStep(currentValue, gradient, step);

            // Assert
            Assert.IsTrue(Mathf.Approximately(expectedNextValue, actualNextValue));
        }

        [Test]
        public void EulerStepShouldBeReturnCurrentValueFor0Gradient()
        {
            // Arrange
            const float currentValue = 1;
            const float gradient = 0;
            const float step = 0.1f;

            const float expectedNextValue = currentValue;

            // Act
            var actualNextValue = Integration.EulerStep(currentValue, gradient, step);

            // Assert
            Assert.IsTrue(Mathf.Approximately(expectedNextValue, actualNextValue));
        }

        [Test]
        public void EulerStepShouldBeReturnCurrentValueFor0Step()
        {
            // Arrange
            const float currentValue = 1;
            const float gradient = 2;
            const float step = 0;

            const float expectedNextValue = currentValue;

            // Act
            var actualNextValue = Integration.EulerStep(currentValue, gradient, step);

            // Assert
            Assert.IsTrue(Mathf.Approximately(expectedNextValue, actualNextValue));
        }
    }
}
