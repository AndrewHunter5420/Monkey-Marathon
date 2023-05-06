using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ARButtonsScript : MonoBehaviour
{
    public MoneyTextScript moneyScript;

    public GameObject weaponsScreen;

    public Slider ammoTopSlider, ammoBottomSlider, dmgTopSlider, dmgBottomSlider;  //Will need to save slider values in save file

    public GameObject ammoPriceText, dmgPriceText;

    public GameObject ammoMaxedText, dmgMaxedText;

    public int baseAmmo = 10;
    public int ammoIncr = 1;

    public int baseDmg = 40;
    public int dmgIncr = 10;

    public TMP_Text ammoText;
    public int ammoPrice = 100;
    public int baseAmmoPrice = 100;

    public TMP_Text dmgText;
    public int dmgPrice = 100;
    public int baseDmgPrice = 100;
    
    private void IncrAmmoPrice()
    {
        ammoPrice += 100;
        ammoText.text = "$" + ammoPrice;
    }

    private void IncrDmgPrice()
    {
        dmgPrice += 100;
        dmgText.text = "$" + dmgPrice;
    }

    private void Start()
    {
        ammoText.text = "$" + ammoPrice;
        dmgText.text = "$" + dmgPrice;
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
        if (ammoPrice <= moneyScript.getGold() && ammoBottomSlider.value < ammoBottomSlider.maxValue)
        {
            moneyScript.SubtractGold(ammoPrice);

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
        if (dmgPrice <= moneyScript.getGold() && dmgBottomSlider.value < dmgBottomSlider.maxValue)
        {
            moneyScript.SubtractGold(dmgPrice);

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
