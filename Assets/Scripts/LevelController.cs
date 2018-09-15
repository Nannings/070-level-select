using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public List<Level> levels;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (FindObjectsOfType<LevelController>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        LoadGame();
    }

    public void StartLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void CompleteLevel(string levelName)
    {
        levels.Find(i => i.LevelName == levelName).Complete();
    }

    public void CompleteLevel(string levelName, int stars)
    {
        levels.Find(i => i.LevelName == levelName).Complete(stars);
    }

    public void LockLevel(string levelName)
    {
        levels.Find(i => i.LevelName == levelName).Lock();
    }

    public void UnlockLevel(string levelName)
    {
        levels.Find(i => i.LevelName == levelName).UnLock();
    }

    public void UnLockNextLevelOfCurrentScene(string levelName)
    {
        int nextLevel = levels.IndexOf(levels.Find(i => i.LevelName == levelName));
        nextLevel++;
        if (nextLevel < levels.Count)
        {
            levels[nextLevel].UnLock();
        }
    }

    public void DebugLevelList()
    {
        foreach (Level level in levels)
        {
            print(level.ID + " - " + level.LevelName + " - " + level.Stars + " - ");
        }
    }

    public void SaveGame()
    {
        SaveManager.saveState.levels = levels;
        SaveManager.Save();
    }

    public void LoadGame()
    {
        SaveManager.Load();
        if(SaveManager.saveState.levels.Count <= 0)
        {
            levels = new List<Level>();
            for (int i = 0; i < 50; i++)
            {
                levels.Add(new Level(i + 1, "Level_" + (i + 1), false, 0, true));
            }

            levels[0].UnLock();

            SaveGame();
        }
        else
        {
            levels = SaveManager.saveState.levels;
        }
    }
}
