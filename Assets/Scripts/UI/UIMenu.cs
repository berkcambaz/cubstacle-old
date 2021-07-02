using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenu : MonoBehaviour
{
    public static UIMenu Instance;

    public void Init() { Instance = this; }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void ButtonPlay()
    {
        Hide();

        User.Spawn();
        LevelManager.Instance.StartLevel();
    }

    public void ButtonShop()
    {

    }

    public void ButtonCustomize()
    {

    }
}
