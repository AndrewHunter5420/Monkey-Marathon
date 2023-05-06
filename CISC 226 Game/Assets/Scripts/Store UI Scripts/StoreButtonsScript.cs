using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoreButtonsScript : MonoBehaviour
{
    public GameObject upgradesScreen, weaponsScreen, pistolScreen, slingshotScreen, shotgunScreen, ARScreen, ultimatesScreen, MoneyText;

    private void Start()
    {
        upgradesScreen.SetActive(true);
        weaponsScreen.SetActive(false);
        pistolScreen.SetActive(false);
        slingshotScreen.SetActive(false);
        shotgunScreen.SetActive(false);
        ARScreen.SetActive(false);
        ultimatesScreen.SetActive(false);
    }

    public void UpgradesScreen()
    {
        upgradesScreen.SetActive(true);
        weaponsScreen.SetActive(false);
        pistolScreen.SetActive(false);
        slingshotScreen.SetActive(false);
        shotgunScreen.SetActive(false);
        ARScreen.SetActive(false);
        ultimatesScreen.SetActive(false);
    }

    public void WeaponsScreen()
    {
        upgradesScreen.SetActive(false);
        weaponsScreen.SetActive(true);
        pistolScreen.SetActive(false);
        slingshotScreen.SetActive(false);
        shotgunScreen.SetActive(false);
        ARScreen.SetActive(false);
        ultimatesScreen.SetActive(false);
    }

    public void UltimatesScreen()
    {
        upgradesScreen.SetActive(false);
        weaponsScreen.SetActive(false);
        pistolScreen.SetActive(false);
        slingshotScreen.SetActive(false);
        shotgunScreen.SetActive(false);
        ARScreen.SetActive(false);
        ultimatesScreen.SetActive(true);
    }

    public void StartButton()
    {
        SaveData();

        SceneManager.LoadScene("SampleScene");
    }

    public void SaveData()
    {
        int value;

        // Gold:
        //----------------
        MoneyTextScript moneyTextScript = MoneyText.GetComponent<MoneyTextScript>();

        PlayerPrefs.SetInt("gold", moneyTextScript.getGold());

        // Upgrades Screen:
        //----------------
        UpgradesButtonsScript upgradesButtonsScript = upgradesScreen.GetComponent<UpgradesButtonsScript>();

        PlayerPrefs.SetInt("healthPrice", upgradesButtonsScript.healthPrice);
        PlayerPrefs.SetInt("sprintPrice", upgradesButtonsScript.sprintPrice);
        PlayerPrefs.SetInt("sneakPrice", upgradesButtonsScript.sneakPrice);

        if (upgradesButtonsScript.healthTopSlider.value < upgradesButtonsScript.healthTopSlider.maxValue)
        {
            value = upgradesButtonsScript.baseHealth + (int)upgradesButtonsScript.healthTopSlider.value * upgradesButtonsScript.healthIncr;
        }
        else
        {
            value = upgradesButtonsScript.baseHealth + (10 + (int)upgradesButtonsScript.healthBottomSlider.value) * upgradesButtonsScript.healthIncr;
        }
        PlayerPrefs.SetInt("maxHealth", value);

        if (upgradesButtonsScript.sprintTopSlider.value < upgradesButtonsScript.sprintTopSlider.maxValue)
        {
            value = upgradesButtonsScript.baseSprint + (int)upgradesButtonsScript.sprintTopSlider.value * upgradesButtonsScript.sprintIncr;
        }
        else
        {
            value = upgradesButtonsScript.baseSprint + (10 + (int)upgradesButtonsScript.sprintBottomSlider.value) * upgradesButtonsScript.sprintIncr;
        }
        PlayerPrefs.SetInt("sprintSpeed", value);

        if (upgradesButtonsScript.sneakTopSlider.value < upgradesButtonsScript.sneakTopSlider.maxValue)
        {
            value = upgradesButtonsScript.baseSneak + (int)upgradesButtonsScript.sneakTopSlider.value * upgradesButtonsScript.sneakIncr;
        }
        else
        {
            value = upgradesButtonsScript.baseSneak + (10 + (int)upgradesButtonsScript.sneakBottomSlider.value) * upgradesButtonsScript.sneakIncr;
        }
        PlayerPrefs.SetInt("sneakSpeed", value);


        // Weapons Screen:
        //----------------
        WeaponsScreenScript weaponsScreenScript = weaponsScreen.GetComponent<WeaponsScreenScript>();

        PlayerPrefs.SetInt("pistolPurchased", weaponsScreenScript.pistolPurchased ? 1 : 0);
        PlayerPrefs.SetInt("slingshotPurchased", weaponsScreenScript.slingshotPurchased ? 1 : 0);
        PlayerPrefs.SetInt("shotgunPurchased", weaponsScreenScript.shotgunPurchased ? 1 : 0);
        PlayerPrefs.SetInt("ARPurchased", weaponsScreenScript.ARPurchased ? 1 : 0);


        // Pistol Screen:
        //----------------
        PistolButtonScript pistolButtonScript = pistolScreen.GetComponent<PistolButtonScript>();

        PlayerPrefs.SetInt("ammoPricePistol", pistolButtonScript.ammoPricePistol);
        PlayerPrefs.SetInt("dmgPricePistol", pistolButtonScript.dmgPricePistol);

        if (pistolButtonScript.ammoTopSlider.value < pistolButtonScript.ammoTopSlider.maxValue)
        {
            value = pistolButtonScript.baseAmmo + (int)pistolButtonScript.ammoTopSlider.value * pistolButtonScript.ammoIncr;
        }
        else
        {
            value = pistolButtonScript.baseAmmo + (10 + (int)pistolButtonScript.ammoBottomSlider.value) * pistolButtonScript.ammoIncr;
        }
        PlayerPrefs.SetInt("maxPistolAmmo", value);

        if (pistolButtonScript.dmgTopSlider.value < pistolButtonScript.dmgTopSlider.maxValue)
        {
            value = pistolButtonScript.baseDmg + (int)pistolButtonScript.dmgTopSlider.value * pistolButtonScript.dmgIncr;
        }
        else
        {
            value = value = pistolButtonScript.baseDmg + (10 + (int)pistolButtonScript.dmgBottomSlider.value) * pistolButtonScript.dmgIncr;
        }
        PlayerPrefs.SetInt("pistolDmg", value);

        PlayerPrefs.SetInt("silencerPurchased", pistolButtonScript.silencerPurchased ? 1 : 0);


        // slingshot Screen:
        //----------------
        SlingshotButtonsScript slingshotButtonsScript = slingshotScreen.GetComponent<SlingshotButtonsScript>();

        PlayerPrefs.SetInt("ammoPriceSling", slingshotButtonsScript.ammoPriceSling);

        value = slingshotButtonsScript.baseAmmo + (int)slingshotButtonsScript.ammoSlider.value * slingshotButtonsScript.ammoIncr;
        PlayerPrefs.SetInt("maxSlingshotAmmo", value);


        // shotgun Screen:
        //----------------
        ShotgunButtonsScript shotgunButtonScript = shotgunScreen.GetComponent<ShotgunButtonsScript>();

        PlayerPrefs.SetInt("ammoPriceShot", shotgunButtonScript.ammoPriceShot);
        PlayerPrefs.SetInt("dmgPriceShot", shotgunButtonScript.dmgPriceShot);


        if (shotgunButtonScript.ammoTopSlider.value < shotgunButtonScript.ammoTopSlider.maxValue)
        {
            value = shotgunButtonScript.baseAmmo + (int)shotgunButtonScript.ammoTopSlider.value * shotgunButtonScript.ammoIncr;
        }
        else
        {
            value = shotgunButtonScript.baseAmmo + (10 + (int)shotgunButtonScript.ammoBottomSlider.value) * shotgunButtonScript.ammoIncr;
        }
        PlayerPrefs.SetInt("maxShotgunAmmo", value);

        if (shotgunButtonScript.dmgTopSlider.value < shotgunButtonScript.dmgTopSlider.maxValue)
        {
            value = shotgunButtonScript.baseDmg + (int)shotgunButtonScript.dmgTopSlider.value * shotgunButtonScript.dmgIncr;
        }
        else
        {
            value = shotgunButtonScript.baseDmg + (10 + (int)shotgunButtonScript.dmgBottomSlider.value) * shotgunButtonScript.dmgIncr;
        }
        PlayerPrefs.SetInt("shotgunDmg", value);


        // AR Screen:
        //----------------
        ARButtonsScript ARButtonScript = ARScreen.GetComponent<ARButtonsScript>();

        PlayerPrefs.SetInt("ammoPrice", ARButtonScript.ammoPrice);
        PlayerPrefs.SetInt("dmgPrice", ARButtonScript.dmgPrice);

        if (ARButtonScript.ammoTopSlider.value < ARButtonScript.ammoTopSlider.maxValue)
        {
            value = ARButtonScript.baseAmmo + (int)ARButtonScript.ammoTopSlider.value * ARButtonScript.ammoIncr;
        }
        else
        {
            value = ARButtonScript.baseAmmo + (10 + (int)ARButtonScript.ammoBottomSlider.value) * ARButtonScript.ammoIncr;
        }
        PlayerPrefs.SetInt("maxARAmmo", value);

        if (ARButtonScript.dmgTopSlider.value < ARButtonScript.dmgTopSlider.maxValue)
        {
            value = ARButtonScript.baseDmg + (int)ARButtonScript.dmgTopSlider.value * ARButtonScript.dmgIncr;
        }
        else
        {
            value = ARButtonScript.baseDmg + (10 + (int)ARButtonScript.dmgBottomSlider.value) * ARButtonScript.dmgIncr;
        }
        PlayerPrefs.SetInt("ARDmg", value);
    }
}
