using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCast : MonoBehaviour
{
    public float sphereRadius;
    public float maxDistance;
    public LayerMask layerMask;

    public CheckCollll juu;

    public GameObject CurrentHitObject;

    private Vector3 origin;
    private Vector3 direction;

    public RaycastHit hit;

    public collectables colll;


    public GameObject salama;

    public Animator alusAn;

    private float currentHitDistance;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        origin = transform.position;
        direction = transform.forward;
        
        
        if(Physics.SphereCast(origin, sphereRadius, direction, out hit, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal))
        {
            CurrentHitObject = hit.transform.gameObject;
            currentHitDistance = hit.distance;
        }
        else
        {
            currentHitDistance = maxDistance;
            CurrentHitObject = null;

        }



    }

    public void rayHit()
    {
        CurrentHitObject = hit.transform.gameObject;
        origin = transform.position;
        direction = transform.forward;

        if (CurrentHitObject.tag == "lightTrigEvent")
        {
            var lato = hit.transform.gameObject;

            var playSund = salama.GetComponent<AudioSource>();
            playSund.Play();
            alusAn.SetBool("go to another place", true);
            Destroy(lato);

        
        }

        if (CurrentHitObject.tag == "collectables")
        {
            var luostar = hit.transform.gameObject;

            var playSund = salama.GetComponent<AudioSource>();
            playSund.Play();
            colll.collected += 1;
            juu.NextAnimationPLZ();
            Destroy(luostar);

        }



        

    }



    private void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.red;
        Debug.DrawLine(origin, origin + direction * currentHitDistance);
        Gizmos.DrawWireSphere(origin + direction * currentHitDistance, sphereRadius);


    }



}
