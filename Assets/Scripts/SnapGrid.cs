using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SnapGrid : MonoBehaviour
{
    public bool snapToCenter = false;

    void Update()
    {
        Vector3 pos = new Vector3(
            RoundTo(transform.position.x, 0.325f, snapToCenter ? 0f : 0.2125f),
            RoundTo(transform.position.y, 0.325f, snapToCenter ? 0f : -0.2f),
            RoundTo(transform.position.z, 1f, 0f)
        );

        transform.position = pos;
    }

    float RoundTo(float value, float multiplier, float offset)
    {
        float output = Mathf.Round(value / multiplier) * multiplier;
        if (output > 0f) output += offset;
        else if (output < 0f) output -= offset;
        return output;
    }
}
