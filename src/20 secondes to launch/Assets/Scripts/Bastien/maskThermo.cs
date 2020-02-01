using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maskThermo : MonoBehaviour
{
    [Range(0.361f,3.2f)]
    public float posY = 0; 
    // Start is called before the first frame update
    void Start()
    {
        posY = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, posY, transform.localPosition.z);
    }
}
