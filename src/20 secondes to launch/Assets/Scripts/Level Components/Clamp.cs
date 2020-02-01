using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clamp : MonoBehaviour
{
    [SerializeField] private Transform openPosition;
    [SerializeField] private Transform closedPosition;
    [SerializeField] private float speed = 1;
    [SerializeField] private float stopDistance = 0.1f;
    [SerializeField] private BoolCondition condition;

    private bool isMoving;

    public void OnButtonClick()
    {
        if (isMoving)
            return;

        if (condition.Value)
        {
            StartCoroutine(Routine_Close());
        }
        else
        {
            StartCoroutine(Routine_Open());
        }

    }

    private IEnumerator Routine_Open()
    {
        isMoving = true;
        var target = openPosition.position;
        while (Vector3.Distance(transform.position, target) > stopDistance)
        {
            transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * speed);
            yield return 0;
        }
        transform.position = target;
        condition.Value = true;
        isMoving = false;
    }

    private IEnumerator Routine_Close()
    {
        isMoving = true;
        condition.Value = false;
        var target = closedPosition.position;
        while (Vector3.Distance(transform.position, target) > stopDistance)
        {
            transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * speed);
            yield return 0;
        }
        transform.position = target;
        isMoving = false;
    }

}
