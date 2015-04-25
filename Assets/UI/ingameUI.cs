using UnityEngine;
using System.Collections;

public class ingameUI : MonoBehaviour {
    void Awake()
    {
        //DontDestroyOnLoad(transform.gameObject);
    }

    public void bnProphetClick()
    {
        Debug.Log("bnProphet_Clicked");
    }

    public void bnLightingClick()
    {
        Instantiate(SpellManager.LightningSpell);
    }

    public void bnMenuClick()
    {
        Debug.Log("bnMenu_Clicked");
    }
}
