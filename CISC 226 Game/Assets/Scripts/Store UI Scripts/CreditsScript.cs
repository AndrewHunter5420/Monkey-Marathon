using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScript : MonoBehaviour
{
    public GameObject mainMenuScreen;

    public void BackButton()
    {
        this.gameObject.SetActive(false);
        mainMenuScreen.SetActive(true);
    }
}
