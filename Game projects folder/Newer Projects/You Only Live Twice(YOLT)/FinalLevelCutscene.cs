using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLevelCutscene : MonoBehaviour
{

    public GameObject cam1, cam2, cam3;
    public GameObject player1, player2, boss;
    public GameObject photograph;
    public GameObject dialog;

    Animator playerAnim;
    Animator bossAnim;

    public 

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = player2.GetComponent<Animator>();
        bossAnim = boss.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(startCutscene());
        }
    }

    IEnumerator startCutscene()
    {
        cam1.SetActive(false);        
        cam2.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        boss.SetActive(true);
        photograph.SetActive(true);
        yield return new WaitForSeconds(1);
        
        player1.SetActive(false);
        player2.SetActive(true);
        yield return new WaitForSeconds(6);
        cam3.SetActive(true);
        dialog.SetActive(true);
    }

}
