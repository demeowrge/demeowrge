using UnityEngine;
using System.Collections;

public class MooveByVector : MonoBehaviour {
    public Vector3 moveVector3;

    void LateUpdate() {
        transform.Translate(moveVector3);
	}
}
