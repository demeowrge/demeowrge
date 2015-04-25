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

    public void bnDirectClick()
    {
        Instantiate(SpellManager.DirectSpell);
    }

    public void bnFishClick()
    {
        Instantiate(SpellManager.FishSpell);
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
