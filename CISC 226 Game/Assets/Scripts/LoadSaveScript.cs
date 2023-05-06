using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSaveScript : MonoBehaviour
{
    public GameObject monkey;
    public GameObject goldScriptObject;
    private GoldScript goldScript;

    void Awake()
    {
        goldScript = goldScriptObject.GetComponent<GoldScript>();
        goldScript.setGold(PlayerPrefs.GetInt("gold"));

        MonkeyScript monkeyScript = monkey.GetComponent<MonkeyScript>();

        monkeyScript.setMaxHealth(PlayerPrefs.GetInt("maxHealth"));
        monkeyScript.sprintSpeed = PlayerPrefs.GetInt("sprintSpeed");
        monkeyScript.sneakSpeed = PlayerPrefs.GetInt("sneakSpeed");

        monkeyScript.pistolPurchased = PlayerPrefs.GetInt("pistolPurchased") == 1;
        monkeyScript.slingshotPurchased = PlayerPrefs.GetInt("slingshotPurchased") == 1;
        monkeyScript.shotgunPurchased = PlayerPrefs.GetInt("shotgunPurchased") == 1;
        monkeyScript.ARPurchased = PlayerPrefs.GetInt("ARPurchased") == 1;

        monkeyScript.silencerPurchased = PlayerPrefs.GetInt("silencerPurchased") == 1;

        monkeyScript.maxPistolAmmo = PlayerPrefs.GetInt("maxPistolAmmo");
        monkeyScript.maxSlingshotAmmo = PlayerPrefs.GetInt("maxSlingshotAmmo");
        monkeyScript.maxShotgunAmmo = PlayerPrefs.GetInt("maxShotgunAmmo");
        monkeyScript.maxARAmmo = PlayerPrefs.GetInt("maxARAmmo");

        monkeyScript.pistolDmg = PlayerPrefs.GetInt("pistolDmg");
        monkeyScript.shotgunDmg = PlayerPrefs.GetInt("shotgunDmg");
        monkeyScript.ARDmg = PlayerPrefs.GetInt("ARDmg");

        // Still need to apply silencer affect

        monkeyScript.weapon = PlayerPrefs.GetString("lastWeapon");
    }
}
