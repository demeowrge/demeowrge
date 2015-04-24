using UnityEngine;
using System.Collections;

public class Spell : MonoBehaviour
{
    public GameObject PrecastEffect;
    public GameObject SpellEffect;

    public void Start()
    {
        ApplyPrecastEffect();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
            Destroy(gameObject);
    }

    public void OnDestroy()
    {
        RemovePrecastEffect();
    }

    public void ApplyPrecastEffect()
    {
        PrecastEffect = (GameObject)Instantiate(PrecastEffect, (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition), new Quaternion());
        PrecastEffect.transform.SetParent(gameObject.transform);
        PrecastEffect.AddComponent<MouseFollow>();
    }

    public void RemovePrecastEffect()
    {
        if (PrecastEffect == null)
            return;
        Destroy(PrecastEffect);
        PrecastEffect = null;
    }
}
