using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuController : MonoBehaviour {

    private AudioSource audioSource;

    [SerializeField]
    private Slider menuVolumeSlider;
    [SerializeField]
    private Slider gameVolumeSlider;



    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();

    }

    


    // Update is called once per frame
    void Update () {
        audioSource.volume = menuVolumeSlider.value;
        PlayerPrefs.SetFloat("gameVolume", gameVolumeSlider.value);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(0);
        PlayerPrefs.SetInt("Level", 2);
    }
}
