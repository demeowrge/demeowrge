using UnityEngine;
using System.Collections;

public abstract class AbsEffect : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D obj)
    {
        Effect(obj);
    }

    protected abstract void Effect(Collider2D obj);
}
