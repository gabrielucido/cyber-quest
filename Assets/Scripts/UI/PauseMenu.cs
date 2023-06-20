using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public bool isPaused = false;

    public Button continueBtn;
    public Button mainMenuBtn;
    private LevelChanger levelChanger;
    private GameObject player;

    void Start()
    {
        levelChanger = GameObject.Find("LevelChanger").GetComponent<LevelChanger>();
        player = GameObject.Find("PlayerCapsule");

        continueBtn.onClick.AddListener(OnResumeGame);
        mainMenuBtn.onClick.AddListener(ReturnToMainMenu);


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                OnResumeGame();
            }
            else
            {
                OnPauseGame();
            }
        }
        if (isPaused)
        {
            PausedGame();
        }
        else
        {
            ResumedGame();
        }
    }

    void ReturnToMainMenu()
    {
        Debug.Log("Returning to Main Menu....");
        isPaused = false;
        //Time.timeScale = 1;
        levelChanger.ChangeToLevel("MainMenu");
    }

    public void OnPauseGame()
    {
        isPaused = true;
        gameObject.transform.Find("Canvas").gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void OnResumeGame()
    {
        isPaused = false;
        gameObject.transform.Find("Canvas").gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ResumedGame()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    public void PausedGame()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
