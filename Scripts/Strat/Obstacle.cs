using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    //Movement Parameters
    public float speed = 15f;
    public float weavingDistance = 15f;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void ApplyStrategy(IManeuver strategy)
    {
        strategy.Maneuver(this);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
