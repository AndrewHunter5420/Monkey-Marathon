using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSightScript : MonoBehaviour
{
    public LineRenderer laserLineRenderer;
    public Transform laserHit;
    public MonkeyScript monkey;
    private LayerMask mask;
    
    // Start is called before the first frame update
    void Start()
    {
        laserLineRenderer = GetComponent<LineRenderer>();
        mask = LayerMask.GetMask("Obstacle", "Guard");
    }

    // Update is called once per frame
    void Update()
    {
        if (monkey.weapon == "shotgun")
        {
            laserLineRenderer.enabled = false;
        } else if (monkey.weapon == "slingshot")
        {
            laserLineRenderer.enabled = false;
        }
        else
        {
            laserLineRenderer.enabled = true;
 
            RaycastHit2D hit = Physics2D.Raycast(laserLineRenderer.transform.position, laserLineRenderer.transform.up, 300f,mask);
            
            laserHit.position = hit.point;
            laserLineRenderer.SetPosition(0, laserLineRenderer.transform.position);
            laserLineRenderer.SetPosition(1, laserHit.position);

        }
    }
}
