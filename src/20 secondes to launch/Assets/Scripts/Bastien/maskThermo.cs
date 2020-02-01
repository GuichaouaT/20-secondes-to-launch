using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maskThermo : MonoBehaviour
{
    private Transform trMask;
    public float posDeltaY = 0;
    // Start is called before the first frame update
    void Start()
    {
        trMask = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, posDeltaY, transform.localPosition.z);
    }
}
