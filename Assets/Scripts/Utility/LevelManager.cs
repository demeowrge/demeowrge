using UnityEngine;

public static class LevelManager
{
    private const string LevelNameTemplate = "Test Level";
    private const string ClipNameTemplate = "Test Clip";
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

    private static void LoadLevel(int index)
    {
        Application.LoadLevel(GetLevelName(index));
    }

    private static void LoadClip(int index)
    {
        Application.LoadLevel(GetClipName(index));
    }

    public static void NextLevel()
    {
        LoadLevel(currentLevel++);
    }

    public static void NextClip()
    {
        LoadClip(currentClip++);
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
        currentLevel = 1;
        LoadLevel(currentLevel);
    }

    public static void MainMenu()
    {
        currentLevel = 0;
        currentClip = 0;
        Application.LoadLevel("MainMenu");
    }

    public static void Exit()
    {
        Application.Quit();
    }
}