using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSetController : MonoBehaviour
{
    // lastChild has the highest y value
    public GameObject lastChild;

    private void Update()
    {
        // If child is null, obstacle set is finished
        if (lastChild == null)
        {
            LevelManager.Instance.ProceedLevel();
            Destroy(gameObject);
        }
    }
}
