using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    private Vector3 touchPos;
    private Vector3 dragStartPos;
    private bool dragging = false;

    void Start()
    {

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
    }
}
