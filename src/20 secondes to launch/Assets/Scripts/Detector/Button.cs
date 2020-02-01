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

    private void Start()
    {
        if (target)
            target.color = normalColor;
    }

    private void OnMouseDown()
    {
        if (target)
            target.color = pressedColor;
        onClicked.Invoke();
    }

    private void OnMouseUp()
    {
        if (target)
            target.color = normalColor;
    }
}
