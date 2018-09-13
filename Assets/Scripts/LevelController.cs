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
        }

        levels = new List<Level>
        {
            new Level(0, "Level_001", false, 0, false),
            new Level(1, "Level_002", false, 0, false),
            new Level(2, "Level_003", false, 0, true),
            new Level(3, "Level_004", false, 0, true),
            new Level(4, "Level_005", false, 0, true),
            new Level(5, "Level_006", false, 0, true),
            new Level(6, "Level_007", false, 0, true),
            new Level(7, "Level_008", false, 0, true),
            new Level(8, "Level_009", false, 0, true),
            new Level(9, "Level_010", false, 0, true),
            new Level(10, "Level_011", false, 0, true),
            new Level(12, "Level_012", false, 0, true),
            new Level(13, "Level_013", false, 0, true),
            new Level(14, "Level_014", false, 0, true),
        };
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
}
