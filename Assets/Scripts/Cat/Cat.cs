using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class Cat : MonoBehaviour
{
    public GameObject HatPrefab;

    public bool Blessed;
    public FloatRange IdleRange;
    public FloatRange SpeedRange;

    protected bool proselytized = false;
    protected GameObject hat = null;
    protected Coroutine currentAction = null;

    public GameObject BadCatPrefab;

    public bool Degrading;
    public FloatRange HatDegradationRange;
    public FloatRange DegradationRange;

    protected Coroutine degradationAction = null;

    void Start()
    {
        if (Blessed)
        {
            Proselytize();
        }

        if (Degrading)
        {
            if (proselytized)
            {
                StopDegradationAction();
                HatDegradation();
            }
            else
            {
                StopDegradationAction();
                Degradation();
            }
        }
    }

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

    private void StopCurrentAction()
    {
        if (currentAction != null)
        {
            StopCoroutine(currentAction);
            currentAction = null;
        }
    }

    public void Idle(float time)
    {
        StopCurrentAction();

        currentAction = StartCoroutine(
            IdleCoroutine(time)
        );
    }

    public void Move(Vector3 destination, float speed)
    {
        StopCurrentAction();

        if (destination.x < 0.2f)
            destination.x = 0.2f;

        if (destination.x > LevelGenerator.LevelPxWidth)
            destination.x = LevelGenerator.LevelPxWidth;

        if (destination.y < 0.2f)
            destination.y = 0.2f;

        if (destination.y > LevelGenerator.LevelPxHeight)
            destination.y = LevelGenerator.LevelPxHeight;

        currentAction = StartCoroutine(
            MoveCoroutine(destination, speed)
        );
    }

    public void Death()
    {
        LooseAllCats.LooseCat();
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
            proselytized = true;

            hat = (GameObject)Instantiate(HatPrefab, transform.position, Quaternion.identity);
            hat.transform.parent = transform;
        }

        if (Degrading)
        {
            StopDegradationAction();
            HatDegradation();
        }
    }

    public void DeProselytize()
    {
        if (proselytized)
        {
            proselytized = false;
            Destroy(hat);

            if (Degrading)
            {
                StopDegradationAction();
                Degradation();   
            }
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

    public void StopDegradationAction()
    {
        if (degradationAction != null)
        {
            StopCoroutine(degradationAction);
            degradationAction = null;
        }
    }

    public void HatDegradation()
    {
        degradationAction = StartCoroutine(
            HatDegradationCoroutine(HatDegradationRange.random())
        );
    }

    private IEnumerator HatDegradationCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
        DeProselytize();
    }

    public void Degradation()
    {
        degradationAction = StartCoroutine(
            DegradationCoroutine(DegradationRange.random())
        );
    }

    private IEnumerator DegradationCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
        Degradate();
    }

    private void Degradate()
    {
        Instantiate(BadCatPrefab, transform.position, Quaternion.identity);
        Death();
    }
}
