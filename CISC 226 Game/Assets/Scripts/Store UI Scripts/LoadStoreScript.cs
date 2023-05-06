using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadStoreScript : MonoBehaviour
{
    public GameObject storeScreen, mainMenuScreen, optionsScreen, howToScreen, creditsScreen;
    public GameObject upgradeScreen, weaponsScreen, pistolScreen, slingshotScreen, shotgunScreen, ARScreen, moneyText;

    public Slider toggleSneakSlider, musicVolSlider, SFXVolSlider;

    void Start()
    {
        SceneManagerScript sceneManagerScript = GameObject.Find("Scene Manager").GetComponent<SceneManagerScript>();
        if (sceneManagerScript.load == "main")
        {
            storeScreen.SetActive(false);
            mainMenuScreen.SetActive(true);

            optionsScreen.SetActive(false);
            howToScreen.SetActive(false);
            creditsScreen.SetActive(false);
        }
        else if (sceneManagerScript.load == "store")
        {
            storeScreen.SetActive(true);
            mainMenuScreen.SetActive(false);

            optionsScreen.SetActive(false);
            howToScreen.SetActive(false);
            creditsScreen.SetActive(false);
        }


        load();
    }

    public void load()
    {
        // Option Sliders:
        toggleSneakSlider.value = PlayerPrefs.GetInt("toggleSneak", 0);
        musicVolSlider.value = PlayerPrefs.GetInt("musicVol", 10);
        SFXVolSlider.value = PlayerPrefs.GetInt("SFXVol", 10);
        

        int value;

        // Upgrades Screen:
        //----------------
        UpgradesButtonsScript upgradeButtonScript = upgradeScreen.GetComponent<UpgradesButtonsScript>();

        upgradeButtonScript.healthPrice = PlayerPrefs.GetInt("healthPrice", 10);
        upgradeButtonScript.sprintPrice = PlayerPrefs.GetInt("sprintPrice", 10);
        upgradeButtonScript.sneakPrice = PlayerPrefs.GetInt("sneakPrice", 10);

        value = (PlayerPrefs.GetInt("maxHealth") - upgradeButtonScript.baseHealth) / upgradeButtonScript.healthIncr;
        if (value < upgradeButtonScript.healthTopSlider.maxValue)
        {
            upgradeButtonScript.healthTopSlider.value = value;
            upgradeButtonScript.healthBottomSlider.value = 0;
        }
        else if (value <= 20) //20 is max amount of upgrades, 10 + 10 from top and bottom slider
        {
            upgradeButtonScript.healthTopSlider.value = upgradeButtonScript.healthTopSlider.maxValue;
            upgradeButtonScript.healthBottomSlider.value = value - 10;
        }
        else
        {
            Debug.LogError("value from playerpref is greater than 20, which shouldn't be allowed");
        }

        value = (PlayerPrefs.GetInt("sprintSpeed") - upgradeButtonScript.baseSprint) / upgradeButtonScript.sprintIncr;
        if (value < upgradeButtonScript.sprintTopSlider.maxValue)
        {
            upgradeButtonScript.sprintTopSlider.value = value;
            upgradeButtonScript.sprintBottomSlider.value = 0;
        }
        else if (value <= 20) //20 is max amount of upgrades, 10 + 10 from top and bottom slider
        {
            upgradeButtonScript.sprintTopSlider.value = upgradeButtonScript.sprintTopSlider.maxValue;
            upgradeButtonScript.sprintBottomSlider.value = value - 10;

        }
        else
        {
            Debug.LogError("value from playerpref is greater than 20, which shouldn't be allowed");
        }

        value = (PlayerPrefs.GetInt("sneakSpeed") - upgradeButtonScript.baseSneak) / upgradeButtonScript.sneakIncr;
        if (value < upgradeButtonScript.sneakTopSlider.maxValue)
        {
            upgradeButtonScript.sneakTopSlider.value = value;
            upgradeButtonScript.sneakBottomSlider.value = 0;
        }
        else if (value <= 20) //20 is max amount of upgrades, 10 + 10 from top and bottom slider
        {
            upgradeButtonScript.sneakTopSlider.value = upgradeButtonScript.sneakTopSlider.maxValue;
            upgradeButtonScript.sneakBottomSlider.value = value - 10;

        }
        else
        {
            Debug.LogError("value from playerpref is greater than 20, which shouldn't be allowed");
        }



        upgradeButtonScript.loadValues();


        // Weapons Screen:
        //----------------
        WeaponsScreenScript weaponsScreenScript = weaponsScreen.GetComponent<WeaponsScreenScript>();

        weaponsScreenScript.pistolPurchased = PlayerPrefs.GetInt("pistolPurchased") == 1;  // the "== 1" converts int to bool
        weaponsScreenScript.slingshotPurchased = PlayerPrefs.GetInt("slingshotPurchased") == 1;
        weaponsScreenScript.shotgunPurchased = PlayerPrefs.GetInt("shotgunPurchased") == 1;
        weaponsScreenScript.ARPurchased = PlayerPrefs.GetInt("ARPurchased") == 1;

        weaponsScreenScript.loadValues();


        // Pistol Screen:
        //----------------
        PistolButtonScript pistolButtonScript = pistolScreen.GetComponent<PistolButtonScript>();

        pistolButtonScript.ammoPricePistol = PlayerPrefs.GetInt("ammoPricePistol", 10);
        pistolButtonScript.dmgPricePistol = PlayerPrefs.GetInt("dmgPricePistol", 30);

        value = (PlayerPrefs.GetInt("maxPistolAmmo") - pistolButtonScript.baseAmmo) / pistolButtonScript.ammoIncr;
        if (value < pistolButtonScript.ammoTopSlider.maxValue)
        {
            pistolButtonScript.ammoTopSlider.value = value;
            pistolButtonScript.ammoBottomSlider.value = 0;
        }
        else if (value <= 20) //20 is max amount of upgrades, 10 + 10 from top and bottom slider
        {
            pistolButtonScript.ammoTopSlider.value = pistolButtonScript.ammoTopSlider.maxValue;
            pistolButtonScript.ammoBottomSlider.value = value - 10;
        }
        else
        {
            Debug.LogError("value from playerpref is greater than 20, which shouldn't be allowed");
        }

        value = (PlayerPrefs.GetInt("pistolDmg") - pistolButtonScript.baseDmg) / pistolButtonScript.dmgIncr;
        if (value < pistolButtonScript.dmgTopSlider.maxValue)
        {
            pistolButtonScript.dmgTopSlider.value = value;
            pistolButtonScript.dmgBottomSlider.value = 0;
        }
        else if (value <= 20) //20 is max amount of upgrades, 10 + 10 from top and bottom slider
        {
            pistolButtonScript.dmgTopSlider.value = pistolButtonScript.dmgTopSlider.maxValue;
            pistolButtonScript.dmgBottomSlider.value = value - 10;
        }
        else
        {
            Debug.LogError("value from playerpref is greater than 20, which shouldn't be allowed");
        }

        pistolButtonScript.silencerPurchased = PlayerPrefs.GetInt("silencerPurchased") == 1;

        pistolButtonScript.loadValues();


        // slingshot Screen:
        //----------------
        SlingshotButtonsScript slingshotButtonsScript = slingshotScreen.GetComponent<SlingshotButtonsScript>();

        value = PlayerPrefs.GetInt("ammoPriceSling", 10);
        slingshotButtonsScript.ammoPriceSling = value;

        value = (PlayerPrefs.GetInt("maxSlingshotAmmo") - slingshotButtonsScript.baseAmmo) / slingshotButtonsScript.ammoIncr;
        slingshotButtonsScript.ammoSlider.value = value;

        slingshotButtonsScript.loadvalues();


        // shotgun Screen:
        //----------------
        ShotgunButtonsScript shotgunButtonScript = shotgunScreen.GetComponent<ShotgunButtonsScript>();

        shotgunButtonScript.ammoPriceShot = PlayerPrefs.GetInt("ammoPriceShot", 20);
        shotgunButtonScript.dmgPriceShot = PlayerPrefs.GetInt("dmgPriceShot", 30);

        value = (PlayerPrefs.GetInt("maxShotgunAmmo") - shotgunButtonScript.baseAmmo) / shotgunButtonScript.ammoIncr;
        if (value < shotgunButtonScript.ammoTopSlider.maxValue)
        {
            shotgunButtonScript.ammoTopSlider.value = value;
            shotgunButtonScript.ammoBottomSlider.value = 0;
        }
        else if (value <= 20) //20 is max amount of upgrades, 10 + 10 from top and bottom slider
        {
            shotgunButtonScript.ammoTopSlider.value = shotgunButtonScript.ammoTopSlider.maxValue;
            shotgunButtonScript.ammoBottomSlider.value = value - 10;

        }
        else
        {
            Debug.LogError("value from playerpref is greater than 20, which shouldn't be allowed");
        }

        value = (PlayerPrefs.GetInt("shotgunDmg") - shotgunButtonScript.baseDmg) / shotgunButtonScript.dmgIncr;
        if (value < shotgunButtonScript.dmgTopSlider.maxValue)
        {
            shotgunButtonScript.dmgTopSlider.value = value;
            shotgunButtonScript.dmgBottomSlider.value = 0;
        }
        else if (value <= 20) //20 is max amount of upgrades, 10 + 10 from top and bottom slider
        {
            shotgunButtonScript.dmgTopSlider.value = shotgunButtonScript.dmgTopSlider.maxValue;
            shotgunButtonScript.dmgBottomSlider.value = value - 10;

        }
        else
        {
            Debug.LogError("value from playerpref is greater than 20, which shouldn't be allowed");
        }

        shotgunButtonScript.loadValues();


        // AR Screen:
        //----------------
        ARButtonsScript ARButtonScript = ARScreen.GetComponent<ARButtonsScript>();

        value = PlayerPrefs.GetInt("ammoPrice");
        ARButtonScript.ammoPrice = PlayerPrefs.GetInt("ammoPrice", 200);
        value = PlayerPrefs.GetInt("dmgPrice");
        ARButtonScript.dmgPrice = PlayerPrefs.GetInt("dmgPrice", 450);

        value = (PlayerPrefs.GetInt("maxARAmmo") - ARButtonScript.baseAmmo) / ARButtonScript.ammoIncr;
        if (value < ARButtonScript.ammoTopSlider.maxValue)
        {
            ARButtonScript.ammoTopSlider.value = value;
            ARButtonScript.ammoBottomSlider.value = 0;
        }
        else if (value <= 20) //20 is max amount of upgrades, 10 + 10 from top and bottom slider
        {
            ARButtonScript.ammoTopSlider.value = ARButtonScript.ammoTopSlider.maxValue;
            ARButtonScript.ammoBottomSlider.value = value - 10;

        }
        else
        {
            Debug.LogError("value from playerpref is greater than 20, which shouldn't be allowed");
        }

        value = (PlayerPrefs.GetInt("ARDmg") - ARButtonScript.baseDmg) / ARButtonScript.dmgIncr;
        if (value < ARButtonScript.dmgTopSlider.maxValue)
        {
            ARButtonScript.dmgTopSlider.value = value;
            ARButtonScript.dmgBottomSlider.value = 0;
        }
        else if (value <= 20) //20 is max amount of upgrades, 10 + 10 from top and bottom slider
        {
            ARButtonScript.dmgTopSlider.value = ARButtonScript.dmgTopSlider.maxValue;
            ARButtonScript.dmgBottomSlider.value = value - 10;

        }
        else
        {
            Debug.LogError("value from playerpref is greater than 20, which shouldn't be allowed");
        }

        ARButtonScript.loadValues();


        // Gold:
        //----------------
        MoneyTextScript moneyTextScript = moneyText.GetComponent<MoneyTextScript>();
        moneyTextScript.setGold(PlayerPrefs.GetInt("gold"));
    }
}
