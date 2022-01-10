using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Bars : MonoBehaviour
{
    GameManager gameManager;
    public List<Collider> RagdollParts = new List<Collider>();
    public List<Rigidbody> ragRB = new List<Rigidbody>();

    private Rigidbody parentRB;

    public BoxCollider upper, head;
    public CapsuleCollider down;

    public Rigidbody torsoRB;
    public float forcePower;

    Animator anim;
    public Image panel;

    public float Health = 1;
    public float Mana;
    float maxMana;
    public Image healthBar;
    public Image manaBar;

    public string level_name;

 

    // Start is called before the first frame update
    void Start()
    {
        GameObject gmObject = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = gmObject.GetComponent<GameManager>();
        anim = GetComponent<Animator>();
        healthBar.fillAmount = Health;
        EtsiRagnukke();
        
    }

    // Update is called once per frame
    void Update()
    {

        healthBar.fillAmount = Health;
        manaBar.fillAmount = Mana;

        CheckHealth();
        CheckMana();

        

    }


    void CheckHealth()
    {
        if (Health <= 0)
        {
            AktvRagnukke();
            StartCoroutine(DeathScreen());
        }

        if (Health > 1)
        {
            Health = 1;
        }
    }

    void CheckMana()
    {
        if(Mana >= maxMana)
        {

        }
    }

    IEnumerator DeathScreen()
    {
        yield return new WaitForSeconds(0.1f);
        gameManager.TimeSlower();
        yield return new WaitForSeconds(0.3f);
        panel.DOFade(1, 0.25f);
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadScene(level_name);

    }

    public void EtsiRagnukke()
    {
        print("etsiRAG");
        Collider[] colliders = this.gameObject.GetComponentsInChildren<Collider>();
        Rigidbody[] rbs = this.gameObject.GetComponentsInChildren<Rigidbody>();

        foreach (Collider c in colliders)
        {
            if (c.gameObject != this.gameObject)
            {

                c.isTrigger = true;
                RagdollParts.Add(c);
                upper.isTrigger = false;
                down.isTrigger = false;
               

            }

        }

        foreach (Rigidbody r in rbs)
        {

            if (r.gameObject != this.gameObject)
            {
                ragRB.Add(r);
                r.useGravity = false;
                r.isKinematic = true;

            }


        }


    }


    public void AktvRagnukke()
    {

        

        
        Collider[] colliders = this.gameObject.GetComponentsInChildren<Collider>();
        Rigidbody[] rbs = this.gameObject.GetComponentsInChildren<Rigidbody>();

        foreach (Collider c in colliders)
        {
            if (c.gameObject != this.gameObject)
            {
                anim.enabled = false;
                c.isTrigger = false;
                head.isTrigger = true;
                upper.isTrigger = true;
                down.isTrigger = true;
               
            }

        }

        foreach (Rigidbody r in rbs)
        {

            if (r.gameObject != this.gameObject)
            {
                r.useGravity = true;
                r.isKinematic = false;

            }


        }



        torsoRB.AddForce(-transform.forward * forcePower);

        Destroy(GetComponent<BoxCollider>());
        Destroy(GetComponent<CapsuleCollider>());
        
        Destroy(GetComponent<Rigidbody>());
        
    }


}
