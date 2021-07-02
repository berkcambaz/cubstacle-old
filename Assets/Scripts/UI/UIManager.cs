using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public UIMain uiMain;
    public UIMenu uiMenu;

    public void Init()
    {
        Instance = this;

        // Initialize other components of the UI
        uiMain.Init();
        uiMenu.Init();

        // Update necessary parts of the UI
        uiMain.UpdateScore();
        uiMain.UpdateLevel();
    }
}