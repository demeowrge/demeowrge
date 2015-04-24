using UnityEngine;
using System.Collections;

public class mainMenuUI : MonoBehaviour {
	public void bnNewGameClick () {
        Debug.Log("bnNewGame_Clicked");
	}

    public void bnContinueClick()
    {
        Debug.Log("bnContinue_Clicked");
    }

    public void bnMultiplayerClick()
    {
        Debug.Log("bnMultiplayer_Clicked");
    }

    public void bnExitClick()
    {
        Debug.Log("bnExit_Clicked");
        Application.Quit();
    }
}
