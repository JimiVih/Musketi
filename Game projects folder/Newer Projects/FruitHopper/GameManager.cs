using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public Text score;
    public GameObject winner;
    public GameObject loser;
    public GameObject player;
    public GameObject cam;
    public GameObject[] spawners;
    PlayerMovement playerMove;
    CameraMove camMove;
    public int points;
    public int playerHealth;
    public Image panel, one, two, three, go;
    bool gameOver;
    public bool gameWon;
    
    // Start is called before the first frame update
    void Start()
    {
        winner.SetActive(false);
        loser.SetActive(false);
        playerHealth = 3;
        gameOver = false;
        playerMove = player.GetComponent<PlayerMovement>();
        camMove = cam.GetComponent<CameraMove>();
        playerMove.enabled = false;
        points = 0;
        panel.DOFade(0, 1);
        StartCoroutine(CountDown());
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Points " + points;

        if(playerHealth <= 0)
        {
            gameOver = true;
        }
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(1);
        three.DOFade(1, 0);        
        three.DOFade(0, 0.5f);
        yield return new WaitForSeconds(1);
        two.DOFade(1, 0);       
        two.DOFade(0, 0.5f);
        yield return new WaitForSeconds(1);
        one.DOFade(1, 0);
        one.DOFade(0, 0.5f);
        yield return new WaitForSeconds(1);
        go.DOFade(1, 0);
        go.DOFade(0, 0.5f);
        yield return new WaitForSeconds(1);
        playerMove.enabled = true;
        camMove.canMove = true;
        StartCoroutine(GameFlow());
    }

    IEnumerator GameFlow()
    {
        if(gameWon)
        {
            camMove.canMove = false;
            winner.SetActive(true);
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene("menu");
        }
        if (!gameOver)
        {
            Debug.Log("spawn");
            yield return new WaitForSeconds(1);
            var spawner = spawners[Random.Range(0, 8)];
            spawner.GetComponent<Spawn>().SpawnRandomPrefab();
            yield return new WaitForSeconds(3f);
            
            StartCoroutine(GameFlow());
        }
        else
        {
            camMove.canMove = false;
            loser.SetActive(true);
            Destroy(player);
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene("menu");
        }
    }

}
