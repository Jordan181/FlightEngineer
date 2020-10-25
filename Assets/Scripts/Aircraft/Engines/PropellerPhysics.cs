using Aircraft.Specifications;
using UnityEngine;

namespace Aircraft.Engines
{
    public static class PropellerPhysics
    {
        public static float CalculateAdvanceRatio(float airSpeed, float revsPerSecond, float diameter)
        {
            if (revsPerSecond < 1e-8 || diameter < 1e-8)
                return 0f;

            return airSpeed / (revsPerSecond * diameter);
        }

        public static float CalculateThrust(PropellerSpecification propellerSpec, float advanceRatio, float currentTorque, float airSpeed, float airDensity, float revsPerSecond)
        {
            const float criticalSpeed = 0.5f;

            var thrustCoefficient = propellerSpec.DynamicThrustCoefficient.Evaluate(advanceRatio);
            var dynamicThrust = CalculateDynamicThrust(thrustCoefficient, airDensity, revsPerSecond, Mathf.Pow(propellerSpec.Diameter, 4));

            if (airSpeed < criticalSpeed && currentTorque > 0)
            {
                var staticThrust = CalculateStaticThrust(propellerSpec.StaticThrustCoefficient, currentTorque, propellerSpec.Diameter);
                var interpolant = Mathf.InverseLerp(0, criticalSpeed, airSpeed);
                return Mathf.Lerp(staticThrust, dynamicThrust, interpolant);
            }
            
            return dynamicThrust;
        }

        public static float CalculateDragTorque(PropellerSpecification propellerSpec, float advanceRatio, float airDensity, float revsPerSecond)
        {
            var torqueCoefficient = propellerSpec.TorqueCoefficient.Evaluate(advanceRatio);
            return torqueCoefficient * airDensity * revsPerSecond * revsPerSecond * Mathf.Pow(propellerSpec.Diameter, 5);
        }

        private static float CalculateStaticThrust(float staticThrustCoefficient, float currentTorque, float propellerDiameter)
        {
            return staticThrustCoefficient * 2 * Mathf.PI * currentTorque / propellerDiameter;
        }

        private static float CalculateDynamicThrust(float dynamicThrustCoefficient, float airDensity, float revsPerSecond, float diameterToThe4)
        {
            return dynamicThrustCoefficient * airDensity * revsPerSecond * revsPerSecond * diameterToThe4;
        }
    }
}
