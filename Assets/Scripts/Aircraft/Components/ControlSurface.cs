using Aircraft.Interfaces;
using Aircraft.Specifications;
using Core.Physics.Dynamics;
using UnityEngine;

namespace Aircraft.Components
{
    public class ControlSurface : MonoBehaviour, IRespondToInput, IGenerateForce
    {
        [SerializeField] private ControlSurfaceSpecification specification;

        public InputKey InputKey => specification.InputKey;
        public Vector3 Position => transform.position;

        private float currentAngle;

        public void Respond(float inputValue)
        {
            var wantedAngle = specification.MaxAngle * inputValue;
            
            currentAngle = Mathf.Lerp(currentAngle, wantedAngle, Time.deltaTime * specification.RotationSpeed);
            transform.localRotation = Quaternion.Euler(currentAngle * specification.LocalRotationAxis);
        }

        public Vector3 CalculateForce(AircraftState currentAircraftState)
        {
            var forceCoefficient = Aerodynamics.CalculateFlatPlateLiftCoefficient(currentAngle);
            var force = Aerodynamics.CalculateAerodynamicForce(currentAircraftState.DynamicPressure, specification.SurfaceArea, forceCoefficient);

            return force * transform.TransformDirection(specification.SurfaceNormal);
        }
    }
}