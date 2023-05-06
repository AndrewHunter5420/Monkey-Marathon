using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotBarScript : MonoBehaviour
{
    public GameObject monkey;
    private MonkeyScript monkeyScript;

    public GameObject pistol, slingshot, shotgun, AR;
    public GameObject pistolSelected, slinshotSelected, shotgunSelected, ARSelected;

    // Start is called before the first frame update
    void Start()
    {
        monkeyScript = monkey.GetComponent<MonkeyScript>();

        if (monkeyScript.pistolPurchased == true)
        {
            pistol.SetActive(true);
        }
        else
        {
            pistol.SetActive(false);
        }

        if (monkeyScript.slingshotPurchased == true)
        {
            slingshot.SetActive(true);
        }
        else
        {
            slingshot.SetActive(false);
        }

        if (monkeyScript.shotgunPurchased == true)
        {
            shotgun.SetActive(true);
        }
        else
        {
            shotgun.SetActive(false);
        }

        if (monkeyScript.ARPurchased == true)
        {
            AR.SetActive(true);
        }
        else
        {
            AR.SetActive(false);
        }
    }
    public void selectPistol()
    {
        pistolSelected.SetActive(true);
        slinshotSelected.SetActive(false);
        shotgunSelected.SetActive(false);
        ARSelected.SetActive(false);
    }
    public void selectSlingshot()
    {
        pistolSelected.SetActive(false);
        slinshotSelected.SetActive(true);
        shotgunSelected.SetActive(false);
        ARSelected.SetActive(false);
    }
    public void selectShotgun()
    {
        pistolSelected.SetActive(false);
        slinshotSelected.SetActive(false);
        shotgunSelected.SetActive(true);
        ARSelected.SetActive(false);
    }
    public void selectAR()
    {
        pistolSelected.SetActive(false);
        slinshotSelected.SetActive(false);
        shotgunSelected.SetActive(false);
        ARSelected.SetActive(true);
    }
}