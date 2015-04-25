using UnityEngine;
using System.Collections;

public abstract class VictoryCondition : MonoBehaviour
{

    protected abstract bool Condition { get;}

    protected void Update () {
	    if (Condition)
	    {
	        OnVictory();
	    }

	}
    
    protected void OnVictory()
    {
        Destroy(gameObject);
        LevelManager.NextClip();
    }
}
