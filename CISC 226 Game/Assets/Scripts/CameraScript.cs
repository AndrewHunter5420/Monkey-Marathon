using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    private GameObject monkey;
    private Transform monkeyPos;
    private Vector3 camPos;
    public Transform cam;
    public float camHeight;    

    // Start is called before the first frame update
    void Start()
    {
        monkey = GameObject.FindWithTag("Player");
        monkeyPos = monkey.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        camPos = new Vector3(monkeyPos.position.x, monkeyPos.position.y, camHeight);
        cam.position = camPos;
    }
}
