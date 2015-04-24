using UnityEngine;
using System.Collections;

public class MouseFollow : MonoBehaviour {
	// Update is called once per frame
	void Update ()
	{
	    transform.position = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}
}
