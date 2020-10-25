using Aircraft.Specifications;
using Core.Maths;
using Core.Physics.Dynamics;
using UnityEngine;

namespace Aircraft.Engines
{
    public static class PistonEnginePhysics
    {
        public const float Rps2Rpm = 60;
        public const float Rpm2Rps = 0.01666666667f;
        public const float Rads2Rpm = 9.549296586f;

        public static float CalculateTorque(PistonEngineSpecification engineSpec, float currentRpm)
        {
            if (currentRpm < engineSpec.MinRpm || currentRpm > engineSpec.MaxRpm)
                return 0;

            var normalizedRpm = Mathf.InverseLerp(engineSpec.MinRpm, engineSpec.MaxRpm, currentRpm);
            var normalizedTorque = engineSpec.NormalizedTorqueCurve.Evaluate(normalizedRpm);
            return Mathf.Lerp(engineSpec.MinTorque, engineSpec.MaxTorque, normalizedTorque);
        }

        public static float CalculateRpm(float currentRpm, float resultantTorque, float propellerInertia, float dt)
        {
            var angularAcceleration = RotationalDynamics.CalculateAngularAcceleration(resultantTorque, propellerInertia) * Rads2Rpm;
            return Integration.EulerStep(currentRpm, angularAcceleration, dt);
        }
    }
}
