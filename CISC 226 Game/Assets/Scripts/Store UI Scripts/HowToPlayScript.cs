using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayScript : MonoBehaviour
{
    public GameObject mainMenuScreen;

    public void BackButton()
    {
        this.gameObject.SetActive(false);
        mainMenuScreen.SetActive(true);
    }
}
