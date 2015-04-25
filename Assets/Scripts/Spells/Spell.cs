using UnityEngine;
using System.Collections;

public class Spell : MonoBehaviour
{
    public GameObject PrecastEffect;
    public GameObject SpellEffect;

    public void Start()
    {
        gameObject.AddComponent<MouseFollow>();
        ApplyPrecastEffect();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(SpellEffect, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (Input.GetMouseButtonDown(1))
            Destroy(gameObject);
    }

    public void OnDestroy()
    {
        RemovePrecastEffect();
    }

    public void ApplyPrecastEffect()
    {
        var destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        destination.z = 0;
        PrecastEffect = (GameObject)Instantiate(PrecastEffect, destination, Quaternion.identity);
        PrecastEffect.transform.SetParent(gameObject.transform);
        PrecastEffect.AddComponent<MouseFollow>();
    }

    public void RemovePrecastEffect()
    {
        Destroy(PrecastEffect);
    }
}
