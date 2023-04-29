using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public bool isPaused = false;

    public Button continueBtn;
    public Button mainMenuBtn;
    private LevelChanger levelChanger;

    void Start()
    {
        levelChanger = GameObject.Find("LevelChanger").GetComponent<LevelChanger>();

        continueBtn.onClick.AddListener(ResumeGame);
        mainMenuBtn.onClick.AddListener(ReturnToMainMenu);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            } else
            {
                PauseGame();
            }
        }
    }

    void ReturnToMainMenu()
    {
        Debug.Log("Returning to Main Menu....");
        isPaused = false;
        Time.timeScale = 1;
        levelChanger.ChangeToLevel("MainMenu");
    }

    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;
        gameObject.transform.Find("Canvas").gameObject.SetActive(true);
    }

    void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        gameObject.transform.Find("Canvas").gameObject.SetActive(false);
    }


}
