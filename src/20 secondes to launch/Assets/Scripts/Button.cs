using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
#pragma warning disable CS0649
    [SerializeField] private SpriteRenderer target;
    [SerializeField] private bool isInteractable = true;
    [Header("Sprites")]
    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color pressedColor = Color.gray;

    [SerializeField] private UnityEvent onClicked;
    [SerializeField] private UnityEvent onUnclicked;
    private AudioSource audioSource;
    [Header("Sound")]
    [SerializeField] private AudioClip buttonSound;
#pragma warning disable CS0649

    public bool IsInteractable { get => isInteractable; set => isInteractable = value; }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (target)
            target.color = normalColor;
    }

    private void OnMouseDown()
    {
        if (!isInteractable)
            return;
        if (target)
            target.color = pressedColor;
        onClicked.Invoke();
        audioSource?.PlayOneShot(buttonSound, 3.0f);
    }

    private void OnMouseUp()
    {
        if (!isInteractable)
            return;
        if (target)
            target.color = normalColor;
        onUnclicked.Invoke();
    }

}
