using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickDetector : MonoBehaviour
{
    [SerializeField] private EventTrigger trigger;

    private void OnMouseDown()
    {
        trigger.Raise();
    }
}
