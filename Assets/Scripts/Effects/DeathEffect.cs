using UnityEngine;
using System.Collections;

public class DeathEffect : AbsCatEffect
{
    protected override void CatEffect(Cat cat)
    {
        cat.Death();
    }
}
