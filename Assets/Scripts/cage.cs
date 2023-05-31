using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cage : MonoBehaviour
{
    public GameObject cageObject;
    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player.GetComponent<PlayerMovement>().getFreedom())
        {
            Destroy(cageObject);
        }
    }
    void OnTriggerStay(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        if(player != null  && Input.GetKey(KeyCode.E) && player.getKeycard() && !player.getFreedom())
        {
            player.parterFree();
            Destroy(cageObject);
        }
    }
}
