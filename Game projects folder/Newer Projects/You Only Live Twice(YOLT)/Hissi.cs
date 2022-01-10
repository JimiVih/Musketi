using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hissi : MonoBehaviour
{
    newEnemySpawner enemySpawner;
    public GameObject elevatorDoors;
    public GameObject execute_text;
    public GameObject timerObj;
    public Animator elevatorAnim;

    float timer;
    public float time;

    public TMP_Text timerText;

    AudioSource elevatorAudSource;
    public AudioClip elevatorAudClip;

    bool timerActive;

    // Start is called before the first frame update
    void Start()
    {
        elevatorAudSource = GetComponent<AudioSource>();
        enemySpawner = GetComponent<newEnemySpawner>();
        timer = time;
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = "" + timer;

        if (timerActive)
        {
            timer -= Time.deltaTime;

            if(timer <= 0)
            {
                OpenElevator();
            }

        }
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            execute_text.SetActive(true);
            if (Input.GetKeyUp(KeyCode.E))
            {
                print("activate elevator");
                Activate_Elevator();
            }
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        execute_text.SetActive(false);
    }


    void Activate_Elevator()
    {
        timerActive = true;
        enemySpawner.enabled = true;
        timerObj.SetActive(true);
    }

    void OpenElevator()
    {
        elevatorAnim.SetBool("open", true);
        timer = 0;
        timerActive = false;
        print("openElevator");
        enemySpawner.spawn = false;
        elevatorAudSource.clip = elevatorAudClip;
        elevatorAudSource.Play();
    }

}
