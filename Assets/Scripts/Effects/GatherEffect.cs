using UnityEngine;
using System.Collections;
using Ramdom = UnityEngine.Random;

public class GatherEffect : AbsCatEffect
{
    protected override void CatEffect(Cat cat)
    {
        cat.Move(
            transform.position + (Vector3) Random.insideUnitCircle,
            cat.SpeedRange.random()
        );
    }
}
