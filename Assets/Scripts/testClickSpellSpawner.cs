using UnityEngine;
using System.Collections;

public class testClickSpellSpawner : MonoBehaviour
{
    public GameObject lbuttonPrefab;
    public GameObject rbuttonPrefab;

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            destination.z = 0;

            Instantiate(lbuttonPrefab, destination, Quaternion.identity);
        }
        else if (Input.GetMouseButtonUp(1))
        {
            Vector3 destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            destination.z = 0;

            Instantiate(rbuttonPrefab, destination, Quaternion.identity);
        }
    }
}
