using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMain : MonoBehaviour
{
    public static UIMain Instance;

    public Text textHighscore;
    public Text textScore;
    public Text textLevel;

    public void Init() { Instance = this; }

    public void UpdateScore()
    {
        textHighscore.text = "Highscore: " + User.data.highscore.ToString();
        textScore.text = User.data.score.ToString();
    }

    public void UpdateLevel()
    {
        textLevel.text = User.data.level.ToString();
    }
}
