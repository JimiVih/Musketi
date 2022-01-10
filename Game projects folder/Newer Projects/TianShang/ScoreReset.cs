using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreReset : MonoBehaviour
{
    public PointManager pointManager;
    // Start is called before the first frame update
    void Start()
    {
        pointManager.ResetScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
