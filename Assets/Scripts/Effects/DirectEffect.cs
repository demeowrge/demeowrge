﻿using UnityEngine;
using System.Collections;
using Ramdom = UnityEngine.Random;

public class DirectEffect : AbsCatEffect
{
    public Vector3 destination;

    protected override void CatEffect(Cat cat)
    {
        cat.Move(
            destination + (Vector3)Random.insideUnitCircle,
            cat.SpeedRange.random()
        );
    }
}
