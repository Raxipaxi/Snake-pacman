using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public int Id { get; set; }
    public string Nickname { get; set; }
    public int Level { get; set; }
    public int Score { get; set; }

    public Player()
    {
        var nameCollection = new NamesBasic();

        this.Nickname = string.Empty;
        this.Level = 0;
        this.Score = 0;

    }
}
