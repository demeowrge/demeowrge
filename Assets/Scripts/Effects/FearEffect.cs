using UnityEngine;
using System.Collections;

public class FearEffect : AbsCatEffect
{
    public FloatRange fearRange;

    protected override void CatEffect(Cat cat)
    {
        cat.Move(
            (cat.transform.position - transform.position) * fearRange.random(),
            cat.SpeedRange.max * 2
        );
    }
}
