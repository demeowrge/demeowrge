using UnityEngine;
using System.Collections;

public class ProselytizeEffect : AbsCatEffect
{
    protected override void CatEffect(Cat cat)
    {
        cat.Proselytize();
    }
}
