using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// This script is ONLY for constants



public class Tags
{
    //Tags
    public static string WALL = "Wall";
    public static string BOX = "Box";
    public static string FRUIT = "Fruit";
    public static string BOMB = "Bomb";
    public static string Tail = "Tail";
    public static string Node = "Head";

}

public class Metrics
{
    public static float NODEHEADDIST = 5.5f;
    public static float NODESIZE = 5.5f;
}

public enum PlayerDirection
{   // Movements allowed
    LEFT = 0,
    UP = 1,
    RIGHT = 2,
    DOWN = 3,
    COUNT =  4
}
