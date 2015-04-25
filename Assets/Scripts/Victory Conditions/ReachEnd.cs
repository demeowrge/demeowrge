using UnityEngine;
using System.Collections;

public class ReachEnd : VictoryCondition
{
    public int NeededCats;
    public int FinishedCats; //{ get; private set; }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Cat")
         FinishCat();
    }

    public void FinishCat()
    {
        FinishedCats ++;
    }
    protected override bool Condition
    {
        get { return FinishedCats >= NeededCats; }
    }
}
