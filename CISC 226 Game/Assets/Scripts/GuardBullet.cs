using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardBullet : MonoBehaviour
{
    public GameObject hitEffect;
    public Transform bullet;

    GameObject monkey;
    MonkeyScript monkeyScript;

    private void Start()
    {
        monkey = GameObject.FindWithTag("Player");
        monkeyScript = monkey.GetComponent<MonkeyScript>();

        Physics2D.IgnoreLayerCollision(3, 10); // Guard bullet ignores gold coins
        Physics2D.IgnoreLayerCollision(7, 10);  // Player Bullet ignores Guard Bullets
        Physics2D.IgnoreLayerCollision(9, 10);  // Gaurd Bullet ignores Guards
        Physics2D.IgnoreLayerCollision(10, 10);  // // Guard Bullet ignores Guard Bullets
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, bullet.rotation * Quaternion.Euler(0f, 0f, 180f));
        Destroy(gameObject);
        Destroy(effect, 0.05f);

        if (collision.gameObject.name.Equals("monkey"))
        {
            monkeyScript.takeDmg(20);
        }
    }
}

