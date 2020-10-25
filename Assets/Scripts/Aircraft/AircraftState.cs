using Core.Physics.Calculators;
using Core.Physics.Dynamics;
using UnityEngine;

namespace Aircraft
{
    public class AircraftState
    {
        public float AngleOfAttack { get; }
        public float YawAngle { get; }
        public float RelativeAirSpeed { get; }
        public float DynamicPressure { get; }
        public Vector3 LocalAngularVelocity { get; }
        public Vector3 VerticalLiftDirection { get; }
        public Vector3 HorizontalLiftDirection { get; }
        public Vector3 DragDirection { get; }
        public Vector3 AngularDragDirection { get; }

        private AircraftState(
            float angleOfAttack, 
            float yawAngle,
            float relativeAirSpeed, 
            float dynamicPressure, 
            Vector3 localAngularVelocity,
            Vector3 verticalLiftDirection, 
            Vector3 horizontalLiftDirection, 
            Vector3 dragDirection, 
            Vector3 angularDragDirection)
        {
            AngleOfAttack = angleOfAttack;
            YawAngle = yawAngle;
            RelativeAirSpeed = relativeAirSpeed;
            DynamicPressure = dynamicPressure;
            LocalAngularVelocity = localAngularVelocity;
            VerticalLiftDirection = verticalLiftDirection;
            HorizontalLiftDirection = horizontalLiftDirection;
            DragDirection = dragDirection;
            AngularDragDirection = angularDragDirection;
        }

        public static AircraftState Capture(Transform transform, Vector3 velocity, Vector3 angularVelocity)
        {
            var localAngularVelocity = transform.InverseTransformDirection(angularVelocity);

            var angleOfAttack = AngleCalculator.CalculateAngleOfAttack(transform, velocity);
            var yawAngle = AngleCalculator.CalculateYawAngle(transform, velocity);

            var relativeAirSpeed = Aerodynamics.CalculateRelativeAirSpeed(velocity, Vector3.zero);
            var dynamicPressure = Aerodynamics.CalculateDynamicPressure(Aerodynamics.AirDensity, relativeAirSpeed);
            
            var verticalLiftDirection = ForceDirectionCalculator.CalculateVerticalLiftDirection(transform, velocity);
            var horizontalLiftDirection = ForceDirectionCalculator.CalculateHorizontalLiftDirection(transform, velocity);
            var dragDirection = ForceDirectionCalculator.CalculateLinearDragDirection(velocity);
            var angularDragDirection = ForceDirectionCalculator.CalculateAngularDragDirection(angularVelocity);

            return new AircraftState(
                angleOfAttack, 
                yawAngle,
                relativeAirSpeed,
                dynamicPressure, 
                localAngularVelocity,
                verticalLiftDirection,
                horizontalLiftDirection,
                dragDirection,
                angularDragDirection);
        }
    }
}
