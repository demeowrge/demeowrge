using UnityEngine;
using System.Collections;

public class ReachEndBinder : MonoBehaviour {

    public delegate void func();

    public func FinishCat;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        FinishCat();
    }
}
