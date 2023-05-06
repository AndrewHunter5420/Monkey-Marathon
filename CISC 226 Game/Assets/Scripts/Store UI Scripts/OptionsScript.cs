using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour
{
    public GameObject mainMenuScreen, upgradesScreen, weaponsScreen, pistolScreen, slingshotScreen, shotgunScreen, ARScreen, loadStore, confirmScreen;
    public Slider toggleSneakSlider, musicVolSlider, SFXVolSlider;

    public void ResetButton()
    {
        confirmScreen.SetActive(true);
    }

    public void ConfirmResetButton()
    {
        Reset();
        confirmScreen.SetActive(false);
    }

    public void NoResetButton()
    {
        confirmScreen.SetActive(false);
    }

    public void BackButton()
    {
        if (confirmScreen.activeInHierarchy == false)
        {
            // save slider settings:
            PlayerPrefs.SetInt("toggleSneak", (int)toggleSneakSlider.value);
            PlayerPrefs.SetInt("musicVol", (int)musicVolSlider.value);
            PlayerPrefs.SetInt("SFXVol", (int)SFXVolSlider.value);

            this.gameObject.SetActive(false);
            mainMenuScreen.SetActive(true);
        }
    }

    private void Reset()
    {
        PlayerPrefs.SetInt("gold", 0);

        UpgradesButtonsScript upgradesButtonsScript = upgradesScreen.GetComponent<UpgradesButtonsScript>();
        PlayerPrefs.SetInt("maxHealth", upgradesButtonsScript.baseHealth);
        PlayerPrefs.SetInt("sprintSpeed", upgradesButtonsScript.baseSprint);
        PlayerPrefs.SetInt("sneakSpeed", upgradesButtonsScript.baseSneak);

        PlayerPrefs.SetInt("pistolPurchased", 0);
        PlayerPrefs.SetInt("slingshotPurchased", 0);
        PlayerPrefs.SetInt("shotgunPurchased", 0);
        PlayerPrefs.SetInt("ARPurchased", 0);

        PlayerPrefs.SetInt("healthPrice", upgradesButtonsScript.baseHealthPrice);
        PlayerPrefs.SetInt("sprintPrice", upgradesButtonsScript.baseSprintPrice);
        PlayerPrefs.SetInt("sneakPrice", upgradesButtonsScript.baseSneakPrice);

        PistolButtonScript pistolButtonScript = pistolScreen.GetComponent<PistolButtonScript>();
        PlayerPrefs.SetInt("maxPistolAmmo", pistolButtonScript.baseAmmo);
        PlayerPrefs.SetInt("pistolDmg", pistolButtonScript.baseDmg);
        PlayerPrefs.SetInt("ARPurchased", 0);

        PlayerPrefs.SetInt("ammoPricePistol", pistolButtonScript.baseAmmoPricePistol);
        PlayerPrefs.SetInt("dmgPricePistol", pistolButtonScript.baseDmgPricePistol);

        SlingshotButtonsScript slingshotButtonsScript = slingshotScreen.GetComponent<SlingshotButtonsScript>();
        PlayerPrefs.SetInt("maxSlingshotAmmo", slingshotButtonsScript.baseAmmo);

        PlayerPrefs.SetInt("ammoPriceSling", slingshotButtonsScript.baseAmmoPriceSling);

        ShotgunButtonsScript shotgunButtonScript = shotgunScreen.GetComponent<ShotgunButtonsScript>();
        PlayerPrefs.SetInt("maxShotgunAmmo", shotgunButtonScript.baseAmmo);
        PlayerPrefs.SetInt("shotgunDmg", shotgunButtonScript.baseDmg);

        PlayerPrefs.SetInt("ammoPriceShot", shotgunButtonScript.baseAmmoPriceShot);
        PlayerPrefs.SetInt("dmgPriceShot", shotgunButtonScript.baseDmgPriceShot);

        ARButtonsScript ARButtonScript = ARScreen.GetComponent<ARButtonsScript>();
        PlayerPrefs.SetInt("maxARAmmo", ARButtonScript.baseAmmo);
        PlayerPrefs.SetInt("ARDmg", ARButtonScript.baseDmg);

        PlayerPrefs.SetInt("ammoPrice", ARButtonScript.baseAmmoPrice);
        PlayerPrefs.SetInt("dmgPrice", ARButtonScript.baseDmgPrice);

        PlayerPrefs.SetString("lastWeapon", null);

        LoadStoreScript loadStoreScript = loadStore.GetComponent<LoadStoreScript>();
        loadStoreScript.load();
    }
}
