using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILevel : MonoBehaviour
{
    public Level level;
    public Text levelIDText;
    public GameObject lockImage;

    private Transform startParent;
    private Image[] stars;

    private void Awake()
    {
        startParent = transform.Find("Stars").transform;
        stars = startParent.GetComponentsInChildren<Image>();
    }

    public void SetStars(int stars)
    {
        for (int i = 0; i < stars; i++)
        {
            this.stars[i].color = Color.white;
        }
    }
}
