using UnityEngine;
using System.Collections;

public class DestroyCommand : MonoBehaviour {
    public void DestroyThis()
    {
        Destroy(gameObject);
    }
}
