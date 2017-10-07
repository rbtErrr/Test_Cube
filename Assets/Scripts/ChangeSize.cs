using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSize : MonoBehaviour {


    [SerializeField] private float range = 1f;
    [SerializeField]
    private GameObject secondPlayer;
    [SerializeField]
    private GameObject thirdPlayer;



    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {
        if (Vector3.Distance(transform.position, secondPlayer.transform.position) < range)
        {
            transform.localScale = new Vector3(0.7F, 0.7F, 0.7F);
        }
        else if(Vector3.Distance(transform.position, thirdPlayer.transform.position) < range){
            transform.localScale = new Vector3(0.7F, 0.7F, 0.7F);
        }
        else
        {
            transform.localScale = new Vector3(0.3F, 0.3F, 0.3F);
        }
    }

   
}
