using Aircraft.Interfaces;
using Aircraft.Specifications;
using Core.Physics;
using Core.Physics.Dynamics;
using UnityEngine;

namespace Aircraft.Wings
{
    public abstract class Aerofoil : MonoBehaviour, IGenerateForce
    {
        [SerializeField] private AerofoilSpecification wingSpec;

        private float wingArea;
        private float distanceFromCentre;

        public Vector3 Position => transform.position;
        protected abstract Vector3 SurfaceNormal { get; }

        protected virtual void Awake()
        {
            wingArea = wingSpec.ChordLength * wingSpec.Span;

            var com = GetComponentInParent<Rigidbody>().worldCenterOfMass;
            distanceFromCentre = (com - transform.position).magnitude;
        }

        public abstract Vector3 CalculateForce(AircraftState currentAircraftState);

        protected float CalculateLift(float angleOfAttack, float dynamicPressure)
        {
            var liftCoefficient = wingSpec.GetLiftCoefficient(angleOfAttack);
            return Aerodynamics.CalculateAerodynamicForce(dynamicPressure, wingArea, liftCoefficient);
        }

        protected float CalculateDrag(float angleOfAttack, float dynamicPressure)
        {
            var dragCoefficient = wingSpec.GetDragCoefficient(angleOfAttack);
            return Aerodynamics.CalculateAerodynamicForce(dynamicPressure, wingArea, dragCoefficient);
        }

        protected float CalculateAngularDrag(Vector3 localAngularVelocity)
        {
            return Aerodynamics.CalculateFlatPlateAngularDrag(localAngularVelocity, SurfaceNormal, distanceFromCentre, wingArea, Aerodynamics.AirDensity, Aerodynamics.FlatPlateDragCoefficient);
        }
    }
}
