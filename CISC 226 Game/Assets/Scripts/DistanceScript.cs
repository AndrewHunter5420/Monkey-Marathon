using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DistanceScript : MonoBehaviour
{
    public TMP_Text distanceText;
    public int distanceTravelled = 0;

    private void Awake()
    {
        distanceTravelled = 0;
        distanceText.text = distanceTravelled + " m";
    }

    public void Restart()
    {
        distanceTravelled = 0;
        distanceText.text = distanceTravelled + " m";
    }

    public void IncrDistance()
    {
        distanceTravelled++;
        distanceText.text = distanceTravelled + " m";
    }
}
