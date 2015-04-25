using UnityEngine;
using System.Collections;

public class RelativeAnimate : MonoBehaviour {
    private Vector3 startPosition;

	void Start () {
        startPosition = transform.localPosition;
	}

    void LateUpdate()
    {
        transform.localPosition += startPosition;
    }
}
