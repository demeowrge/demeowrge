using System;
using Random = UnityEngine.Random;

namespace Utility {
    [Serializable]
    public class FloatRange {
        public float min;
        public float max;

        public FloatRange(float minimum, float maximum)
        {
            min = minimum;
            max = maximum;
        }

        public float random()
        {
            return Random.Range(min, max);
        }
    }
}