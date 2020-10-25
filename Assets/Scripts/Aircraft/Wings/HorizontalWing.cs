using Aircraft;
using Core.Physics.Calculators;
using UnityEngine;

namespace Aircraft.Wings
{
    public class HorizontalWing : Aerofoil
    {
        protected override Vector3 SurfaceNormal => transform.up;

        [SerializeField] private bool subjectToDownwash;
        private float angleOfIncidence;

        protected override void Awake()
        {
            angleOfIncidence = AngleCalculator.CalculateAngleOfIncidence(transform);
            if (subjectToDownwash)
                angleOfIncidence -= 3;

            base.Awake();
        }

        public override Vector3 CalculateForce(AircraftState currentAircraftState)
        {
            var angleOfAttack = currentAircraftState.AngleOfAttack + angleOfIncidence;

            var lift = CalculateLift(angleOfAttack, currentAircraftState.DynamicPressure) * currentAircraftState.VerticalLiftDirection;
            var linearDrag = CalculateDrag(angleOfAttack, currentAircraftState.DynamicPressure) * currentAircraftState.DragDirection;
            var angularDrag = CalculateAngularDrag(currentAircraftState.LocalAngularVelocity) * currentAircraftState.AngularDragDirection;

            return lift + linearDrag + angularDrag;
        }
    }
}
