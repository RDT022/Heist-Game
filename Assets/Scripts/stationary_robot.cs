using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stationary_robot : MonoBehaviour
{

    public float speed;
    public float rotStartAngle;
    public float rotEndAngle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float r = Mathf.SmoothStep(rotStartAngle,rotEndAngle,Mathf.PingPong(Time.time * speed,1));
        transform.rotation = Quaternion.Euler(0,r,0);
    }
}
