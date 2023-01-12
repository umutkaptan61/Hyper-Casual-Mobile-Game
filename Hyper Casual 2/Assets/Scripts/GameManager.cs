using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject LoseUI;
    public GameObject WinUI;

    public int score;

    public Text loseScoreText , winScoreText;
    public Text �nGameScoreText;

    void Start()
    {
        
    }

    public void LevelEnd()      //Level sonu oyunu kaybetme paneli
    {
        LoseUI.SetActive(true);
        loseScoreText.text = "Toplam Puan : " + score;
        �nGameScoreText.gameObject.SetActive(false);     //Oyun i�i g�z�ken skor oyun bitince g�z�kmeyecek.
    }

    public void WinLevel()      //Level sonu b�l�m� ge�me paneli
    {
        WinUI.SetActive(true);
        winScoreText.text = "Toplam Puan : " + score;
        �nGameScoreText.gameObject.SetActive(false);
    }
    
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void AddScore(int pointValue)
    {
        score += pointValue;
        �nGameScoreText.text = "Puan: " + score;
    }

    public void StartApp()     //Tekrar oyna butonu
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AppQuit()     //��k�� butonu
    {
        Application.Quit();
    }
}
