using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public GameObject[] obstacleSets;

    private SeedRandom srandom;
    private List<GameObject> currentObstacleSets;
    private float levelCountdown;

    public void Init() { Instance = this; }

    public void StartLevel()
    {
        srandom = new SeedRandom(User.data.level);

        currentObstacleSets = new List<GameObject>();

        // Level countdown is ranging from 15.5 to 25 seconds depending on the level
        levelCountdown = 15f + Mathf.Clamp(User.data.level * 0.05f, 0f, 10f);

        // Start the countdown timer
        StartCoroutine(LevelCountdownTimer());

        ProceedLevel();
    }

    public void ProceedLevel()
    {
        int obstacleSetId = srandom.Number(0, obstacleSets.Length);
        currentObstacleSets.Add(Instantiate(obstacleSets[obstacleSetId], transform.position, transform.rotation));
    }

    public void StopLevel(bool _success)
    {
        for (int i = 0; i < currentObstacleSets.Count; i++)
        {
            if (currentObstacleSets[i] != null)
                Destroy(currentObstacleSets[i]);
        }

        User.Despawn();
        if (_success) User.CompleteLevel();

        UIMenu.Instance.Show();
    }

    private IEnumerator LevelCountdownTimer()
    {
        float countdown = levelCountdown;

        while (levelCountdown > 0f && User.alive)
        {
            UIMain.Instance.UpdateLevelProgress(1f - levelCountdown / countdown);
            levelCountdown -= Time.deltaTime;
            yield return null;
        }

        // After countdown has finished, if user is still alive, completed successfully.
        // Otherwise, "StopLevel" has already been called with "false" somewhere
        if (User.alive)
            StopLevel(true);
    }
}
