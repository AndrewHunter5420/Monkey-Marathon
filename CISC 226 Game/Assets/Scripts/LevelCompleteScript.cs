using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelCompleteScript : MonoBehaviour
{
    public GameObject monkey, distanceTracker, goldTracker, levelGeneratorObject, sceneManager;
    public TMP_Text distanceTravelledText, GoldEarnedCoinsText, GoldEarnedDistanceText;

    private MonkeyScript monkeyScript;
    private DistanceScript distanceScript;
    private GoldScript goldScript;
    private LevelGeneratorScript levelGeneratorScript;
    private SceneManagerScript sceneManagerScript;

    private void Start()
    {
        sceneManagerScript = GameObject.Find("Scene Manager").GetComponent<SceneManagerScript>();

        monkeyScript = monkey.GetComponent<MonkeyScript>();
        distanceScript = distanceTracker.GetComponent<DistanceScript>();
        goldScript = goldTracker.GetComponent<GoldScript>();
        levelGeneratorScript = levelGeneratorObject.GetComponent<LevelGeneratorScript>();
    }

    public void OpenLevelCompleteScreen()
    {
        int distanceTravelled = distanceScript.distanceTravelled;
        int coins = goldScript.coinsPickedUp;


        gameObject.SetActive(true);

        distanceTravelledText.text = "Distance Travelled: " + distanceTravelled + " m";

        PlayerPrefs.SetInt("Highscore", 0);

        GoldEarnedCoinsText.text = "Gold Earned from Coins Picked Up: $" + coins;

        GoldEarnedDistanceText.text = "Gold Earned from Distance Travelled: $" + distanceTravelled * GoldScript.distanceToGoldConversion;

        PlayerPrefs.SetFloat("Floor", PlayerPrefs.GetFloat("Floor") + 1);

        goldScript.saveGold(distanceTravelled);
    }

    public void MainMenuButton()
    {
        sceneManagerScript.load = "main";
        SceneManager.LoadScene("menu");
    }

    public void StoreButton()
    {
        sceneManagerScript.load = "store";
        SceneManager.LoadScene("menu");
    }

    public void ContinueButton()
    {
        gameObject.SetActive(false);

        var clones = GameObject.FindGameObjectsWithTag("clone");
        foreach (var i in clones)
        {
            Destroy(i);
        }

        levelGeneratorScript.generateLevel();

        monkeyScript.Restart();
        distanceScript.Restart();
        goldScript.Restart();
    }
}
