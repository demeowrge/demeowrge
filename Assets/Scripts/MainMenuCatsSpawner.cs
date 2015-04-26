using UnityEngine;
using System.Collections;

public class MainMenuCatsSpawner : MonoBehaviour
{
    public GameObject MenuCatsPrefab;

    public FloatRange SpawnPauseRange;

    void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    protected IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnPauseRange.random());
            Instantiate(MenuCatsPrefab, transform.position, Quaternion.identity);
        }
    }
}
