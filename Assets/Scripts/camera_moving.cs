using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_moving : MonoBehaviour
{

    public float speed;
    public float rotStartAngle;
    public float rotEndAngle;
    public float yRot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float r = Mathf.SmoothStep(rotStartAngle,rotEndAngle,Mathf.PingPong(Time.time * speed,1));
        transform.rotation = Quaternion.Euler(r,yRot,0);
    }
}
