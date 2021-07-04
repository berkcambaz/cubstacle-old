using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSetController : MonoBehaviour
{
    // Top point has the highest y value in a obstacle set
    public Transform topPoint;

    private bool nextObstacleSetSpawned = false;

    private void Update()
    {
        // If top point is outside the screen, obstacle set is finished
        if (topPoint.position.y < -Game.Instance.screenBounds.y)
        {
            Destroy(gameObject);
        }

        // When top point is at the center of the screen, spawn the new obstacle set
        if (topPoint.position.y < 0f && !nextObstacleSetSpawned)
        {
            LevelManager.Instance.ProceedLevel();
            nextObstacleSetSpawned = true;
        }
    }
}
