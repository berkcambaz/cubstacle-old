using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance;

    public Camera cam;
    public Vector2 bounds;
    public Vector2 playerSize;

    void Awake()
    {
        Instance = this;
        bounds = cam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        playerSize = new Vector2(0.65f / 2.0f, 0.65f / 2.0f);
        Debug.Log(bounds.x);
        Debug.Log(bounds.y);
        ConfigAspectRatio();

        User.Load();
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
        // (dt / ( defRes.x /  defRes.y)    Native resolution of the game
        // (dt / (currRes.x / currRes.y)    Phone's resolution
    }
}
