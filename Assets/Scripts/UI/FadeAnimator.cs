using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeAnimator : MonoBehaviour
{
    public LevelChanger levelChanger;

    private void Start()
    {
        levelChanger = GameObject.Find("LevelChanger").GetComponent<LevelChanger>();
    }

    void OnFadeComplete() {
        levelChanger.OnFadeComplete();
    }
}
