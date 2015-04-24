using UnityEngine;
using System.Collections;

using Utility;
using Random = UnityEngine.Random;

public class Cat : MonoBehaviour
{
    public FloatRange idleRange;
    public FloatRange speedRange;

    private Coroutine currentAction = null;

    void Update()
    {
        if (currentAction == null)
        {
            pickAction();
        }
    }

    private void pickAction()
    {   
        float val = Random.value;

        if (val - 0.5 < Mathf.Epsilon)
        {
            Idle(idleRange.random());
        }
        else
        {
            Move(transform.position + (Vector3) Random.insideUnitCircle, speedRange.random());
        }
    }

    public void Idle(float time)
    {
        currentAction = StartCoroutine(idle(time));
    }

    public void Move(Vector3 destination, float speed)
    {
        currentAction = StartCoroutine(move(destination, speed));
    }

    public void Death()
    {
        // pass
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
