using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Level
{
    public int ID;
    public string LevelName;
    public bool Completed;
    public int Stars;
    public bool Locked;

    public Level(int iD, string levelName, bool completed, int stars, bool locked)
    {
        this.ID = iD;
        this.LevelName = levelName;
        this.Completed = completed;
        this.Stars = stars;
        this.Locked = locked;
    }

    public void Complete()
    {
        this.Completed = true;
    }

    public void Complete(int stars)
    {
        this.Completed = true;
        this.Stars = stars;
    }

    public void Lock()
    {
        this.Locked = true;
    }

    public void UnLock()
    {
        this.Locked = false;
    }
}
