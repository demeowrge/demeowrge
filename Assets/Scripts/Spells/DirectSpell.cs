using UnityEngine;
using System.Collections;

public class DirectSpell : MonoBehaviour
{
    public GameObject PrecastEffect;
    public GameObject PrecastMarker;

    public GameObject SpellEffectObject;
    protected DirectEffect SpellEffectComponent;

    protected bool click = false;

    protected Vector3 btnDown;

    void Start()
    {
        SpellEffectComponent = SpellEffectObject.GetComponent<DirectEffect>();
        if (SpellEffectComponent == null)
        {
            Destroy(this);
        }

        gameObject.AddComponent<MouseFollow>();
        ApplyPrecastEffect();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && click == false)
        {
            click = true;
            btnDown = transform.position;

            Instantiate(PrecastMarker, transform.position, Quaternion.identity);
        }
        else if (Input.GetMouseButtonUp(0) && click == true)
        {
            SpellEffectComponent.destination = transform.position;
            Instantiate(SpellEffectObject, btnDown, Quaternion.identity);
            
            Destroy(gameObject);
        }

        if (Input.GetMouseButtonDown(2))
        {
            Destroy(gameObject);
        }
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
