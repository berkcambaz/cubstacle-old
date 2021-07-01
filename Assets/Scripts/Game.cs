using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance;

    public Camera cam;

    public LevelManager levelManager;
    public UIManager uiManager;

    [System.NonSerialized] public Vector2 screenBounds;

    void Awake()
    {
        Instance = this;

        ConfigAspectRatio();

        screenBounds = cam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        User.Load();

        // Init managers
        levelManager.Init();
        uiManager.Init();

        LevelManager.Instance.StartLevel();
    }

    private void OnApplicationQuit()
    {
        User.Save();
    }

    private void ConfigAspectRatio()
    {
        float size = 5f;

        Vector2 defRes = new Vector2(1080f, 1920f);
        Vector2 currRes = new Vector2(Screen.width, Screen.height);
        float dt = size * (defRes.x / defRes.y);

        cam.orthographicSize = dt / (currRes.x / currRes.y);
    }
}
