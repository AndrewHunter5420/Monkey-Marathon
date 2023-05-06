using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAI : MonoBehaviour
{
    private WeaponScript weaponscript;
    public GameObject bullet;
    public float pistolCooldown = 5f;
    private float currTime;
    

    // Start is called before the first frame update
    void Start()
    {
        weaponscript = gameObject.GetComponent<WeaponScript>();
        currTime = 0f;
    }

    void Update()
    {
        if (currTime <= Time.time)
        {
            weaponscript.pistolShoot();
            currTime = Time.time + pistolCooldown;
        }
    }
}
