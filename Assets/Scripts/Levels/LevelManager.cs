using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelManager
{
    private const string LevelNameTemplate = "Level";
    private const string ClipNameTemplate = "Clip";
    private static int savedLevel;
    private static int currentLevel;
    private static int currentClip;

    public static bool HaveSavedLevel
    {
        get { return savedLevel != 0; }
    }

    private static string GetLevelName(int index)
    {
        return LevelNameTemplate + " " + index;
    }

    private static string GetClipName(int index)
    {
        return ClipNameTemplate + " " + index;
    }

    private static string nameBuffer;

    private static void LoadScene(string name)
    {
        nameBuffer = name;
        FadeManager.Fade(PostFadeLoadScene);
    }

    public static void PostFadeLoadScene()
    {
        Application.LoadLevel(nameBuffer);
        FadeManager.Unfade();
    }

    public static void NextLevel()
    {
        LoadScene(GetLevelName(++currentLevel));
    }

    public static void NextClip()
    {
        LoadScene(GetClipName(++currentClip));
    }

    public static void RestartLevel()
    {
        LoadScene(GetLevelName(currentLevel));
    }

    public static void Save()
    {
        savedLevel = currentLevel;
    }

    public static void Load()
    {
        if (!HaveSavedLevel) return;
        currentLevel = savedLevel;
        LoadScene(GetLevelName(savedLevel));
    }

    public static void NewGame()
    {
        currentLevel = 0;
        currentClip = 0;
        LoadScene(GetClipName(0));
    }

    public static void MainMenu()
    {
        currentLevel = 0;
        currentClip = 0;
        LoadScene("MainMenu");
    }

    public static void DefeatClip()
    {
        LoadScene("Defeat Clip");
    }

    public static void Exit()
    {
        Application.Quit();
    }
}