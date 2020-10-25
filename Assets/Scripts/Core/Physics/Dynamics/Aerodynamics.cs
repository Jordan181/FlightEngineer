using UnityEngine;

namespace Core.Physics.Dynamics
{
    public static class Aerodynamics
    {
        public const float AirDensity = 0.9f;
        public const float FlatPlateDragCoefficient = 2f;

        public static float CalculateRelativeAirSpeed(Vector3 bodyVelocity, Vector3 windVelocity)
        {
            return (bodyVelocity - windVelocity).magnitude;
        }

        public static float CalculateDynamicPressure(float airDensity, float relativeAirSpeed)
        {
            return 0.5f * airDensity * relativeAirSpeed * relativeAirSpeed;
        }

        public static float CalculateAerodynamicForce(float dynamicPressure, float characteristicArea, float dimensionlessCoefficient)
        {
             return dynamicPressure * characteristicArea * dimensionlessCoefficient;
        }
        
        public static float CalculateFlatPlateAngularDrag(Vector3 angularVelocity, Vector3 surfaceNormal, float distanceFromPivot, float surfaceArea, float airDensity, float dragCoefficient)
        {
            var inPlaneAngularVelocity = Vector3.ProjectOnPlane(angularVelocity, surfaceNormal);

            var tangentialSpeed = inPlaneAngularVelocity.magnitude * distanceFromPivot;
            var tangentialDynamicPressure = CalculateDynamicPressure(airDensity, tangentialSpeed);
            
            return CalculateAerodynamicForce(tangentialDynamicPressure, surfaceArea, dragCoefficient);
        }

        public static float CalculateFlatPlateLiftCoefficient(float angleOfAttack)
        {
            return 2 * Mathf.PI * angleOfAttack * Mathf.Deg2Rad;
        }
    }
}
