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
    public Text ýnGameScoreText;

    void Start()
    {
        
    }

    public void LevelEnd()      //Level sonu oyunu kaybetme paneli
    {
        LoseUI.SetActive(true);
        loseScoreText.text = "Toplam Puan : " + score;
        ýnGameScoreText.gameObject.SetActive(false);     //Oyun içi gözüken skor oyun bitince gözükmeyecek.
    }

    public void WinLevel()      //Level sonu bölümü geçme paneli
    {
        WinUI.SetActive(true);
        winScoreText.text = "Toplam Puan : " + score;
        ýnGameScoreText.gameObject.SetActive(false);
    }
    
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void AddScore(int pointValue)
    {
        score += pointValue;
        ýnGameScoreText.text = "Puan: " + score;
    }

    public void StartApp()     //Tekrar oyna butonu
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AppQuit()     //Çýkýþ butonu
    {
        Application.Quit();
    }
}
