using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCollision : MonoBehaviour
{
    GameObject monkey;
    MonkeyScript monkeyScript;
    private GoldScript goldScript;

    void Start()
    {
        Physics2D.IgnoreLayerCollision(3, 7);  // Ignore collision between coin and player bullet
        Physics2D.IgnoreLayerCollision(3, 9);  // Ignore collision between coin and guard
        Physics2D.IgnoreLayerCollision(3, 10); // Ignore collision between coin and guard bullet


        monkey = GameObject.FindWithTag("Player");
        monkeyScript = monkey.GetComponent<MonkeyScript>();

        goldScript = GameObject.Find("Gold Script").GetComponent<GoldScript>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.Equals("monkey"))
        {
            goldScript.PickUpCoin();
            
            Destroy(gameObject);
        }
    }
}
