using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [Header("Componants")]
    [SerializeField] private Transform conditionsParent;
    [SerializeField] private Animation sceneAnimation;
    [SerializeField] private TextMeshPro countdownText;

    [Header("Settings")]
    [SerializeField] private int initialCountdown = 20;

    private readonly List<Condition> conditions = new List<Condition>();

    #region Unity Callbacks

    private void Awake()
    {
        foreach(Transform t in conditionsParent)
        {
            var cond = t.GetComponent<Condition>();
            if (cond)
                conditions.Add(cond);
        }
    }

    private void Start()
    {
        StartCoroutine(Routine_Countdown());
    }

    #endregion

    #region Event Listener

    public void EVENT_Lauch()
    {
        Launch();
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

        Launch();
    }

    #endregion

    private void Launch()
    {
        foreach (var cond in conditions)
            if (!cond.IsValid())
            {
                ExecuteFail(cond.FailData);
                return;
            }
        ExecuteSuccess();
    }

    private void ExecuteFail(FailData failData)
    {
        Debug.Log("Fail");
    }

    private void ExecuteSuccess()
    {
        Debug.Log("You WIN !!!!!");
        sceneAnimation.Play("fuse launch");
    }
}
