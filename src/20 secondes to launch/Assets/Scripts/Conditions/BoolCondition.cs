using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolCondition : Condition
{
    public bool value;
    public bool reversed = false;

    public override bool IsValid() => reversed ? value : !value;
}
