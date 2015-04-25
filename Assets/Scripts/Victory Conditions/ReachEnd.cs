using UnityEngine;
using System.Collections;

public class ReachEnd : VictoryCondition
{
    public int NeededCats;
    public int FinishedCats; //{ get; private set; }
    public GameObject FinishZone;

    void Start()
    {
        var binder = FinishZone.AddComponent<ReachEndBinder>();
        binder.FinishCat = FinishCat;
    }

    public void FinishCat()
    {
        FinishedCats ++;
    }
    protected override bool Condition
    {
        get { return FinishedCats > NeededCats; }
    }
}
