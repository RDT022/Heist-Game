using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{
    public CharacterController characterController;
    public float standing = 3f;
    public float crouching = 1f;
    void Start ()
    {
        characterController = gameObject.GetComponent<CharacterController>();
    }

    private void Update ()
    {
        if(Input.GetKey(KeyCode.LeftControl))
        {
            characterController.height = crouching;
        }
        else
        {
            characterController.height = standing;
            characterController.center = new Vector3(0, -6, 0);
        }
    }   
}
