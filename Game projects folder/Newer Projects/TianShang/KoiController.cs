using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoiController : MonoBehaviour
{
    Rigidbody rb;
    public GameObject oppositeKoiFish;
    public Camera cam;
    public float thrust;
    public float tailFollowSpeed;
    public float rotationSpeed;
    public Transform head;
    public LayerMask mouseMask;

    public Transform headAim;
    public Transform lookAtTrans;
    public Transform sword;
    public Transform swordHolderPosition;
    public Transform Yin;
    public Transform Yang;

    public string enemyTag;

    public bool isActive;
    public bool isDead;
    public bool isYin;
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        rb = GetComponent<Rigidbody>();
        Physics.IgnoreCollision(oppositeKoiFish.GetComponent<Collider>(), GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            
            if (isActive)
            {
                GetInputs();
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, mouseMask))
                {

                    lookAtTrans.position = hit.point;

                }

                if (isYin)
                {
                    Yin.position = transform.position;
                   Yang.position = oppositeKoiFish.transform.position;
                }

                if (!isYin)
                {
                    Yang.position = transform.position;
                    Yin.position = oppositeKoiFish.transform.position;
                }

            }

            sword.position = swordHolderPosition.position;


            transform.rotation = Quaternion.Slerp(transform.rotation, head.rotation, rotationSpeed * Time.deltaTime);
            headAim.position = lookAtTrans.position;
            head.LookAt(lookAtTrans, Vector3.up * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        if (!isDead)
        {
            Vector3 playerPos = head.position;
            Vector3 targetPos = lookAtTrans.position;
            Vector3 targetDir = playerPos - targetPos;
            Debug.DrawRay(head.transform.position, head.transform.forward, Color.yellow);
            //rb.AddRelativeForce(head.forward.normalized * thrust, ForceMode.Impulse);
            rb.AddForce(-targetDir.normalized * thrust, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isYin)
        {
            if (collision.transform.tag == "YangHeron")
            {
                isDead = true;
                oppositeKoiFish.GetComponent<KoiController>().isDead = true;
            }
        }


        if (!isYin)
        {
            if (collision.transform.tag == "YinHeron")
            {
                isDead = true;
                oppositeKoiFish.GetComponent<KoiController>().isDead = true;
            }
        }
    }

    void GetInputs()
    {
        if(Input.GetMouseButtonDown(1))
        {
            //if(isYin)
            //{
            //    StartCoroutine(ChangeToYang());
            //}

            //if (!isYin)
            //{
            //    StartCoroutine(ChangeToYin());
            //}

        }
    }

    IEnumerator ChangeToYang()
    {
        yield return new WaitForSeconds(0.2f);
        isYin = false;
        oppositeKoiFish.GetComponent<KoiController>().isYin = true;
    }

    IEnumerator ChangeToYin()
    {
        yield return new WaitForSeconds(0.2f);
        isYin = true;
        oppositeKoiFish.GetComponent<KoiController>().isYin = false;
    }

}
