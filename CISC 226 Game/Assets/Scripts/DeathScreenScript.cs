using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DeathScreenScript : MonoBehaviour
{
    public GameObject monkey, levelComplete, distanceTracker, goldTracker, levelGeneratorObject, FurthestTravelled, NewHighScore, sceneManager;
    public TMP_Text distanceTravelledText, FurthestTravelledText, HighScoreText, GoldEarnedCoinsText, GoldEarnedDistanceText;

    private MonkeyScript monkeyScript;
    private DistanceScript distanceScript;
    private GoldScript goldScript;
    private LevelGeneratorScript levelGeneratorScript;
    private SceneManagerScript sceneManagerScript;

    private void Start()
    {
        monkeyScript = monkey.GetComponent<MonkeyScript>();
        distanceScript = distanceTracker.GetComponent<DistanceScript>();
        goldScript = goldTracker.GetComponent<GoldScript>();
        levelGeneratorScript = levelGeneratorObject.GetComponent<LevelGeneratorScript>();
        sceneManagerScript = GameObject.Find("Scene Manager").GetComponent<SceneManagerScript>();
    }

    public void OpenDeathScreen(int distanceTravelled, int coins)
    {
        gameObject.SetActive(true);

        distanceTravelledText.text = "Distance Travelled: " + distanceTravelled + " m";

        int highScore = PlayerPrefs.GetInt("Highscore");
        if (distanceTravelled > highScore)
        {
            FurthestTravelled.SetActive(false);
            NewHighScore.SetActive(true);

            HighScoreText.text = "New Highscore: " + distanceTravelled + " m";
            PlayerPrefs.SetInt("Highscore", distanceTravelled);
        }
        else
        {
            NewHighScore.SetActive(false);
            FurthestTravelled.SetActive(true);

            FurthestTravelledText.text = "Furthest Travelled: " + highScore + " m";
        }

        GoldEarnedCoinsText.text = "Gold Earned from Coins Picked Up: $" + coins;

        GoldEarnedDistanceText.text = "Gold Earned from Distance Travelled: $" + distanceTravelled * GoldScript.distanceToGoldConversion;

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

    public void RetryButton()
    {
        gameObject.SetActive(false);
        levelComplete.SetActive(true);

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
