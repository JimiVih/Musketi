using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mana : MonoBehaviour
{

    public float MANA;
    public ParticleSystem manaPart;

    private void Start()
    {
        gameObject.GetComponent<BoxCollider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            var barScript = coll.GetComponent<Bars>();
            barScript.Mana += MANA;
            StartCoroutine(StopMana());
        }
    }

    IEnumerator StopMana()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        manaPart.Stop();
        gameObject.GetComponentInParent<EnemyRipt>().StartDestroying();
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

}
