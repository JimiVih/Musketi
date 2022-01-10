using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeronScript : MonoBehaviour
{

    public Transform followTarget;
    public float flyingSpeed;

    public string followTargetName;
    bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        
        Physics.IgnoreCollision(GetComponent<Collider>(), GameObject.Find("FishBowlWalls").GetComponent<Collider>());
        transform.parent = null;
        followTarget = GameObject.Find(followTargetName).GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            transform.position = Vector3.MoveTowards(transform.position, followTarget.position, flyingSpeed * Time.deltaTime);
            transform.LookAt(followTarget);
        }

        if (GameObject.Find("GameManager").GetComponent<GameManager>().koiIsDead == true)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        
    }

    public void Hit()
    {        
        PointManager.score += 50;
        isDead = true;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
