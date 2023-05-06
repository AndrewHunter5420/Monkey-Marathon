using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public GameObject storeScreen, optionScreen, upgradesScreen, howToScreen, creditScreen;

    public void PlayButton()
    {
        gameObject.SetActive(false);
        storeScreen.SetActive(true);
        upgradesScreen.SetActive(true);


    }

    public void OptionsButton()
    {
        gameObject.SetActive(false);
        optionScreen.SetActive(true);
    }

    public void HowToButton()
    {
        gameObject.SetActive(false);
        howToScreen.SetActive(true);
    }

    public void CreditsButton()
    {
        gameObject.SetActive(false);
        creditScreen.SetActive(true);
    }

    public void ExitButton()
    {
        storeScreen.GetComponentInChildren<StoreButtonsScript>().SaveData();

        Application.Quit();
    }
}
