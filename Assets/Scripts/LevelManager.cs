using UnityEngine;

public static class LevelManager
{
    private const string LevelNameTemplate = "Test Level";
    private static int savedLevel;
    private static int currentLevel;

    public static bool HaveSavedLevel
    {
        get { return savedLevel != 0; }
    }

    private static string GetLevelName(int index)
    {
        return LevelNameTemplate + " " + index;
    }

    private static void LoadLevel(int index)
    {
        Application.LoadLevel(GetLevelName(index));
    }

    public static void NextLevel()
    {
        LoadLevel(currentLevel++);
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
        if (savedLevel > 0)
            LoadLevel(savedLevel);
    }

    public static void NewGame()
    {
        currentLevel = 1;
        LoadLevel(currentLevel);
    }

    public static void MainMenu()
    {
        Application.LoadLevel("MainMenu");
    }

    public static void Exit()
    {
        Application.Quit();
    }
}