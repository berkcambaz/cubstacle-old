using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    public SpriteRenderer spriteRenderer;

    public float speed;

    private float obstacleHeight;

    void Start()
    {
        obstacleHeight = transform.localScale.y / 2.0f;
    }

    void Update()
    {
        // Move the obstacle down
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        // Destory if outside of the screen
        if (transform.position.y + obstacleHeight < -Game.Instance.screenBounds.y)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        boxCollider.enabled = false;
        spriteRenderer.enabled = false;
    }
}
