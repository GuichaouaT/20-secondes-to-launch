using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [Header("Componants")]
    [SerializeField] private TextMeshPro countdownText;

    [Header("Settings")]
    [SerializeField] private int initialCountdown = 20;

    #region Unity Callbacks

    private void Start()
    {
        StartCoroutine(Routine_Countdown());
    }

    #endregion

    #region Event Listener

    public void EVENT_Lauch()
    {
        Lauch();
    }

    #endregion


    #region Routine

    private IEnumerator Routine_Countdown()
    {
        for (int i = initialCountdown; i >= 0; i--)
        {
            countdownText.SetText(i.ToString());
            yield return new WaitForSeconds(1);
        }

        Lauch();
    }

    #endregion

    private void Lauch()
    {
        Debug.Log("LAUNCH !!!!!!!!");
    }

}
