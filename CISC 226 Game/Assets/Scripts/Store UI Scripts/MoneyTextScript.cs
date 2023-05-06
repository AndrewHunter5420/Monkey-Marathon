using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyTextScript : MonoBehaviour
{
    public int gold;
    public TMP_Text goldText;

    public void setGold(int amount)
    {
        gold = amount;
        goldText.text = "$" + gold.ToString();
    }

    public void SubtractGold(int amount)
    {
        gold -= amount;

        goldText.text = "$" + gold.ToString();
    }

    public int getGold()
    {
        return gold;
    }
}
