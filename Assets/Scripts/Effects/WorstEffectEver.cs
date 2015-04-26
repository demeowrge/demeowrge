using UnityEngine;
using System.Collections;

public class WorstEffectEver : AbsCatEffect
{
    public bool chased = false;
    public GameObject BadCat;

    protected override void CatEffect(Cat cat)
    {
        chased = true;

        Vector3 position = cat.transform.position;
        Destroy(cat.gameObject);
        Instantiate(BadCat, position, Quaternion.identity);
    }
}
