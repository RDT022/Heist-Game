using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class art_alley : MonoBehaviour
{
    GameObject player;
    GameObject partner;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        partner = GameObject.FindGameObjectWithTag("Partner");
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            player.GetComponent<PlayerMovement>().noRobotDetect = true;
        }
        else if(other.gameObject == partner)
        {
            partner.GetComponent<partnermove>().noRobotDetect = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            player.GetComponent<PlayerMovement>().noRobotDetect = false;
        }
        else if(other.gameObject == partner)
        {
            partner.GetComponent<partnermove>().noRobotDetect = false;
        }
    }
}
