using UnityEngine;
using System.Collections;

public class ingameUI : MonoBehaviour {
    void Awake()
    {
        //DontDestroyOnLoad(transform.gameObject);
    }

    public void bnProphetClick()
    {
        Instantiate(SpellManager.ProphetSpell);
    }

    public void bnLightingClick()
    {
        Instantiate(SpellManager.LightningSpell);
    }

    public void bnMenuClick()
    {
        LevelManager.MainMenu();
    }
}
