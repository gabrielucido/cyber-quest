using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            }
        }
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
