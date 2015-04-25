using UnityEngine;
using System.Collections;

public abstract class DefeatCondition : MonoBehaviour {
    protected abstract bool Condition { get; }

    protected void Update()
    {
        if (Condition)
            OnDefeat();

    }

    protected void OnDefeat()
    {
        LevelManager.DefeatClip();
    }
}
