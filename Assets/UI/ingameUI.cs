using System;
using UnityEngine;
using UnityEngine.UI;

public class ingameUI : MonoBehaviour
{
    public GameObject FishCounter;
    public GameObject LightingCounter;
    public GameObject ProphetCounter;
    public GameObject DirectCounter; 

    public void bnRestartClick()
    {
        LevelManager.RestartLevel();
    }

    public void bnProphetClick()
    {
        if (UpdateSpellAmount(ProphetCounter))
            Instantiate(SpellManager.ProphetSpell);
    }

    public void bnDirectClick()
    {
        if (UpdateSpellAmount(DirectCounter))
            Instantiate(SpellManager.DirectSpell);
    }

    public void bnFishClick()
    {
        if (UpdateSpellAmount(FishCounter))
            Instantiate(SpellManager.FishSpell);
    }

    private bool UpdateSpellAmount(GameObject spellCounter)
    {
        var textComponent = spellCounter.GetComponent<Text>();
        var castsCountNumber = Int32.Parse(textComponent.text);
        if (castsCountNumber > 0)
        {
            castsCountNumber--;
            textComponent.text = castsCountNumber.ToString();
            return true;
        }
        return false;
    }

    public void bnLightingClick()
    {
        if (UpdateSpellAmount(LightingCounter))
            Instantiate(SpellManager.LightningSpell);
    }

    public void bnMenuClick()
    {
        LevelManager.MainMenu();
    }
}
