using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    private Vector3 touchPos;
    private Vector3 dragStartPos;
    private bool dragging = false;

    private Vector2 bounds;
    private Vector2 playerSize;

    void Start()
    {
        bounds = Game.Instance.cam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        playerSize = new Vector2(0.65f / 2.0f, 0.65f / 2.0f);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            touchPos = Game.Instance.cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButtonDown(0))
        {
            dragging = true;

            dragStartPos.x = touchPos.x - transform.position.x;
            dragStartPos.y = touchPos.y - transform.position.y;
        }

        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }

        if (dragging)
        {
            transform.position = new Vector3(touchPos.x - dragStartPos.x, touchPos.y - dragStartPos.y, transform.position.z);
        }

        ClampPlayerIntoBounds();
    }

    void ClampPlayerIntoBounds()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -bounds.x + playerSize.x, bounds.x - playerSize.x);
        pos.y = Mathf.Clamp(pos.y, -bounds.y + playerSize.y, bounds.y - playerSize.y);
        transform.position = pos;
    }
}
