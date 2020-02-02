using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class clickedAtLeastOnce : MonoBehaviour
{
    [SerializeField] private bool eventAvailable = false;
    [SerializeField] private UnityEvent onClickedSecond;
    // Start is called before the first frame update
    public void eventOk() => eventAvailable = true;
    public void clickSecond()
    {
        Debug.Log("in clickSecond");
        if(eventAvailable)
        {
            onClickedSecond.Invoke();
        }
    }
}
