using UnityEngine;
using System.Collections;
using Ramdom = UnityEngine.Random;

public class Direct : MonoBehaviour
{
    public Vector3 destination;

    void Start()
    {
        Destroy(gameObject, 1f);
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        Cat cat = obj.GetComponent<Cat>();
        if (cat != null)
        {
            cat.StopAction();
            cat.Move(
                destination + (Vector3)Random.insideUnitCircle, 
                cat.speedRange.random()
            );
        }
    }
}
