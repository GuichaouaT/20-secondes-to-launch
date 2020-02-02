using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    [SerializeField] private SpriteRenderer target;
    [Header("Sprites")]
    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color pressedColor = Color.gray;

    [SerializeField] private UnityEvent onClicked;
    [SerializeField] private UnityEvent onUnclicked;
    private AudioSource source;
    [Header("Sound")]
    [SerializeField] private AudioClip buttonSound;

    private void Start()
    {
        if (target)
            target.color = normalColor;
        source = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        if (!enabled)
            return;
        if (target)
            target.color = pressedColor;
        onClicked.Invoke();
        source.PlayOneShot(buttonSound, 3.0f);
    }

    private void OnMouseUp()
    {
        if (!enabled)
            return;
        if (target)
            target.color = normalColor;
        onUnclicked.Invoke();
    }

}
