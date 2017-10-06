using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour {

    public static GameController instance = null;


    private AudioSource audioSource;

    [SerializeField] GameObject[] bonusUpPoints;
    [SerializeField]
    GameObject bonusPowerUp;
    [SerializeField]
    int maxPowerUps = 4;

    [SerializeField]
    GameObject cubePlayer;
    [SerializeField]
    GameObject spherePlayer;
    [SerializeField]
    GameObject capsulePlayer;

    [SerializeField]
    Text Score;
    private int scorePoint = 0;

    private GameObject newBonusUp;
    private float currentSpawnTime = 0;
    private float powerUpSpawnTime = 5;
    private float currentBonusUpSpawnTime = 0;
    private int powerups = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

    }

    public void TogglePlayer(GameObject player)
    { 
        if(player.tag == "Cube")
        {
            player.GetComponent<CharacterController>().enabled = true;
            spherePlayer.GetComponent<CharacterController>().enabled = false;
            capsulePlayer.GetComponent<CharacterController>().enabled = false;
        }else if(player.tag == "Capsule")
        {
            player.GetComponent<CharacterController>().enabled = true;
            spherePlayer.GetComponent<CharacterController>().enabled = false;
            cubePlayer.GetComponent<CharacterController>().enabled = false;
        }else if(player.tag == "Sphere")
        {
            player.GetComponent<CharacterController>().enabled = true;
            capsulePlayer.GetComponent<CharacterController>().enabled = false;
            cubePlayer.GetComponent<CharacterController>().enabled = false;
        }
    }

    // Use this for initialization
    void Start () {
        StartCoroutine(bonusUpSpawn());

        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("gameVolume");
    }

    public void RegisterPowerUps()
    {
        powerups++;
    }

    public void UnRegisterPowerUps()
    {
        powerups--;
    }

    IEnumerator bonusUpSpawn()
    {
        if (currentBonusUpSpawnTime > powerUpSpawnTime)
        {
            currentBonusUpSpawnTime = 0;

            if (powerups < maxPowerUps)
            {
                int randomNumber = Random.Range(0, bonusUpPoints.Length - 1);
                GameObject spawnBonusUpsLocation = bonusUpPoints[randomNumber];
               
                    newBonusUp = Instantiate(bonusPowerUp) as GameObject;
               

                newBonusUp.transform.position = spawnBonusUpsLocation.transform.position;
            }
        }

        yield return null;
        StartCoroutine(bonusUpSpawn());
    }   

    // Update is called once per frame
    void Update () {
        currentBonusUpSpawnTime += Time.deltaTime;
    }

    public void SetScoreTxt()
    {
        scorePoint++;
        Score.text = "Score: " + scorePoint;
    }
}
