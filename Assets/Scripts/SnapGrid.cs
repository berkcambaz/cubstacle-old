using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class SnapGrid : MonoBehaviour
{
#if UNITY_EDITOR
    public bool snapToCenter = false;
    public bool snapToCenterX = false;
    public bool snapToCenterY = false;

    void Update()
    {
        if (EditorApplication.isPlaying) return;

        float snappedX;
        if (snapToCenter || snapToCenterX)
            snappedX = transform.position.x;
        else
            snappedX = transform.position.x - (transform.position.x == 0f ? 0f : Mathf.Sign(transform.position.x) * 0.2125f);

        float snappedY;
        if (snapToCenter || snapToCenterY)
            snappedY = transform.position.y;
        else
            snappedY = transform.position.y - (transform.position.y == 0f ? 0f : Mathf.Sign(transform.position.y) * -0.2f);

        snappedX = RoundTo(snappedX, 0.325f, snapToCenter || snapToCenterX ? 0f : 0.2125f);
        snappedY = RoundTo(snappedY, 0.325f, snapToCenter || snapToCenterY ? 0f : -0.2f);

        transform.position = new Vector3(snappedX, snappedY, transform.position.z);
    }

    float RoundTo(float value, float multiplier, float offset)
    {
        float output = Mathf.Round(value / multiplier) * multiplier;
        if (output > 0f) output += offset;
        else if (output < 0f) output -= offset;
        return output;
    }
#endif
}
