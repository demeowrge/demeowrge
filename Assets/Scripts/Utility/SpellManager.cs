using UnityEngine;
using System.Collections;

public class SpellManager : MonoBehaviour
{

    public static GameObject LightningSpell;
    public GameObject LightningSpellObject;

    public static GameObject ProphetSpell;
    public GameObject ProphetSpellObject;
    // Use this for initialization
    void Start()
    {
        LightningSpell = LightningSpellObject;
        ProphetSpell = ProphetSpellObject;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
