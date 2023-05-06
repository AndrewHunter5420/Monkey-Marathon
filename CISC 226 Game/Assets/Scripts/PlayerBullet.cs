using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private GameObject monkey;
    private GameObject enemy;
    public GameObject hitEffect;
    public Transform bullet;

    public MonkeyScript monkeyScript;
    public BlueGuardScript blueGuardScript;
	public GreenGuardScript greenGuardScript;
	public WhiteGuardScript whiteGuardScript;
    private string weapon;

    private Vector2 startVec;
    public float despawnDistance = 15f;
	public int damage = 20;

    private void Start()
    {
        Physics2D.IgnoreLayerCollision(3, 7); // Player bullet ignores gold coin
        Physics2D.IgnoreLayerCollision(7, 10);  // Player Bullet ignores Guard Bullets
        Physics2D.IgnoreLayerCollision(6, 7);  // Player Bullet ignores Player
        Physics2D.IgnoreLayerCollision(7, 7);  // // Player Bullet ignores Player Bullets
		Physics2D.IgnoreLayerCollision(7, 5); // Player Bullet ignores ui

        startVec = bullet.position;

        monkey = GameObject.FindWithTag("Player");
        monkeyScript = monkey.GetComponent<MonkeyScript>();
        weapon = monkeyScript.weapon;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            GameObject effect = Instantiate(hitEffect, transform.position, bullet.rotation * Quaternion.Euler(0f, 0f, 180f));
            Destroy(gameObject);
            Destroy(effect, 0.05f);

            GameObject targetHit = collision.gameObject;
            
            if (targetHit.name.Equals("Blue-Guard"))
            {
                enemy = targetHit;
                blueGuardScript = enemy.GetComponent<BlueGuardScript>();
                blueGuardScript.takeDmg(calcDmg());
            }
			else if (targetHit.name.Equals("Green-Guard"))
            {
                enemy = targetHit;
                greenGuardScript = enemy.GetComponent<GreenGuardScript>();
                greenGuardScript.takeDmg(calcDmg());
            }
			else if (targetHit.name.Equals("White-Guard"))
			{
				enemy = targetHit;
				whiteGuardScript = enemy.GetComponent<WhiteGuardScript>();
				whiteGuardScript.takeDmg(calcDmg());
			}
    }

    private int calcDmg()
    {
        switch (weapon){
            case "pistol":
                return monkeyScript.pistolDmg;
            case "shotgun":
                return monkeyScript.shotgunDmg;
            case "AR":
                return monkeyScript.ARDmg;
        }
        return -1000;  // error occurred 
    }

    private void FixedUpdate()
    {
        if (weapon == "shotgun")
        {
            if (Vector2.Distance(startVec, bullet.position) >= despawnDistance)
            {
                Destroy(gameObject);
            }
        }
    }
}
