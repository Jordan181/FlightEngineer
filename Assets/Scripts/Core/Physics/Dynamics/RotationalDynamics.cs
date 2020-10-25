namespace Core.Physics.Dynamics
{
    public static class RotationalDynamics
    {
        public static float CalculateAngularAcceleration(float torque, float inertia)
        {
            return torque / inertia;
        }
    }
}
