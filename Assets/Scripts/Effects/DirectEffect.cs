using UnityEngine;
using System.Collections;
using Ramdom = UnityEngine.Random;

public class DirectEffect : AbsCatEffect
{
    public Vector3 destination;

    protected override void CatEffect(Cat cat)
    {
        if (destination != null)
        {
            cat.StopAction();
            cat.Move(
                destination + (Vector3)Random.insideUnitCircle,
                cat.speedRange.random()
            );
        }
    }
}
