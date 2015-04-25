﻿using UnityEngine;
using System.Collections;

public class SpellManager : MonoBehaviour
{
    public static GameObject ProphetSpell;
    public GameObject ProphetSpellObject;

    public static GameObject DirectSpell;
    public GameObject DirectSpellObject;

    public static GameObject FishSpell;
    public GameObject FishSpellObject;

    public static GameObject LightningSpell;
    public GameObject LightningSpellObject;


    void Start()
    {
        ProphetSpell = ProphetSpellObject;
        DirectSpell = DirectSpellObject;
        FishSpell = FishSpellObject;
        LightningSpell = LightningSpellObject;
    }
}
