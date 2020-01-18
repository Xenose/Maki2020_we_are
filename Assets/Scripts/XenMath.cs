using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class XenMath
{
    public static float AngleX(float angle, float radius)
    {
        float tmp = 0;

        if (angle > 180)
        {
            tmp = Mathf.Cos(3.1415f / 2 - angle) * radius;
        }
        else 
        {
            tmp = Mathf.Cos(3.1415f / 2 + angle) * radius;
        }

        return tmp;
    }

    public static float AngleY(float angle, float radius)
    {
        float tmp = 0;

        if (angle > 180)
        {
            tmp = Mathf.Sin(3.1415f / 2 - angle) * radius;
        }
        else 
        {
            tmp = Mathf.Sin(3.1415f / 2 + angle) * radius;
        }

        return tmp;
    }
}
