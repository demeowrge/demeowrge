using UnityEngine;
using System.Collections;

public class MouseFollow : MonoBehaviour
{
    void Update()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
