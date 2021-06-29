using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public GameObject[] obstacleSets;

    private SeedRandom srandom;

    public void Init() { Instance = this; }

    public void StartLevel()
    {
        srandom = new SeedRandom(User.data.level);
        ProceedLevel();
    }

    public void ProceedLevel()
    {
        int obstacleSetId = srandom.Number(0, obstacleSets.Length);
        Instantiate(obstacleSets[obstacleSetId], transform.position, transform.rotation);
    }

    public void StopLevel()
    {

    }
}
