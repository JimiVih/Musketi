using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class doTweenAnim : MonoBehaviour
{

    public PathType pathsystem = PathType.CatmullRom;
    public Vector3[] pathval = new Vector3[3];
    public float DurationAnim;
    public float DurationBeforeTurn;
    public float RotationDirection;

    Animator anim;
    Rigidbody rb;
    public EnemyRipt enem;
    public GameObject aimObj;

    


    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(changeBool());
        anim = GetComponent<Animator>();
        //animate();
        aimObj.SetActive(false);

        //enem.enabled = false;
        anim.SetBool("runFor", true);
        transform.DOPath(pathval, DurationAnim, pathsystem);
        
         
        //enem.enabled = true;
        aimObj.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }


      IEnumerator changeBool()
       {
        yield return new WaitForSeconds(DurationBeforeTurn);
        aimObj.SetActive(true);
        anim.SetBool("runFor", false);
        transform.rotation = Quaternion.Euler(0, RotationDirection, 0);
        

    }


    

}
