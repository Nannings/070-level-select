using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UILevelSelect : MonoBehaviour
{
    [SerializeField] private LevelController levelController;
    [SerializeField] private UILevel levelUI;
    [SerializeField] private GameObject levelPopup;

    private Transform levelSelectPanel;
    private int currentPage;
    private List<UILevel> levelList;

    private  void Start()
    {
        levelSelectPanel = transform;

        for (int i = 0; i < levelController.levels.Count; i++)
        {
            levelList.Add(levelUI);
        }

        BuildLevelPage(0);
    }

    private void BuildLevelPage(int page)
    {
        RemoveItemsFromPage();

        currentPage = page;
        int pageSize = 12;
        List<UILevel> pageList = levelList.Skip(page * pageSize).Take(pageSize).ToList();

        for (int i = 0; i < pageList.Count; i++)
        {
            Level level = levelController.levels[(page * pageSize) + i];
            UILevel instance = Instantiate(pageList[i]);
            instance.SetStars(level.Stars);
            instance.transform.SetParent(levelSelectPanel);

            if(!level.Locked)
            {
                instance.lockImage.SetActive(false);
                instance.levelIDText.text = level.ID.ToString();
            }
            else
            {
                instance.lockImage.SetActive(true);
                instance.levelIDText.text = "";
            }
        }
    }

    private void RemoveItemsFromPage()
    {
        for (int i = 0; i < levelSelectPanel.childCount; i++)
        {
            Destroy(levelSelectPanel.GetChild(i).gameObject);
        }
    }

    public void NextPage()
    {
        BuildLevelPage(currentPage + 1);
    }

    public void PreviousPage()
    {
        BuildLevelPage(currentPage - 1);
    }

    private void SelectLevel(Level level)
    {
        if (level.Locked)
        {
            levelPopup.gameObject.SetActive(true);
            Debug.Log("levellocked");
        }
        else
        {
            Debug.Log("go to level: " + level.ID);
            levelController.StartLevel(level.LevelName);
        }
    }
}
