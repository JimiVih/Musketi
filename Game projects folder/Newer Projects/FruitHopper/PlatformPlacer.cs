using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPlacer : MonoBehaviour
{
    public Transform[] platforms;
    Transform currentPlatform;
    Transform lastPlatform;
    public Transform maxDistanceTrans;

  

    int randomPlatformNumber;
    [SerializeField]
    float NewrandomDistance;
    [SerializeField]
    float OldrandomDistance;
    float currentPlatformWidth;
    [SerializeField]
    float maxDistance;
    float curPlatDistfromMax;

    bool isOverZero;

    // Start is called before the first frame update
    void Start()
    {
       // transform.parent = null;
        maxDistance = Vector2.Distance(transform.position, maxDistanceTrans.position);
        
        PlacePlatform();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void PlacePlatform()
    {
        

        randomPlatformNumber = Random.Range(0, platforms.Length);
        NewrandomDistance = Random.Range(-10, 10);
        Instantiate(platforms[randomPlatformNumber], transform, false);
        lastPlatform = transform.GetChild(0);
        lastPlatform.position = new Vector2(NewrandomDistance, lastPlatform.position.y);
        
        
        if(lastPlatform.position.x < 0)
        {
            isOverZero = false;
        }
        else if(lastPlatform.position.x >= 0)
        {
            isOverZero = true;
        }

        if(isOverZero == true && NewrandomDistance < 8)
        {
            randomPlatformNumber = Random.Range(0, platforms.Length);
            Instantiate(platforms[randomPlatformNumber], transform, false);
            currentPlatformWidth = lastPlatform.GetComponent<BoxCollider2D>().size.x;
            currentPlatformWidth /= 2;
            OldrandomDistance = NewrandomDistance;
            OldrandomDistance -= currentPlatformWidth;
            NewrandomDistance = Random.Range(-8, OldrandomDistance);
            lastPlatform = transform.GetChild(0);            
            lastPlatform.position = new Vector2(NewrandomDistance, lastPlatform.position.y);

        }


        if (isOverZero == false && NewrandomDistance > -8)
        {
            randomPlatformNumber = Random.Range(0, platforms.Length);
            Instantiate(platforms[randomPlatformNumber], transform, false);
            currentPlatformWidth = lastPlatform.GetComponent<BoxCollider2D>().size.x;
            OldrandomDistance = NewrandomDistance;
            OldrandomDistance -= currentPlatformWidth;
            NewrandomDistance = Random.Range(-8, OldrandomDistance);
            lastPlatform = transform.GetChild(0);
            lastPlatform.position = new Vector2(NewrandomDistance, lastPlatform.position.y);
        }

    }
}
