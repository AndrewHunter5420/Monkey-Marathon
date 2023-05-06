using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfLevelScript : MonoBehaviour
{
    private LevelCompleteScript levelCompleteScript;

    private void Start()
    {
        GameObject levelComplete = GameObject.Find("Level Completed Screen");

        levelCompleteScript = levelComplete.GetComponent<LevelCompleteScript>();

        levelComplete.SetActive(false);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("monkey"))
        {
            levelCompleteScript.OpenLevelCompleteScreen();
        }
    }
}
