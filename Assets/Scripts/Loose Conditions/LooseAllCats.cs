using UnityEngine;
using System.Collections;

public class LooseAllCats : DefeatCondition
{
    private static int remainingCats;
    public GameObject[] Cats;

    public static void LooseCat()
    {
        remainingCats--;
    }
	// Use this for initialization
	void Start ()
	{
	    remainingCats = Cats.Length;
	}
	
	// Update is called once per frame
    protected override bool Condition
    {
        get { return remainingCats <= 0; }
    }
}
