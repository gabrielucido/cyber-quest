using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SimonSays : MonoBehaviour
{

    public Image VizualizarImage;
    public GameObject BordaImage;
    public List<Color> ColorsButton;
    public int Barra1Cor;
    public int MostrarCores;
    public int Ocult;
    public TMP_Text OcultText;
    public List<int> Sequiencia;
    public TMP_Text LevelText;
    public GameObject EndScene;
    public int HighScore;
    public TMP_Text HighScoreText;

    private bool isShowingSequence;

    void Start()
    {
        Sequiencia = new List<int>();
        StartGame();
    }

    public void Generator()
    {
        Barra1Cor++;
        LevelText.text = "Level: " + Barra1Cor;
        Sequiencia.Add(Random.Range(0, 4));
        MostrarVizualizacao();
    }

    void MostrarVizualizacao()
    {
        if (Sequiencia.Count <= MostrarCores)
        {
            VizualizarImage.color = Color.white;
            MostrarCores = 0;
            Ocult = Sequiencia.Count;
            OcultText.text = Ocult.ToString();
            BordaImage.SetActive(false);
        }
        else
        {
            VizualizarImage.color = ColorsButton[Sequiencia[MostrarCores]];
            Invoke(nameof(NachsteZeigen), 0.5f);
        }
    }

    public void FarbenButton(int ID)
    {
        if (isShowingSequence)
            return;

        if (ID == Sequiencia[MostrarCores])
        {
            MostrarCores++;
            Ocult--;
            OcultText.text = Ocult.ToString();
            if (MostrarCores == Sequiencia.Count)
            {
                BordaImage.SetActive(true);
                OcultText.text = "";
                Ocult = 0;
                MostrarCores = 0;
                Invoke(nameof(StartGame), 0.5f);
            }
        }
        else
        {
            EndScene.SetActive(true);
            BordaImage.SetActive(true);
            HighScore = PlayerPrefs.GetInt("Highscore");
            if (Barra1Cor > HighScore)
            {
                HighScore = Barra1Cor;
                PlayerPrefs.SetInt("Highscore", HighScore);
            }
            HighScoreText.text = "Highscore: " + HighScore;
            OcultText.text = "";
            Ocult = 0;
            MostrarCores = 0;
        }
    }

    public void Nochmal()
    {
        Sequiencia = new List<int>();
        Barra1Cor = 0;
        LevelText.text = "Level: " + Barra1Cor;
        EndScene.SetActive(false);
        StartGame();
    }

    void StartGame()
    {
        Invoke(nameof(Generator), 0.5f);
    }

    void NachsteZeigen()
    {
        VizualizarImage.color = Color.white;
        Invoke(nameof(ShowNextColor), 0.7f);
    }

    void ShowNextColor()
    {
        MostrarCores++;
        MostrarVizualizacao();
    }
}
