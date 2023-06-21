using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Introduction : MonoBehaviour
{
    public bool completed = false;
    public bool open = false;

    public GameObject player;
    public GameObject canvas;

    private void Start()
    {
        player = GameObject.Find("PlayerCapsule");
    }

    void Update()
    {
        if (!completed && open == false)
        {
            PopUpIntroduction();
        }


        if (open)
        {
            player.SetActive(false);
            if (Input.GetMouseButtonDown(0))
            {
                CompleteIntroduction();
            }
        }
    }

    void PopUpIntroduction()
    {
        open = true;
        canvas.SetActive(true);
    }

    void CompleteIntroduction()
    {
        open = false;
        completed = true;
        player.SetActive(true);
        canvas.SetActive(false);
    }
}
