using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    public void ReturnToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void NextScene()
    {
        SceneManager.LoadSceneAsync(2);
    }
}
