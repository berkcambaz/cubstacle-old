using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance;

    public Camera cam;

    void Awake()
    {
        Instance = this;
        SaveData saveData = SaveData.Load();
    }

    void Update()
    {
        
    }
}
