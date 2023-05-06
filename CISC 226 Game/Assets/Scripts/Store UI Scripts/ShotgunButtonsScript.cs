using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShotgunButtonsScript : MonoBehaviour
{
    public MoneyTextScript moneyScript;

    public GameObject weaponsScreen;

    public Slider ammoTopSlider, ammoBottomSlider, dmgTopSlider, dmgBottomSlider;  //Will need to save slider values in save file

    public GameObject ammoPriceText, dmgPriceText;

    public GameObject ammoMaxedText, dmgMaxedText;

    public int baseAmmo = 5;
    public int ammoIncr = 1;

    public int baseDmg = 15;
    public int dmgIncr = 5;

    public TMP_Text ammoText;
    public int ammoPriceShot = 30;
    public int baseAmmoPriceShot = 30;

    public TMP_Text dmgText;
    public int dmgPriceShot = 50;
    public int baseDmgPriceShot = 50;

    private void IncrAmmoPrice()
    {
        ammoPriceShot += 30;
        ammoText.text = "$" + ammoPriceShot;
    }

    private void IncrDmgPrice()
    {
        dmgPriceShot += 50;
        dmgText.text = "$" + dmgPriceShot;
    }

    private void Start()
    {
        ammoText.text = "$" + ammoPriceShot;
        dmgText.text = "$" + dmgPriceShot;
    }

    public void loadValues()
    {
        if (ammoBottomSlider.value == ammoBottomSlider.maxValue)
        {
            ammoPriceText.SetActive(false);
            ammoMaxedText.SetActive(true);
        }
        else
        {
            ammoPriceText.SetActive(true);
            ammoMaxedText.SetActive(false);
        }

        if (dmgBottomSlider.value == dmgBottomSlider.maxValue)
        {
            dmgPriceText.SetActive(false);
            dmgMaxedText.SetActive(true);
        }
        else
        {
            dmgPriceText.SetActive(true);
            dmgMaxedText.SetActive(false);
        }
    }

    public void AmmoButton()
    {
        if (ammoPriceShot <= moneyScript.getGold() && ammoBottomSlider.value < ammoBottomSlider.maxValue)
        {
            moneyScript.SubtractGold(ammoPriceShot);

            // Increase price
            IncrAmmoPrice();

            // Apply upgrade
            if (ammoTopSlider.value < ammoTopSlider.maxValue)
            {
                ammoTopSlider.value++;
            }
            else if (++ammoBottomSlider.value == ammoBottomSlider.maxValue)
            {
                ammoPriceText.SetActive(false);
                ammoMaxedText.SetActive(true);
            }
        }
    }

    public void DmgButton()
    {
        if (dmgPriceShot <= moneyScript.getGold() && dmgBottomSlider.value < dmgBottomSlider.maxValue)
        {
            moneyScript.SubtractGold(dmgPriceShot);

            // Increase price
            IncrDmgPrice();

            // Apply upgrade
            if (dmgTopSlider.value < dmgTopSlider.maxValue)
            {
                dmgTopSlider.value++;
            }
            else if (++dmgBottomSlider.value == dmgBottomSlider.maxValue)
            {
                dmgPriceText.SetActive(false);
                dmgMaxedText.SetActive(true);
            }
        }
    }

    public void BackButton()
    {
        weaponsScreen.SetActive(true);
        gameObject.SetActive(false);
    }
}
