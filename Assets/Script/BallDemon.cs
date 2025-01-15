using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDemon : MonoBehaviour
{
    AIPlanner planner;

    // Start is called before the first frame update
    void Start()
    {
        planner = GetComponent<AIPlanner>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
