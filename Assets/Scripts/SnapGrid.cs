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

        Vector2 screen = new Vector2(2.8125f, 5f);
        Vector2 scale = transform.localScale;
        Vector2 offset = new Vector2(screen.x % scale.x, screen.y % scale.y);

        float snappedX;
        if (snapToCenter || snapToCenterX)
            snappedX = transform.position.x;
        else
            snappedX = transform.position.x - (transform.position.x == 0f ? 0f : Mathf.Sign(transform.position.x) * offset.x);

        float snappedY;
        if (snapToCenter || snapToCenterY)
            snappedY = transform.position.y;
        else
            snappedY = transform.position.y - (transform.position.y == 0f ? 0f : Mathf.Sign(transform.position.y) * offset.y);

        snappedX = RoundTo(snappedX, scale.x / 2f, snapToCenter || snapToCenterX ? 0f : offset.x);
        snappedY = RoundTo(snappedY, scale.y / 2f, snapToCenter || snapToCenterY ? 0f : offset.y);

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
