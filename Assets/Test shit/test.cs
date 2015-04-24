using UnityEngine;
using System.Collections;

public class test : MonoBehaviour
{

    public GameObject spell;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(spell);
        }
    }
}
