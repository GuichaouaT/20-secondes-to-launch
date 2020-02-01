using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaugeBehaviour : MonoBehaviour
{
    [SerializeField] private Transform pointer;
    [Range(0,1)] public float pos = 0;
    private float angle = 0;
    public float speed;
    private bool fillIt = false;


    private void Update()
    {
        if (angle != -pos * 180)
            angle = -pos * 180;
        if (pointer.transform.eulerAngles[2] != angle)        
            pointer.transform.Rotate(0, 0, angle- pointer.transform.eulerAngles[2]);
        if (fillIt) { pos += speed; }
        pos = Mathf.Clamp(pos, 0, 1);
    }

    public void SetPos(bool t) => fillIt = t;
}
