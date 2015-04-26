using UnityEngine;
using System.Collections;

public class DontDestroyBetweenScenes : MonoBehaviour {
	void Awake () {
        DontDestroyOnLoad(gameObject);
	}
}
