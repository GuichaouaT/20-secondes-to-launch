using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class light : MonoBehaviour
{
    [SerializeField] private SpriteRenderer target;
    [Header("Sprites")]
    [SerializeField] private Color colorOn = Color.white;
    [SerializeField] private Color colorOff = Color.gray;
    [Header("Sound")]
    public AudioClip sensorSound;
    private AudioSource source;
    private bool once = false;
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
