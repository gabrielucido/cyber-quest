using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UnlockManifolds : MonoBehaviour
{
    public List<Button> buttons;
    public List<Button> shuffledButtons;
    int counter = 0;

    // Start is called before the first frame update
    public void Start()
    {
        RestartTheGame();
    }

    public void RestartTheGame()
    {
        counter = 0;
        shuffledButtons = buttons.OrderBy<Button, int>(a => UnityEngine.Random.Range(0, 100)).ToList();

        for (int i = 1; i < 11; i++)
        {
            shuffledButtons[i - 1].GetComponentInChildren<TMP_Text>().text = i.ToString();
            shuffledButtons[i - 1].interactable = true;
            shuffledButtons[i - 1].image.color = new Color32(177, 220, 233, 255);
        }
    }

    public void PressButton(Button button)
    {
        if (int.Parse(button.GetComponentInChildren<TMP_Text>().text) - 1 == counter)
        {
            counter++;
            Debug.Log("Counter "+counter);
            button.interactable = false;
            button.image.color = Color.green;
            if (counter == 10)
            {
                PresentResult(true);
            }
        }
        else
        {
            PresentResult(false);
        }
    }

    public void PresentResult(bool win)
    {
        if (!win)
        {
            foreach (var button in shuffledButtons)
            {
                button.image.color = Color.red;
                button.interactable = false;
            }
        }

        Invoke("RestartTheGame", 2f);
    }

    private void Update()
    {
        
    }
}