using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Interaction : MonoBehaviour
{
    bool mouseIn;
    void Start()
    {
        mouseIn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseIn == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<Light>().enabled = !GetComponent<Light>().enabled;
                AbrirCenaNova();

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
            }
        }
    }

    public void AbrirCenaNova()
    {
        // Carrega a cena com o nome da cena desejada
        SceneManager.LoadScene("NunbersMinigame");
    }
    void OnMouseEnter()
    {
        mouseIn = true;
    }

    void OnMouseExit()
    {
        mouseIn = false;
    }
}
