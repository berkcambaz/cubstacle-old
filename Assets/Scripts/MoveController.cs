using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float speed;

    void Update()
    {
        // Move the obstacle down
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
