using Aircraft.Interfaces;

namespace Aircraft.Wheels
{
    public class BrakingWheel : BaseWheel
    {
        public override InputKey InputKey => InputKey.Brakes;

        public override void Respond(float inputValue)
        {
            WheelCollider.brakeTorque = inputValue * WheelSpec.MaximumBrakingForce;
        }
    }
}
