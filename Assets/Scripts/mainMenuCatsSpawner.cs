using UnityEngine;
using System.Collections;

public class mainMenuCatsSpawner : MonoBehaviour {
	public int catsPauseChance;
    public GameObject menuCatsPrefab;
	
	void Update () {
        if (Random.Range(0, catsPauseChance) == 0)
        {
              Instantiate(menuCatsPrefab, transform.position, transform.rotation);
        };
	}
}
