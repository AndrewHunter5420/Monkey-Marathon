using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoldScript : MonoBehaviour
{
    public TMP_Text goldText;
    public int gold;
    public int coinsPickedUp;
    public static int distanceToGoldConversion = 1;
	public AudioSource collectGold;
	private double volume;

    void Start()
    {
        coinsPickedUp = 0;

		volume = PlayerPrefs.GetInt("SFXVol")/10.0;
		collectGold.volume = (float)volume;
    }

    public void Restart()
    {
        coinsPickedUp = 0;
    }

    public void setGold(int newGold)
    {
        gold = newGold;
        goldText.text = "$" + gold;
    }

    public void PickUpCoin()
    {
		collectGold.Play();

        gold++;
        goldText.text = "$" + gold;

        coinsPickedUp++;
    }

    public void saveGold(int distanceTravelled)
    {
        gold += distanceTravelled * distanceToGoldConversion;
        goldText.text = "$" + gold;
        PlayerPrefs.SetInt("gold", gold);
    }
}
