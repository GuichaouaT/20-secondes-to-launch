using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LED : MonoBehaviour
{
#pragma warning disable CS0649
    [SerializeField] private SpriteRenderer target;
    [Header("Sprites")]
    [SerializeField] private Color colorOn = Color.white;
    [SerializeField] private Color colorOff = Color.gray;
    [Header("Sound")]
    public AudioClip sensorSound;
    private AudioSource source;
    private bool once = false;
#pragma warning restore CS0649

    public bool LightOn { set => target.color = value ? colorOn : colorOff; }

    private void Start()
    {
        if (target)
            target.color = colorOff;
        source = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if(target.color == colorOn && !once)
        {
            source.PlayOneShot(sensorSound, 1.0f);
            once = true;
        }
    }
}
