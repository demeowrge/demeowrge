using UnityEngine;
using System.Collections;

public class Fear : MonoBehaviour
{
    public FloatRange fearRange;

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
                (cat.transform.position - transform.position) * fearRange.random(),
                cat.speedRange.max * 2
            );
        }
    }
}
