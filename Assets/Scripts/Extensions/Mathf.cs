namespace Extensions
{
    public class Mathf
    {
        public static bool Approximately(float a, float b, float precision)
        {
            return UnityEngine.Mathf.Abs(a - b) < precision;
        }
    }
}
