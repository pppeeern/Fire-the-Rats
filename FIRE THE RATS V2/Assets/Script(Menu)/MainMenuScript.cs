using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    AudioScript audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioScript>();
    }

    public void PlayGame() {
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame() { 
        Application.Quit();
    }
}
