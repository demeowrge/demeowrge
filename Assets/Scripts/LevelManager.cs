using System;
using UnityEngine;
using System.Collections;
using UnityEditor;

public static class LevelManager {

    public static void NextLevel()
    {
        throw new NotImplementedException();    
    }
    public static void RestartLevel()
    {
        throw new NotImplementedException();
    }
    public static void Save()
    {
        throw new NotImplementedException();
    }
    public static void Load()
    {
        throw new NotImplementedException();
    }
    public static void NewGame()
    {
        Application.LoadLevel("Test Level 1");
    }
    public static void Exit()
    {
        Environment.Exit(0);
    }
}
