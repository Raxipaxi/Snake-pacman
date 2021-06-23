using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingElement : MonoBehaviour
{
    public Text Nickname;
    public Text Level;
    public Text Score;

    public void SetDefaultText()
    {
        this.Nickname.text = "---";
        this.Level.text = "---";
        this.Score.text = "---";
    }

    public void SetInfo(string nickname, int level, int score)
    {
        this.Nickname.text = nickname;
        this.Level.text = level.ToString();
        this.Score.text = score.ToString();
    }
}

