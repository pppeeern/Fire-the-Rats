using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class LevelScript : MonoBehaviour { 

    public Button btnTwoOne, btnTwoTwo, btnTwoThree, btnTwoFour;
    public bool btnOneHasClick, btnTwoHasClick, btnThreeHasClick, btnFourHasClick = false;

    public void ReturnToMenu() {
        SceneManager.LoadSceneAsync(0);
    }

    public void PreviousScene()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void buttonOneClicked() { 
        btnTwoOne.interactable = false;
        btnTwoOne.Select();
    }

    public void buttonTwoClicked()
    {
        btnTwoOne.Select();
        btnTwoTwo.interactable = false;
    }

    public void buttonThreeClicked()
    {
        btnTwoOne.Select();
        btnTwoThree.interactable = false;
    }

    public void buttonFourClicked()
    {
        btnTwoOne.Select();
        btnTwoFour.interactable = false;
    }

    public void DisableAllButton()
    {
        btnTwoOne.interactable = false;
        btnTwoTwo.interactable = false;
        btnTwoThree.interactable = false;
        btnTwoFour.interactable = false;
    }
}
