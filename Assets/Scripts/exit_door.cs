using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exit_door : MonoBehaviour
{
    public GameObject winMenuUI;
    void OnTriggerStay(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        if(player != null  && Input.GetKey(KeyCode.E) && player.getKeycard() && player.getFreedom())
        {
            SceneManager.LoadScene("WinMenu");
        }
    }
}
