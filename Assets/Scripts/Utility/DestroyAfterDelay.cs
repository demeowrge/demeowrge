using UnityEngine;
using System.Collections;

public class DestroyAfterDelay : MonoBehaviour
{
    public float lifetime;

    void Awake()
    {
        Destroy(gameObject, lifetime);
    }
}
