using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool crouching;
    public bool noRobotDetect;
    public GameObject GetKeycard;
    public GameObject FreePartner;
    public GameObject Escape;


    Vector3 velocity;
    bool isGrounded;

    BoxCollider c;
    public GameObject cameraObj;
    static public bool keycardCollected;
    static public bool freedPartner;

    public bool isSpotted;
    public GameObject cardCheckpoint;

    void Start()
    {
        if(keycardCollected && !freedPartner)
        {
            controller.enabled = false;
            controller.transform.position = cardCheckpoint.transform.position;
            controller.enabled = true;
        }
        Time.timeScale = 1f;
        c = GetComponent<BoxCollider>();
        
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(Input.GetKeyDown(KeyCode.C))
        {
            if(crouching)
            {
                cameraObj.transform.position = cameraObj.transform.position + new Vector3(0f,3f,0f);
                c.center = new Vector3(0f, 1f, 0f);
                c.size = new Vector3(1f, 6.5f, 1f);
                controller.height = 6.5f;
                controller.center = new Vector3(0f, 1f, 0f);
                crouching = false;
                speed = 12f;
            }
            else
            {
                cameraObj.transform.position = cameraObj.transform.position - new Vector3(0f,3f,0f);
                c.size = new Vector3(1f, 3f, 1f);
                c.center = new Vector3(0f, -1f, 0f);
                controller.height = 3f;
                controller.center = new Vector3(0f, -1f, 0f);
                crouching = true;
                speed = 6f;
            }
        }

        if(keycardCollected && !freedPartner)
        {
            FreePartner.SetActive(true);
            GetKeycard.SetActive(false);
        }
        else if(keycardCollected && freedPartner)
        {
            Escape.SetActive(true);
            FreePartner.SetActive(false);
        }
        else
        {
            GetKeycard.SetActive(true);
        }

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime); 
    }
    public void collectedCard()
    {
        keycardCollected = true;
    }
    public void parterFree()
    {
        freedPartner = true;
    }
    public bool getKeycard()
    {
        return keycardCollected;
    }
    public bool getFreedom()
    {
        return freedPartner;
    }

    public void resetValues()
    {
        freedPartner = false;
        keycardCollected = false;
    }
}