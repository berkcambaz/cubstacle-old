using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSetController : MonoBehaviour
{
    // Last child has the highest y value in a obstacle set
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
