using UnityEngine;
using System.Collections;
using System.Text;

public class BadCat : MonoBehaviour
{
    public float Speed;

    protected Collider2D chaseCollider;
    protected WorstEffectEver worstEffectEver;

    void Start()
    {
        worstEffectEver = transform.GetComponentInChildren<WorstEffectEver>();

        chaseCollider = gameObject.GetComponent<Collider2D>();
        chaseCollider.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        Cat cat = obj.GetComponent<Cat>();
        if (cat != null)
        {
            chaseCollider.enabled = false;
            StartCoroutine(ChaseCoroutine(cat));
        }
    }

    protected IEnumerator ChaseCoroutine(Cat cat)
    {
        while (cat != null 
            && worstEffectEver.chased == false 
            && Vector3.Distance(transform.position, cat.transform.position) > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, cat.transform.position, Speed * Time.deltaTime);
            yield return null;
        }

        worstEffectEver.chased = false;
    }
}
