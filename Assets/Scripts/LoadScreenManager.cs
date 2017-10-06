using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScreenManager : MonoBehaviour {

    [SerializeField]
    private GameObject LoadingScreenObject;
    [SerializeField]
    private Slider slider;

    AsyncOperation async;

	// Use this for initialization
	void Start() {
        if(PlayerPrefs.GetInt("Level") == 2)
        {
            StartCoroutine(LoadingScreen(2));
            PlayerPrefs.SetInt("Level", 0);
        }else if(PlayerPrefs.GetInt("Level") != 2) { 
            StartCoroutine(LoadingScreen(1));
        }
    }

    // public void LoadScreenCoroutine()
    // {
    //}

    IEnumerator LoadingScreen(int sceneIndex)
    {
        LoadingScreenObject.SetActive(true);
        async = SceneManager.LoadSceneAsync(0);
        async.allowSceneActivation = false;

        while(async.isDone == false)
        {
            slider.value = async.progress;
            if(async.progress == 0.9f)
            {
                slider.value = 1f;
                async.allowSceneActivation = true;
                SceneManager.LoadScene(sceneIndex);
            }

            yield return new WaitForSeconds(2f);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
