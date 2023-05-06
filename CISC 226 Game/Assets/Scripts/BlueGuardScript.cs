using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BlueGuardScript : MonoBehaviour
{
    public int maxHealth;
    public int health;
    private HealthBarScript healthBarScript;
    public GameObject healthBar;

    private WeaponScript weaponscript;
    public GameObject bullet;
    public float pistolCooldown = 0.5f;
    private float currTime;

    private Transform monkeyPos;
    private Transform guardPos;
    public Transform patrolPos1;
    public Transform patrolPos2;
    public float fireDistance = 70f;

    public AIPath pathfinding;
	public AIBase myAI;
    public Patrol patrol;
    public string state = "PATROL";
	public int investigateTime = 2000;
	public GameObject intriguePoint;
	public Transform intriguePos;
	private float hearingRadius = 20f;
	public int speed = 4;
	public int chaseSpeedIncrease = 1;

    private GameObject monkey;
    private MonkeyScript monkeyScript;
    private Animator anim;
	public AudioSource getHit;
	public AudioSource die;
	private double volume;

    void Start()
    {
        healthBarScript = healthBar.GetComponentInChildren<HealthBarScript>();
        setMaxHealth();

        weaponscript = gameObject.GetComponent<WeaponScript>();
        currTime = 0f;

        monkeyPos = GameObject.Find("monkey").GetComponent<Transform>();
        guardPos = gameObject.GetComponent<Transform>();

        monkey = GameObject.Find("monkey");
        monkeyScript = monkey.GetComponent<MonkeyScript>();

        anim = GetComponent<Animator>();
        
		myAI.maxSpeed = speed;
	
		volume = PlayerPrefs.GetInt("SFXVol")/10.0;
		getHit.volume = (float)volume;
		die.volume = (float)volume;
    }

    void Update()
    {
        // very temporary, just for testing
        if (Input.GetKeyDown(KeyCode.Home))
        {
            if(state.Equals("PATROL"))
			{
				state = "CHASE";
			}
			else if(state.Equals("CHASE"))
			{
				state = "PATROL";
			}
        }

        if ((Vector2.Distance(monkeyPos.position, guardPos.position) <= fireDistance) && state.Equals("CHASE"))
        {
            // Stop path finding
            anim.SetInteger("Running State", 0);
            pathfinding.canMove = false;

            // aim at monkey
            Vector2 lookDir = new Vector2(monkeyPos.position.x - guardPos.position.x, monkeyPos.position.y - guardPos.position.y);
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;
            guardPos.rotation = Quaternion.Euler(0, 0, angle);

            // shoot
            if (currTime <= Time.time)
            {
                weaponscript.pistolShoot();
                currTime = Time.time + pistolCooldown;
            }
        }
        else
        {
	        anim.SetInteger("Running State", 1);
            // May be inefficient, keep an eye on this
            pathfinding.canMove = true;
        }

        // Chase Monkey State
        if (state.Equals("CHASE"))
        {
            patrol.targets[0] = monkeyPos;
            patrol.targets[1] = monkeyPos;
			myAI.maxSpeed += chaseSpeedIncrease;
        }
        // Patrol State
        else if (state.Equals("PATROL"))
        {
            patrol.targets[0] = patrolPos1;
            patrol.targets[1] = patrolPos2;
			myAI.maxSpeed = speed;
			
			// Guard hears monkey
			if(Vector2.Distance(monkeyPos.position, guardPos.position) <= hearingRadius && monkeyScript.loud && !monkeyScript.isDead)
			{
                setIntriguePoint(monkeyPos.position);
			}
        }
        // Investigation State
        else if (state.Equals("INVESTIGATE"))
        {
            // Guard hears monkey
            if (Vector2.Distance(monkeyPos.position, guardPos.position) <= hearingRadius && monkeyScript.loud && !monkeyScript.isDead)
            {
                Destroy(intriguePos.gameObject);
                setIntriguePoint(monkeyPos.position);
            }

            patrol.targets[0] = intriguePos;
            patrol.targets[1] = intriguePos;
			myAI.maxSpeed = speed;

            // wait 100 frames then return to patrol
            if (investigateTime > 0)
            {
                investigateTime -= 1;
                anim.SetInteger("Running State", 0);
            }
            else
            {
                state = "PATROL";
                investigateTime = 2000;
                Destroy(intriguePos.gameObject);
            }
        }
    }

    public void setIntriguePoint(Vector2 position)
    {
        GameObject lastSeen = (GameObject)Instantiate(intriguePoint, position, Quaternion.identity);
        intriguePos = lastSeen.transform;
        state = "INVESTIGATE";
    }

    public void setMaxHealth()
    {
        health = maxHealth;
        healthBarScript.SetMaxHealth(health);
    }

    public void takeDmg(int dmg)
    {
		getHit.Play();
        health -= dmg;
        healthBarScript.SetHealth(health);
        if (health <= 0)
        {
			AudioSource.PlayClipAtPoint(die.clip, monkeyPos.position, 100.0F);
            Destroy(healthBar);
            Destroy(gameObject);
        }
    }

	private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name.Equals("monkey"))
        {
            state = "CHASE";
        }
    }

	private void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.gameObject.name.Equals("monkey"))
		{
			GameObject lastSeen = (GameObject)Instantiate(intriguePoint, monkeyPos.position, Quaternion.identity);
			intriguePos = lastSeen.transform;
			state = "INVESTIGATE";
		}
	}
}
