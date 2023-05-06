using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlingshotButtonsScript : MonoBehaviour
{
    public MoneyTextScript moneyScript;

    public GameObject weaponsScreen;

    public Slider ammoSlider;  //Will need to save slider values in save file

    public GameObject ammoPriceText;

    public GameObject ammoMaxedText;

    public int baseAmmo = 2;
    public int ammoIncr = 1;

    public TMP_Text ammoText;
    public int ammoPriceSling = 10;
    public int baseAmmoPriceSling = 10;

    private void IncrAmmoPrice()
    {
        ammoPriceSling += 10;
        ammoText.text = "$" + ammoPriceSling;
    }

    private void Start()
    {
        ammoText.text = "$" + ammoPriceSling;
    }

    public void loadvalues()
    {
        if (ammoSlider.value == ammoSlider.maxValue)
        {
            ammoPriceText.SetActive(false);
            ammoMaxedText.SetActive(true);
        }
        else
        {
            ammoPriceText.SetActive(true);
            ammoMaxedText.SetActive(false);
        }
    }

    public void AmmoButton()
    {
        if (ammoPriceSling <= moneyScript.getGold() && ++ammoSlider.value <= ammoSlider.maxValue)
        {
            moneyScript.SubtractGold(ammoPriceSling);

            // Increase price
            IncrAmmoPrice();

            // Apply upgrade
            if (ammoSlider.value == ammoSlider.maxValue)
            {
                ammoPriceText.SetActive(false);
                ammoMaxedText.SetActive(true);
            }
        }
    }

    public void BackButton()
    {
        weaponsScreen.SetActive(true);
        gameObject.SetActive(false);
    }
}
