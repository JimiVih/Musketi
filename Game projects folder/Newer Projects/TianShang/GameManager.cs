using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class GameManager : MonoBehaviour
{

    public KoiController YinkoiController;
    public KoiController YangkoiController;
    public PointManager pointManager;

    public GameObject winScreen;
    public GameObject gameOverScreen;
    public TMP_Text score;
    public TMP_Text finalScore;

   

    public Image panel;

    public string level;
    public bool koiIsDead;
    bool hasWon;
    // Start is called before the first frame update
    void Start()
    {
        panel.DOFade(0, 2);
        gameOverScreen.SetActive(false);
        winScreen.SetActive(false);
        hasWon = false;
        koiIsDead = YinkoiController.isDead;
        koiIsDead = YangkoiController.isDead;
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();
        GameOver();
        score.text = "Score " + PointManager.score;
        if (!koiIsDead)
        {
            koiIsDead = YinkoiController.isDead;
            koiIsDead = YangkoiController.isDead;
        }
    }

    void GetInputs()
    {
        if(koiIsDead)
        {           
            if(Input.GetKeyUp(KeyCode.R))
            {
                Restart();
            }
        }

        if(hasWon)
        {
            if(Input.GetKeyUp(KeyCode.Return))
            {
                NextStage();
            }
        }

        if(Input.GetKeyUp(KeyCode.Escape))
        {
            QuitToMenu();
        }
    }

    public void Restart()
    {
        panel.DOFade(1, 3);
        SceneManager.LoadScene("level_1");
    }

    public void QuitToMenu()
    {
        panel.DOFade(1, 3);
        SceneManager.LoadScene("menu");
    }

    public void NextStage()
    {
        panel.DOFade(1, 3);
        SceneManager.LoadScene(level);
    }

    public void GameOver()
    {
        if (koiIsDead)
        {
            YinkoiController.isDead = true;
            YangkoiController.isDead = true;
            
            
            finalScore.text = "Final Score: " + PointManager.score;
            gameOverScreen.SetActive(true);
        }

    }

    public void Win()
    {
        if (hasWon)
        {            
            winScreen.SetActive(true);
        }
    }
}
