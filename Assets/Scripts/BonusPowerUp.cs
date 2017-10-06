using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPowerUp : MonoBehaviour {

    private GameObject player;
    [SerializeField]
    private float lifetime;

    private float currentLifeTime;

    // Use this for initialization
    void Start () {
        GameController.instance.RegisterPowerUps();
        Destroy(gameObject, lifetime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cube")
        {
            DestroyBonuse();
        }
        else if(other.tag == "Sphere")
        {
            DestroyBonuse();
        }
        else if(other.tag == "Capsule")
        {
            DestroyBonuse();
        }
    }

    private void DestroyBonuse()
    {
        Destroy(gameObject);
        GameController.instance.UnRegisterPowerUps();
        GameController.instance.SetScoreTxt();
    }

    // Update is called once per frame
    void Update () {
        currentLifeTime += Time.deltaTime;
        if(lifetime == currentLifeTime)
        {
            GameController.instance.UnRegisterPowerUps();
        }
    }
}
