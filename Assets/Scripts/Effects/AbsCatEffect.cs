using UnityEngine;
using System.Collections;

public abstract class AbsCatEffect : AbsEffect
{
    protected override void Effect(Collider2D obj)
    {
        Cat cat = obj.GetComponent<Cat>();
        if (cat != null)
        {
            CatEffect(cat);
        }
    }

    protected abstract void CatEffect(Cat cat);
}
