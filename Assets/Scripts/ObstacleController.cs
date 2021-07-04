using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    public SpriteRenderer spriteRenderer;

    private float obstacleHeight;

    void Start()
    {
        obstacleHeight = transform.localScale.y / 2.0f;
    }

    void Update()
    {
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
