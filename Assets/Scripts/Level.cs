using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public int ID { get; set; }
    public string LevelName { get; set; }
    public bool Completed { get; set; }
    public int Stars { get; set; }
    public bool Locked { get; set; }

    public Level(int iD, string levelName, bool completed, int stars, bool locked)
    {
        ID = iD;
        LevelName = levelName;
        Completed = completed;
        Stars = stars;
        Locked = locked;
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
