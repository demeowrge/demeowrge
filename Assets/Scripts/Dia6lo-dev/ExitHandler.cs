using UnityEngine;
using System.Collections;

public class ExitHandler : MonoBehaviour {


    public void OnMouseDown()
    {
        LevelManager.Exit();
    }
}
