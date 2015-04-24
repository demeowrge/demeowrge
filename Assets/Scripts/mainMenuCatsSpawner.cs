using UnityEngine;
using System.Collections;

public class MainMenuCatsSpawner : MonoBehaviour {
	public int catsPauseChance;
    public float spawnPause;
    private float timeFromLastSpawn;

    public GameObject menuCatsPrefab;

    void Awake()
    {
        timeFromLastSpawn = spawnPause;
    }

	void Update ()
	{
        timeFromLastSpawn = timeFromLastSpawn + Time.deltaTime;
        if (timeFromLastSpawn > spawnPause)
	    {
            timeFromLastSpawn = 0;
            if (Random.Range(0, catsPauseChance) == 0)
            {
                Instantiate(menuCatsPrefab, transform.position, transform.rotation);
            }
	    } 
	}
}
