using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceCollision : MonoBehaviour
{
    public BoxCollider2D boxCol;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name.Equals("monkey"))
        {
            boxCol.enabled = false;
            GameObject.Find("Distance Script").GetComponent<DistanceScript>().IncrDistance();
        }
    }
}
