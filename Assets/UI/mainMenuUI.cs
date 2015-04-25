using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class mainMenuUI : MonoBehaviour
{
    public GameObject bnContinue;

    private void Start()
    {
        if (!LevelManager.HaveSavedLevel) return;

        bnContinue.GetComponent<Button>().interactable = true;
        bnContinue.GetComponentInChildren<Text>().color = Color.white;
    }

    public void bnNewGameClick () {
        LevelManager.NewGame();
	}

	public void bnContinueClick()
	{
		LevelManager.Load();
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
