using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
#pragma warning disable CS0649

    [SerializeField] private bool state;
    [SerializeField] private float delay;
    [SerializeField] private UnityEventBool onValue;

#pragma warning restore CS0649

    private void OnEnable()
    {
        StartCoroutine(Routine());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator Routine()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            state ^= true;
            onValue.Invoke(state);
        }
    }

}
