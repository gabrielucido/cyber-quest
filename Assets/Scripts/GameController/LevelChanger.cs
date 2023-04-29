using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    private string nextLevel = "";

    void Start()
    {
        
    }

    public void ChangeToLevel(string levelName)
    {
        nextLevel = levelName;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        if (nextLevel.Length > 0)
        {
            SceneManager.LoadScene(this.nextLevel);
            nextLevel = "";
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
