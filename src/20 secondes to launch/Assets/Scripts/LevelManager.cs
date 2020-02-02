using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
#pragma warning disable CS0649
    [SerializeField] private DragValue thatFuckingLever; // don't judge me
    [SerializeField] private MonoBehaviour[] componentToActivateOnInit;
    [SerializeField] private Button[] buttons;

    [Header("Componants")]
    [SerializeField] private Transform conditionsParent;
    [SerializeField] private Animation sceneAnimation;
    [SerializeField] private TextMeshPro countdownText;
    [SerializeField] private GameObject blackScreen;
    [SerializeField] private GameObject startLight;
    [SerializeField] private SpriteRenderer flashSpriteRenderer;

    [Header("Settings")]
    [SerializeField] private int initialCountdown = 20;
    [SerializeField] private string successAnimationName;
    [SerializeField] private float flashDuration = 1;

#pragma warning restore CS0649

    private static bool isRestart = false;

    private readonly List<Condition> conditions = new List<Condition>();
    private bool isRunning = false;
    private bool isFinish = false;
    private bool isPlayingAnimation = false;
    private bool isWin = false;

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
        else
        {
            EnableButton(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !isPlayingAnimation)
            Restart();
    }

    #endregion


    #region Event Listener

    public void EVENT_Lauch()
    {
        Launch();
    }

    public void EVENT_OnAnimationEnd()
    {
        if (!isWin)
            Restart();
        else
            Win();
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


    private IEnumerator Routine_Restart()
    {
        isRestart = true;
        EnableButton(false);

        flashSpriteRenderer.gameObject.SetActive(true);
        for (float a = 0; a <= flashDuration; a += Time.deltaTime)
        {
            flashSpriteRenderer.color = new Color(1, 1, 1, Mathf.InverseLerp(0, flashDuration, a));
            yield return 0;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    #endregion

    private void EnableButton(bool value)
    {
        foreach (var btn in buttons)
            btn.IsInteractable = value;
        thatFuckingLever.IsInteractable = value;

        foreach (var comp in componentToActivateOnInit)
            comp.enabled = value;
    }

    public void Fail(string animation)
    {
        if (isFinish)
            return;
        isFinish = true;

        ExecuteFail(animation);
    }

    private void Restart()
    {
        StartCoroutine(Routine_Restart());
    }

    private void Win()
    {
        Debug.Log("WIN");
    }

    private void InitGame()
    {
        if (isRunning)
            return;
        isRunning = true;

        EnableButton(true);

        blackScreen.SetActive(false);
        startLight.SetActive(false);

        StartCoroutine(Routine_Countdown());
    }

    private void Launch()
    {
        if (isFinish)
            return;
        isFinish = true;

        foreach (var cond in conditions)
            if (!cond.IsValid())
            {
                ExecuteFail(cond.FailAnimation);
                return;
            }
        ExecuteSuccess();
    }

    private void ExecuteFail(string animation)
    {
        EnableButton(false);
        isPlayingAnimation = true;
        sceneAnimation.Play(animation);
    }

    private void ExecuteSuccess()
    {
        EnableButton(false);
        isPlayingAnimation = true;
        sceneAnimation.Play(successAnimationName);
    }
}
