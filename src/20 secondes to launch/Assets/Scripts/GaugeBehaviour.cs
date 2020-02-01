using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaugeBehaviour : MonoBehaviour
{
    [SerializeField] private Transform pointer;
    [Range(0,1)] public float pos = 0;
    private float angle = 0;



    private void Update()
    {
        if (angle != -pos * 180)
            angle = -pos * 180;
        if (pointer.transform.eulerAngles[2] != angle)        
            pointer.transform.Rotate(0, 0, angle- pointer.transform.eulerAngles[2]);
    }
}
