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
        currentPage = page;
        int pageSize = 12;
        List<UILevel> pageList = levelList.Skip(page * pageSize).Take(pageSize).ToList();
    }
}
