using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DelayedAction : MonoBehaviour
{
#pragma warning disable CS0649
    public float delay;
    [SerializeField] private UnityEvent action;
#pragma warning restore CS0649

    public void Do()
    {
        StartCoroutine(Routine());
    }

    private IEnumerator Routine()
    {
        yield return new WaitForSeconds(delay);
        action.Invoke();
    }
}
