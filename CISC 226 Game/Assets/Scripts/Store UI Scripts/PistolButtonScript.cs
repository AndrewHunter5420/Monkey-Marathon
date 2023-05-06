using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PistolButtonScript : MonoBehaviour
{
    public MoneyTextScript moneyScript;

    public GameObject weaponsScreen;

    public Slider ammoTopSlider, ammoBottomSlider, dmgTopSlider, dmgBottomSlider;  //Will need to save slider values in save file

    public bool silencerPurchased = false;
    public GameObject silencerYellowFill;

    public GameObject ammoPriceText, dmgPriceText, silencerPriceText;

    public GameObject ammoMaxedText, dmgMaxedText, silencerMaxedText;

    public int baseAmmo = 15;
    public int ammoIncr = 2;

    public int baseDmg = 25;
    public int dmgIncr = 10;

    public int silencerPrice = 500;

    public TMP_Text ammoText;
    public int ammoPricePistol = 10;
    public int baseAmmoPricePistol = 10;

    public TMP_Text dmgText;
    public int dmgPricePistol = 30;
    public int baseDmgPricePistol = 30;

    private void IncrAmmoPrice()
    {
        ammoPricePistol += 10;
        ammoText.text = "$" + ammoPricePistol;
    }

    private void IncrDmgPrice()
    {
        dmgPricePistol += 30;
        dmgText.text = "$" + dmgPricePistol;
    }

    private void Start()
    {
        ammoText.text = "$" + ammoPricePistol;
        dmgText.text = "$" + dmgPricePistol;
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

        if (silencerPurchased)
        {
            silencerYellowFill.SetActive(true);
            silencerPriceText.SetActive(false);
            silencerMaxedText.SetActive(true);
        }
        else
        {
            silencerYellowFill.SetActive(false);
            silencerPriceText.SetActive(true);
            silencerMaxedText.SetActive(false);
        }
    }

    public void AmmoButton()
    {
        if (ammoPricePistol <= moneyScript.getGold() && ammoBottomSlider.value < ammoBottomSlider.maxValue)
        {
            moneyScript.SubtractGold(ammoPricePistol);

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
        if (dmgPricePistol <= moneyScript.getGold() && dmgBottomSlider.value < dmgBottomSlider.maxValue)
        {
            moneyScript.SubtractGold(dmgPricePistol);

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

    public void silencerButton()
    {
        if (!silencerPurchased && silencerPrice <= moneyScript.getGold())
        {
            moneyScript.SubtractGold(silencerPrice);

            silencerYellowFill.SetActive(true);

            silencerPriceText.SetActive(false);
            silencerMaxedText.SetActive(true);
        }
    }

    public void BackButton()
    {
        weaponsScreen.SetActive(true);
        gameObject.SetActive(false);
    }
}
