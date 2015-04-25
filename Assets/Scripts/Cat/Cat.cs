using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class Cat : MonoBehaviour
{
    public GameObject HatPrefab;

    public FloatRange IdleRange;
    public FloatRange SpeedRange;

    protected Coroutine currentAction = null;
    protected bool proselytized = false;

    void Update()
    {
        if (currentAction == null)
        {
            float val = Random.value;

            if (val < 0.7f)
            {
                Idle(IdleRange.random());
            }
            else
            {
                Move(transform.position + (Vector3)Random.insideUnitCircle * 2.25f, SpeedRange.random());
            }
        }
    }

    public void Idle(float time)
    {
        StopAllCoroutines();
        currentAction = StartCoroutine(
            IdleCoroutine(time)
        );
    }

    public void Move(Vector3 destination, float speed)
    {
        StopAllCoroutines();

        if (destination.x < 0f)
            destination.x = 0f;

        if (destination.x > LevelGenerator.LevelPxWidth)
            destination.x = LevelGenerator.LevelPxWidth;

        if (destination.y < 0f)
            destination.y = 0f;

        if (destination.y > LevelGenerator.LevelPxHeight)
            destination.y = LevelGenerator.LevelPxHeight;

        currentAction = StartCoroutine(
            MoveCoroutine(destination, speed)
        );
    }

    public void Death()
    {
        StopAllCoroutines();

        CatAnimationController animationController = GetComponent<CatAnimationController>();
        animationController.Death();
        
        Destroy(gameObject, 5f);
        Destroy(this);
    }

    public void Proselytize()
    {
        if (!proselytized)
        {
            GameObject hat = (GameObject) Instantiate(HatPrefab, transform.position, Quaternion.identity);
            hat.transform.parent = transform;
        }
    }

    private IEnumerator IdleCoroutine(float time)
    {
        yield return new WaitForSeconds(time);

        currentAction = null;
    }

    private IEnumerator MoveCoroutine(Vector3 destination, float speed)
    {
        while (Vector3.Distance(transform.position, destination) > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            yield return null;
        }

        currentAction = null;
    }
}
