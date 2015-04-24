using System;
using Random = UnityEngine.Random;

[Serializable]
public class IntRange
{
    public int min;
    public int max;

    public IntRange(int minimum, int maximum)
    {
        min = minimum;
        max = maximum;
    }

    public int random()
    {
        return Random.Range(min, max);
    }
}