using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Header("Componants")]
    [SerializeField] private Transform conditionsParent;
    [SerializeField] private Animation sceneAnimation;
    [SerializeField] private TextMeshPro countdownText;
    [SerializeField] private GameObject blackScreen;
    [SerializeField] private GameObject startLight;

    [Header("Settings")]
    [SerializeField] private int initialCountdown = 20;
    [SerializeField] private string successAnimationName;

    private static bool isRestart = false;

    private readonly List<Condition> conditions = new List<Condition>();
    private bool isRunning = false;

    #region Unity Callbacks

    private void Awake()
    {
        foreach (Transform t in conditionsParent)
        {
            var cond = t.GetComponent<Condition>();
            if (cond)
                conditions.Add(cond);
        }
    }

    private void Start()
    {
        if (isRestart)
        {
            InitGame();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            Restart();

        if (Input.GetKeyDown(KeyCode.M))
            Launch();
    }

    #endregion


    #region Event Listener

    public void EVENT_Lauch()
    {
        Launch();
    }

    public void EVENT_OnAnimationEnd()
    {
        Debug.Log("Animation End");
    }

    public void BTN_StartGame()
    {
        InitGame();
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

    private void Restart()
    {
        isRestart = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void InitGame()
    {
        if (isRunning)
            return;
        isRunning = true;
        blackScreen.SetActive(false);
        startLight.SetActive(false);
        StartCoroutine(Routine_Countdown());
    }




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
        sceneAnimation.Play(failData.animation);
    }

    private void ExecuteSuccess()
    {
        Debug.Log("You WIN !!!!!");
        try
        {
            sceneAnimation.Play(successAnimationName);
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }
}
