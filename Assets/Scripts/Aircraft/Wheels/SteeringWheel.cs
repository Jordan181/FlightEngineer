using Aircraft.Interfaces;
using UnityEngine;

namespace Aircraft.Wheels
{
    public class SteeringWheel : BaseWheel
    {
        public override InputKey InputKey => InputKey.Yaw;

        public override void Respond(float inputValue)
        {
            var wantedSteerAngle = -inputValue * WheelSpec.MaximumSteeringAngle;
            var actualSteerAngle = Mathf.LerpAngle(WheelCollider.steerAngle, wantedSteerAngle, Time.deltaTime);
            WheelCollider.steerAngle = actualSteerAngle;
        }
    }
}
