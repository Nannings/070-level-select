using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private LevelController levelController;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (FindObjectsOfType<LevelController>().Length > 1)
        {
            Destroy(gameObject);
        }

        levelController = FindObjectOfType<LevelController>();
    }

    private void Update()
    {
        DebugLevelController();
    }

    private void DebugLevelController()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            levelController.CompleteLevel(SceneManager.GetActiveScene().name, Random.Range(1, 4));
            levelController.UnLockNextLevelOfCurrentScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("LevelSelect");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            levelController.DebugLevelList();
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            levelController.SaveGame();
        }
    }
}
