using UnityEngine;
using System.Collections;

public class FearEffect : AbsCatEffect
{
    public FloatRange fearRange;

    protected override void CatEffect(Cat cat)
    {
        cat.StopAction();
        cat.Move(
            (cat.transform.position - transform.position) * fearRange.random(),
            cat.speedRange.max * 2
        );
    }
}
