using UnityEngine;
using System.Collections;

public class AddCatEffect : MonoBehaviour
{
    public GameObject CatPrefab;

    void Start()
    {
        Instantiate(CatPrefab, transform.position, Quaternion.identity);
    }
}
