using Aircraft.Specifications;
using Core.Physics.Dynamics;
using UnityEngine;

namespace Aircraft.Engines
{
    public class PistonEngine : BaseEngine
    {
        [SerializeField] private PistonEngineSpecification engineSpec;
        [SerializeField] private PropellerSpecification propellerSpec;

        private float currentTorque;
        private float currentRevsPerSecond;

        private void Start()
        {
            currentRevsPerSecond = engineSpec.MinRpm * PistonEnginePhysics.Rpm2Rps;
        }
        
        public override Vector3 CalculateForce(AircraftState currentAircraftState)
        {
            var advanceRatio = PropellerPhysics.CalculateAdvanceRatio(currentAircraftState.RelativeAirSpeed, currentRevsPerSecond, propellerSpec.Diameter);

            currentRevsPerSecond = CalculateNewRevsPerSecond(advanceRatio);

            var thrust = PropellerPhysics.CalculateThrust(propellerSpec, advanceRatio, currentTorque, currentAircraftState.RelativeAirSpeed, Aerodynamics.AirDensity, currentRevsPerSecond);
            
            return thrust * transform.forward;
        }

        private float CalculateNewRevsPerSecond(float advanceRatio)
        {
            var currentRpm = currentRevsPerSecond * PistonEnginePhysics.Rps2Rpm;
            
            var engineTorque = ThrottlePosition * PistonEnginePhysics.CalculateTorque(engineSpec, currentRpm);
            var propDragTorque = PropellerPhysics.CalculateDragTorque(propellerSpec, advanceRatio, Aerodynamics.AirDensity, currentRevsPerSecond);
            currentTorque = engineTorque - propDragTorque;

            var newRpm = PistonEnginePhysics.CalculateRpm(currentRpm, currentTorque, propellerSpec.MomentOfInertia, Time.deltaTime);

            return Mathf.Clamp(newRpm, engineSpec.MinRpm, engineSpec.MaxRpm) * PistonEnginePhysics.Rpm2Rps;
        }
    }
}