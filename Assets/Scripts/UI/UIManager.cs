using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public UIMain uiMain;

    public void Init()
    {
        Instance = this;

        // Initialize other components of the UI
        uiMain.Init();

        // Update necessary parts of the UI
        uiMain.UpdateScore();
        uiMain.UpdateLevel();
    }
}