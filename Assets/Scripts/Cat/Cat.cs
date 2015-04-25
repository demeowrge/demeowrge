using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class Cat : MonoBehaviour
{
    public FloatRange idleRange;
    public FloatRange speedRange;

    private Coroutine currentAction;

    void Update()
    {
        if (currentAction == null)
        {
            float val = Random.value;

            if (val < 0.7f)
            {
                Idle(idleRange.random());
            }
            else
            {
                Move(transform.position + (Vector3)Random.insideUnitCircle * 2.25f, speedRange.random());
            }
        }
    }

    public void Idle(float time)
    {
        StopAllCoroutines();
        currentAction = StartCoroutine(idle(idleRange.random()));
    }

    public void Move(Vector3 destination, float speed)
    {
        StopAllCoroutines();
        currentAction = StartCoroutine(move(destination, speed));
    }

    public void Death()
    {
        StopAllCoroutines();

        CatAnimationController animationController = GetComponent<CatAnimationController>();
        animationController.Death();
        
        Destroy(gameObject, 5f);
        Destroy(this);
    }

    private IEnumerator idle(float time)
    {
        yield return new WaitForSeconds(time);

        currentAction = null;
    }

    private IEnumerator move(Vector3 destination, float speed)
    {
        while (Vector3.Distance(transform.position, destination) > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            yield return null;
        }

        currentAction = null;
    }
}
