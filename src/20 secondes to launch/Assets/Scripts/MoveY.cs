using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveY : MonoBehaviour
{
    [SerializeField] private float speed;

    public float Speed { get => speed; set => speed = value; }

    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
