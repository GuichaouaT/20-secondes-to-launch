using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSensor : MonoBehaviour
{
    private AudioSource source;
    public AudioClip sensorSound;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.PlayOneShot(sensorSound, 1.0f);
    }
}
