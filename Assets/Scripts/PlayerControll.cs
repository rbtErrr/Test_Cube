using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour {

    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private VirtualJoystick joystick;
    private CharacterController characterController;


    // Use this for initialization
    void Start () {
        characterController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update () {
        Vector3 moveDirection = new Vector3(joystick.Horizontal(), 0, joystick.Vertical());
        //Debug.Log(moveDirection);
        if (characterController.enabled == true) { 
            characterController.SimpleMove(moveDirection * moveSpeed);
        }

    }
}
