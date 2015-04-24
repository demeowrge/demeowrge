using UnityEngine;
using System.Collections;

public class Gather : MonoBehaviour
{
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
                transform.position,
                cat.speedRange.random()
            );
        }
    }
}
