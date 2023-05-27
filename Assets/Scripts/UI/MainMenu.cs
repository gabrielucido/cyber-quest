using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject startButton;
    public GameObject quitButton;
    public LevelChanger levelChanger;

    void Start()
    {
        Button startBtn = startButton.GetComponent<Button>();
        startBtn.onClick.AddListener(StartGame);

        Button quitBtn = quitButton.GetComponent<Button>();
        quitBtn.onClick.AddListener(QuitGame);

        levelChanger = GameObject.Find("LevelChanger").GetComponent<LevelChanger>();
    }

    void StartGame()
    {
        Debug.Log("Game Started!");
        levelChanger.ChangeToLevel("MainScene");
        Cursor.lockState = CursorLockMode.Locked;
    }

    void QuitGame()
    {
        Debug.Log("Game Quited!");
        Application.Quit();
    }
}
