using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class detection : MonoBehaviour
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
            if(!player.GetComponent<PlayerMovement>().noRobotDetect)
            { 
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Time.timeScale = 0f;
            }
        }
        else if(other.gameObject == partner)
        {
            if(!partner.GetComponent<partnermove>().noRobotDetect)
            { 
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Time.timeScale = 0f;
            }
        }
    }
}
