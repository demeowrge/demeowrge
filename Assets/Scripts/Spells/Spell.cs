using UnityEngine;
using System.Collections;

public class Spell : MonoBehaviour
{
    public GameObject PrecastEffect;
    public GameObject[] SpellEffects;

    public void Start()
    {
        gameObject.AddComponent<MouseFollow>();
        ApplyPrecastEffect();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            foreach (var effect in SpellEffects)
                Instantiate(effect, effect.transform.position + gameObject.transform.position, gameObject.transform.rotation);
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
        PrecastEffect = (GameObject)Instantiate(PrecastEffect, destination, PrecastEffect.transform.rotation);
        PrecastEffect.transform.SetParent(gameObject.transform);
        PrecastEffect.AddComponent<MouseFollow>();
    }

    public void RemovePrecastEffect()
    {
        PrecastEffect.GetComponent<ParticleSystem>().Stop();
    }
}
