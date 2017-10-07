using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControll : MonoBehaviour {

    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private VirtualJoystick joystick;
    private CharacterController characterController;
    private NavMeshAgent nav;
    [SerializeField]
    private float timer;
    [SerializeField]
    private float speed;
    [SerializeField]
    private int newTargetTimer;
    private Vector3 target;
    Vector3 moveDirection;


    // Use this for initialization
    void Start () {
        characterController = GetComponent<CharacterController>();
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector3(joystick.Horizontal(), 0, joystick.Vertical());
        //Debug.Log(moveDirection);
        if (characterController.enabled == true)
        {
            nav.enabled = false;
            characterController.SimpleMove(moveDirection * moveSpeed);
        }
        else
        {
            nav.enabled = true;
            timer += Time.deltaTime;

            if (timer >= newTargetTimer)
            {
                nav.speed = speed;
                newTarget();
                timer = 0;
            }

        }
    
    }

    void newTarget()
    {
        float xPos = Random.Range(-6, 0);
        float zPos = Random.Range(-6, 0);

        target = new Vector3(xPos, transform.position.y, zPos);
        nav.SetDestination(target);
    }
}
