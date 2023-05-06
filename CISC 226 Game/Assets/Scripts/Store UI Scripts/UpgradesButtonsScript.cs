using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradesButtonsScript : MonoBehaviour
{
    public MoneyTextScript moneyScript;

    public Slider healthTopSlider, healthBottomSlider, sprintTopSlider, sprintBottomSlider, sneakTopSlider, sneakBottomSlider;

    public GameObject healthPriceText, sprintPriceText, sneakPriceText;

    public GameObject mainMenuScreen, healthMaxedText, sprintMaxedText, sneakMaxedText;

    public int baseHealth;
    public int healthIncr;

    public int baseSprint;
    public int sprintIncr;

    public int baseSneak;
    public int sneakIncr;

    public TMP_Text healthText;
    public int healthPrice = 10;
    public int baseHealthPrice = 10;

    public TMP_Text sprintText;
    public int sprintPrice = 10;
    public int baseSprintPrice = 10;

    public TMP_Text sneakText;
    public int sneakPrice = 10;
    public int baseSneakPrice = 10;

    private void IncrHealthPrice()
    {
        healthPrice += 10;
        healthText.text = "$" + healthPrice;
    }

    private void IncrSprintPrice()
    {
        sprintPrice += 10;
        sprintText.text = "$" + sprintPrice;
    }

    private void IncrSneakPrice()
    {
        sneakPrice += 10;
        sneakText.text = "$" + sneakPrice;
    }

    private void Start()
    {
        healthText.text = "$" + healthPrice;
        sprintText.text = "$" + sprintPrice;
        sneakText.text = "$" + sneakPrice;
    }

    public void loadValues()
    {
        if (healthBottomSlider.value == healthBottomSlider.maxValue)
        {
            healthPriceText.SetActive(false);
            healthMaxedText.SetActive(true);
        }
        else
        {
            healthPriceText.SetActive(true);
            healthMaxedText.SetActive(false);
        }

        if (sprintBottomSlider.value == sprintBottomSlider.maxValue)
        {
            sprintPriceText.SetActive(false);
            sprintMaxedText.SetActive(true);
        }
        else
        {
            sprintPriceText.SetActive(true);
            sprintMaxedText.SetActive(false);
        }

        if (sneakBottomSlider.value == sneakBottomSlider.maxValue)
        {
            sneakPriceText.SetActive(false);
            sneakMaxedText.SetActive(true);
        }
        else
        {
            sneakPriceText.SetActive(true);
            sneakMaxedText.SetActive(false);
        }
    }

    public void HealthButton()
    {
        if (healthPrice <= moneyScript.getGold() && healthBottomSlider.value < healthBottomSlider.maxValue)
        {
            moneyScript.SubtractGold(healthPrice);

            // Increase price
            IncrHealthPrice();

            // Apply upgrade
            if (healthTopSlider.value < healthTopSlider.maxValue)
            {
                healthTopSlider.value++;
            }
            else if (++healthBottomSlider.value == healthBottomSlider.maxValue)
            {
                healthPriceText.SetActive(false);
                healthMaxedText.SetActive(true);
            }
        }
    }

    public void SprintButton()
    {
        if (sprintPrice <= moneyScript.getGold() && sprintBottomSlider.value < sprintBottomSlider.maxValue)
        {
            moneyScript.SubtractGold(sprintPrice);

            // Increase price
            IncrSprintPrice();

            // Apply upgrade
            if (sprintTopSlider.value < sprintTopSlider.maxValue)
            {
                sprintTopSlider.value++;
            }
            else if (++sprintBottomSlider.value == sprintBottomSlider.maxValue)
            {
                sprintPriceText.SetActive(false);
                sprintMaxedText.SetActive(true);
            }
        }
    }

    public void SneakButton()
    {
        if (sneakPrice <= moneyScript.getGold() && sneakBottomSlider.value < sneakBottomSlider.maxValue)
        {
            moneyScript.SubtractGold(sneakPrice);

            // Increase price
            IncrSneakPrice();

            // Apply upgrade
            if (sneakTopSlider.value < sneakTopSlider.maxValue)
            {
                sneakTopSlider.value++;
            }
            else if (++sneakBottomSlider.value == sneakBottomSlider.maxValue)
            {
                sneakPriceText.SetActive(false);
                sneakMaxedText.SetActive(true);
            }
        }
    }

    public void BackButton()
    {
        this.gameObject.SetActive(false);
        mainMenuScreen.SetActive(true);
    }
}