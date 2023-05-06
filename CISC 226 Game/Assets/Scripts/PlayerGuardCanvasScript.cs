using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGuardCanvasScript : MonoBehaviour
{
    public Transform targetPos;
    public Transform canvas;

    public float offset = 3.5f;

    void Update()
    {
        if(targetPos != null)
            canvas.position = new Vector2(targetPos.position.x, targetPos.position.y + offset);
    }
}
