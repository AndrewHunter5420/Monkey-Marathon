using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseCircleScript : MonoBehaviour
{
    public GameObject circle;
    private Transform circlePos;
    private WhiteGuardScript white;
    private BlueGuardScript blue;
    private GreenGuardScript green;

    void Start()
    {
        circlePos = gameObject.GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name.Equals("White-Guard"))
        {
            white = collider.gameObject.GetComponent<WhiteGuardScript>();
            white.setIntriguePoint(circlePos.position);
		}
        if (collider.gameObject.name.Equals("Blue-Guard"))
        {
            blue = collider.gameObject.GetComponent<BlueGuardScript>();
            blue.setIntriguePoint(circlePos.position);
		}
        if (collider.gameObject.name.Equals("Green-Guard"))
        {
            green = collider.gameObject.GetComponent<GreenGuardScript>();
            green.setIntriguePoint(circlePos.position);
		}
        Destroy(circlePos.gameObject, 0.1f);
    }
}