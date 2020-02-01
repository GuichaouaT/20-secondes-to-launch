using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WingRepair : MonoBehaviour
{

    [SerializeField] private GameObject wingAloneObject;
    [SerializeField] private new Animation animation;
    [Header("Animation Name")]
    [SerializeField] private string canRepairAnimationName;
    [SerializeField] private string noWingAnimationName;
    [Header("Event")]
    [SerializeField] private UnityEvent onWingRepaired;

    #region EVENT LISTENER

    public void EVENT_WingRepaired()
    {
        onWingRepaired.Invoke();
    }

    #endregion

    public void TryRepair()
    {
        if (wingAloneObject.activeSelf)
        {
            animation.Play(canRepairAnimationName);
        }
        else
        {
            animation.Play(noWingAnimationName);
        }
    }
}
