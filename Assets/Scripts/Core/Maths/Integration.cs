namespace Core.Maths
{
    public static class Integration
    {
        public static float EulerStep(float currentValue, float gradient, float stepSize)
        {
            return currentValue + gradient * stepSize;
        }
    }
}
