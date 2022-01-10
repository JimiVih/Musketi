using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopViewMovement : MonoBehaviour
{
    private float nextTimeToFire = 0f;
    public float fireRate;
    public AudioSource gun;
    public AudioClip gunsShot;
    public GameObject GunTip;
    public GameObject bulletPrefab;
    public float range;

    private float inputMovementX;
    private float inputMovementZ;
    private int velocity = 1;
    private float angle;
    public float speed;

    private Camera mainCamera;

    public LayerMask mouseAimMask;
    public Transform targetTransform;
    Rigidbody rb;
    Animator playerAnim;

    Vector3 eulerAngleVelocity;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
        playerAnim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        inputMovementX = Input.GetAxis("Horizontal");
        inputMovementZ = Input.GetAxis("Vertical");

        playerAnim.SetFloat("SpeedX", inputMovementX);
        playerAnim.SetFloat("SpeedZ", inputMovementZ);

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, mouseAimMask)) ;
        {
            targetTransform.position = hit.point;
        }

       // if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
      //  {
        //    nextTimeToFire = Time.time + 1f / fireRate;
          //  Fire();
      //  }

    }

    void FixedUpdate()
    {
        var targetDir = targetTransform.position - transform.position;
        var forward = transform.forward;
        var localTarget = transform.InverseTransformPoint(targetTransform.position);

        angle = Mathf.Atan2(localTarget.x, localTarget.z) * Mathf.Rad2Deg;

        eulerAngleVelocity = new Vector3(0, angle, 0);
        Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * velocity);
        rb.MoveRotation(rb.rotation * deltaRotation);

        rb.velocity = new Vector3(inputMovementX * speed, rb.velocity.y, rb.velocity.z);
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, inputMovementZ * speed);
    }

    //void Fire()
    //{
    //    print("KEKW");
    //    Instantiate(bulletPrefab, GunTip.transform.position, GunTip.transform.rotation);
    //    gun.clip = gunsShot;
    //    gun.Play();

    //    RaycastHit hit;
    //    if (Physics.Raycast(GunTip.transform.position, GunTip.transform.forward, out hit, range))
    //    {
    //        Debug.Log(hit.transform.name);
    //    }

    //}


    private void OnAnimatorIK()
    {

        playerAnim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
        playerAnim.SetIKPosition(AvatarIKGoal.RightHand, targetTransform.position);

    }



}
