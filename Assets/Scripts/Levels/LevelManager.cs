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

    private static int indexBuffer;

    private static void LoadLevel(int index)
    {
        indexBuffer = index;
        FadeManager.Fade(PostFadeLoadLevel);
    }

    public static void PostFadeLoadLevel()
    {
        Application.LoadLevel(GetLevelName(indexBuffer));
        FadeManager.Unfade();
    }

    private static void LoadClip(int index)
    {
        indexBuffer = index;
        FadeManager.Fade(PostFadeLoadClip);
    }

    public static void PostFadeLoadClip()
    {
        Application.LoadLevel(GetClipName(indexBuffer));
        FadeManager.Unfade();
    }

    public static void NextLevel()
    {
        LoadLevel(++currentLevel);
    }

    public static void NextClip()
    {
        LoadClip(++currentClip);
    }

    public static void RestartLevel()
    {
        LoadLevel(currentLevel);
    }

    public static void Save()
    {
        savedLevel = currentLevel;
    }

    public static void Load()
    {
        if (!HaveSavedLevel) return;
        currentLevel = savedLevel;
        LoadLevel(savedLevel);
    }

    public static void NewGame()
    {
        currentLevel = 0;
        currentClip = 0;
        LoadClip(0);
    }

    public static void MainMenu()
    {
        currentLevel = 0;
        currentClip = 0;
        Application.LoadLevel("MainMenu");
    }

    public static void DefeatClip()
    {
        Application.LoadLevel("Defeat Clip");
    }

    public static void Exit()
    {
        Application.Quit();
    }
}