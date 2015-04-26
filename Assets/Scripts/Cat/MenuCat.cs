using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class MenuCat : MonoBehaviour
{
    public GameObject[] Hats;

    public FloatRange SpeedRange;

    void Start()
    {
        if (Random.value < 0.7)
        {
            GameObject hat = (GameObject)Instantiate(
                Hats[Random.Range(0, Hats.Length)],
                transform.position,
                Quaternion.identity
            );

            hat.transform.parent = transform;
        }

        StartCoroutine(MoveCoroutine(SpeedRange.random()));
    }

    protected IEnumerator MoveCoroutine(float speed)
    {
        while (true)
        {
            float step = speed * Time.deltaTime;

            Vector3 destination = transform.position;
            destination.x = destination.x - step;

            transform.position = destination;

            yield return null;
        }
    }

}
