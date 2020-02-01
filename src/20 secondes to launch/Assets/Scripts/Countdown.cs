using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public int from;
    public int to;
    public float delay;
    [SerializeField] private UnityEventFloat onValue;

    private IEnumerator Routine()
    {
        for (int i = from; i > to; i--)
        {
            onValue.Invoke(i);
            yield return new WaitForSeconds(delay);
        }
    }
}
