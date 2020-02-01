using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColorOnSpriteRenderer : MonoBehaviour
{
    public SpriteRenderer target;

    public void SetR(float r)
    {
        var c = target.color;
        c.r = r;
        target.color = c;
    }

    public void SetG(float g)
    {
        var c = target.color;
        c.g = g;
        target.color = c;
    }

    public void SetB(float b)
    {
        var c = target.color;
        c.b = b;
        target.color = c;
    }

    public void SetA(float a)
    {
        var c = target.color;
        c.a = a;
        target.color = c;
    }
}
