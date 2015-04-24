using UnityEngine;
using System.Collections;

public class mainMenuUI : MonoBehaviour
{
	public void bnNewGameClick () {
        LevelManager.NewGame();
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
		LevelManager.Exit();
	}
}
