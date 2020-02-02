using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolCondition : Condition
{
    [SerializeField] private bool value;
    public bool reversed = false;

    public bool Value { get => value; set => this.value = value; }

    public override bool IsValid() => reversed ^ value;

    public void Switch() => value ^= true;
}
