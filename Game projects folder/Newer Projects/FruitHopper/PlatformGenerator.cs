using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public Transform platformPlacer;
    public Transform platformGeneratorPoint;
    private Transform lastTransformPlaced;
    public Transform maxDistanceTrans;

    public float minDistance;
    public float maxDistance;
    float currentDistanceFromPlatformPlacer;    
    float randomDistance;
    public float Yaxis;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        maxDistanceTrans.position = new Vector2(maxDistanceTrans.position.x, transform.position.y);

        if (transform.position.y < platformGeneratorPoint.position.y)
        {
            GeneratePlatformPlacer();
        }
        currentDistanceFromPlatformPlacer = Vector3.Distance(transform.position, lastTransformPlaced.position);
    }
    
    void GeneratePlatformPlacer()
    {
        
        randomDistance = Random.Range(minDistance, maxDistance);
        Yaxis = randomDistance;
        transform.position = new Vector2(transform.position.x, transform.position.y + Yaxis);
        Instantiate(platformPlacer, transform, false);
        lastTransformPlaced = transform.GetChild(0);
        lastTransformPlaced.parent = null;

    }
}
