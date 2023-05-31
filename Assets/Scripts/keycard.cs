using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keycard : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate (30*Time.deltaTime,30*Time.deltaTime,0);
    }
}
