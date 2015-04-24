using UnityEngine;
using System.Collections;

public class MoveByVector : MonoBehaviour
{
    public Vector3 moveVector3;

    void LateUpdate()
    {
        transform.Translate(moveVector3);
    }
}
