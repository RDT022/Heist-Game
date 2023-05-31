using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KeyCardDetection : MonoBehaviour
{
    GameObject players;

     public RectTransform prefab;
    private Transform player;
    private Text distanceText;

    private Vector3 offset = new Vector3(0, 1.25f, 0);

    private RectTransform waypoint;

    void Start()
    {

        var canvas = GameObject.Find("Waypoints").transform;

        waypoint = Instantiate(prefab, canvas);

        distanceText = waypoint.GetComponentInChildren<Text>();

        player = GameObject.Find("First Person Player").transform;

        players = GameObject.FindGameObjectWithTag("Player");
        if (players.GetComponent<PlayerMovement>().getKeycard())
        {
            waypoint.gameObject.SetActive(false);
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
    void OnTriggerStay(Collider other)
    {
        PlayerMovement players = other.GetComponent<PlayerMovement>();
        if(players != null  && Input.GetKey(KeyCode.E))
        {
            players.collectedCard();
            waypoint.gameObject.SetActive(false);
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
    void Update()
    {
        var screenPos = Camera.main.WorldToScreenPoint(transform.position + offset);

        waypoint.position = screenPos;
        waypoint.gameObject.SetActive(screenPos.z > 0);

        distanceText.text = Vector3.Distance(player.position, transform.position).ToString("0") + " m";


    }
}
