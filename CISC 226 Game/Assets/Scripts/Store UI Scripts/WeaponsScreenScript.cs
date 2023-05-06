using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsScreenScript : MonoBehaviour
{
    public MoneyTextScript moneyScript;

    public GameObject weaponsScreen;
    public GameObject pistolScreen;
    public GameObject slingshotScreen;
    public GameObject shotgunScreen;
    public GameObject ARScreen;
    public GameObject mainMenuScreen;

    public GameObject pistolPriceText;
    public GameObject pistolDetailsText;
    public GameObject slingshotPriceText;
    public GameObject slingshotDetailsText;
    public GameObject shotgunPriceText;
    public GameObject shotgunDetailsText;
    public GameObject ARPriceText;
    public GameObject ARDetailsText;

    // probably want to get this from save file
    public bool pistolPurchased = false;
    public bool slingshotPurchased = false;
    public bool shotgunPurchased = false;
    public bool ARPurchased = false;

    public int slingshotPrice = 50;
    public int shotgunPrice = 400;
    public int ARPrice = 1700;

    public void loadValues()
    {
        if (pistolPurchased)
        {
            pistolPriceText.SetActive(false);
            pistolDetailsText.SetActive(true);
        }
        else
        {
            pistolPriceText.SetActive(true);
            pistolDetailsText.SetActive(false);
        }

        if (slingshotPurchased)
        {
            slingshotPriceText.SetActive(false);
            slingshotDetailsText.SetActive(true);
        }
        else
        {
            slingshotPriceText.SetActive(true);
            slingshotDetailsText.SetActive(false);
        }

        if (shotgunPurchased)
        {
            shotgunPriceText.SetActive(false);
            shotgunDetailsText.SetActive(true);
        }
        else
        {
            shotgunPriceText.SetActive(true);
            shotgunDetailsText.SetActive(false);
        }

        if (ARPurchased)
        {
            ARPriceText.SetActive(false);
            ARDetailsText.SetActive(true);
        }
        else
        {
            ARPriceText.SetActive(true);
            ARDetailsText.SetActive(false);
        }
    }
    
    public void PistolButton()
    {
        if (pistolPurchased)
        {
            weaponsScreen.SetActive(false);
            pistolScreen.SetActive(true);
        }
        else
        {
            pistolPurchased = true;

            pistolPriceText.SetActive(false);
            pistolDetailsText.SetActive(true);
        }
    }

    public void SlingshotButton()
    {
        if (slingshotPurchased)
        {
            weaponsScreen.SetActive(false);
            slingshotScreen.SetActive(true);
        }
        else if (slingshotPrice <= moneyScript.getGold())
        {
            moneyScript.SubtractGold(slingshotPrice);

            slingshotPurchased = true;

            slingshotPriceText.SetActive(false);
            slingshotDetailsText.SetActive(true);
        }
    }

    public void ShotgunButton()
    {
        if (shotgunPurchased)
        {
            weaponsScreen.SetActive(false);
            shotgunScreen.SetActive(true);
        }
        else if (shotgunPrice <= moneyScript.getGold())
        {
            moneyScript.SubtractGold(shotgunPrice);

            shotgunPurchased = true;

            shotgunPriceText.SetActive(false);
            shotgunDetailsText.SetActive(true);
        }
    }

    public void ARButton()
    {
        if (ARPurchased)
        {
            weaponsScreen.SetActive(false);
            ARScreen.SetActive(true);
        }
        else if (ARPrice <= moneyScript.getGold())
        {
            moneyScript.SubtractGold(ARPrice);

            ARPurchased = true;

            ARPriceText.SetActive(false);
            ARDetailsText.SetActive(true);
        }
    }

    public void BackButton()
    {
        weaponsScreen.SetActive(false);
        mainMenuScreen.SetActive(true);
    }
}
