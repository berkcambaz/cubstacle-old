using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public float speed;

    private Vector2 obstacleSize;

    void Start()
    {
        obstacleSize = new Vector2(transform.localScale.x / 2.0f, transform.localScale.y / 2.0f);
    }

    void Update()
    {
        // Move the obstacle down
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        // Destory if outside of the screen
        if (transform.position.y + obstacleSize.y < -Game.Instance.screenBounds.y)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
