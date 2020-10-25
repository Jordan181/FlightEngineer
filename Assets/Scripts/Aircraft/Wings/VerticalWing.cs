using UnityEngine;

namespace Aircraft.Wings
{
    public class VerticalWing : Aerofoil
    {
        protected override Vector3 SurfaceNormal => transform.right;

        public override Vector3 CalculateForce(AircraftState currentAircraftState)
        {
            var lift = CalculateLift(currentAircraftState.YawAngle, currentAircraftState.DynamicPressure) * currentAircraftState.HorizontalLiftDirection;
            var linearDrag = CalculateDrag(currentAircraftState.YawAngle, currentAircraftState.DynamicPressure) * currentAircraftState.DragDirection;
            var angularDrag = CalculateAngularDrag(currentAircraftState.LocalAngularVelocity) * currentAircraftState.AngularDragDirection;

            return lift + linearDrag + angularDrag;
        }
    }
}
