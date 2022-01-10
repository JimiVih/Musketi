using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{

    public Image panel;
    public float slowdownFactor = 0.05f;
    public float slowdownLength = 2f;
    public bool playerDead;

    public GameObject level2intro;
    public GameObject player;

    public AudioSource Music;
    public AudioClip LevelMusic;

    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(WaitForTheLoad());
        playerDead = false;
        Time.timeScale = 1;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }

    // Update is called once per frame
    void Update()
    {
       // if (Input.GetMouseButtonDown(0))
       // {
         //   TimeSlower();
            
       // }

       // Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
     //   Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);

       
    }

    public void TimeSlower()
    {
        print("slowTime");
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
        playerDead = true;
        Music.DOFade(0, 0.45f);

    }

    IEnumerator WaitForTheLoad()
    {
        yield return new WaitForSeconds(3);
        var panelAlpha = panel.color.a;
        panelAlpha = 1f;
        panel.DOFade(0, 4);              
        Music.clip = LevelMusic;
        Music.Play();
        Music.DOFade(0.23f, 5);

        if(level2intro == null)
        {
            player.GetComponent<PlayerScript1>().canWalk = true;
        }
        else
        {
            level2intro.SetActive(true);
        }
    }

    IEnumerator SpeedupTime()
    {
        
        
        yield return new WaitForSeconds(0.1f);
    }

}
