using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntCondition : Condition
{
    public int value;
    public int maxValue;
    public int minValue;

    public override bool IsValid() => value <= maxValue && value >= minValue;

    public void Increase() => value++;

    public void Decrease() => value--;
}
