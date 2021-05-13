using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// This script is ONLY for constants



public class Tags
{
    //Tags
    public const string WALL = "Wall";
    public const string BOX = "Box";
    public const string FRUIT = "Fruit";
    public const string BOMB = "Bomb";
    public const string TAIL = "Tail";
    public const string Node = "Head";
    public const string GHOST = "Ghost";

}

public class SpawnPointslvl1
{
    public static Vector3[] spawn =
    {
    new Vector3(-7.5f,3.5f,15f),
    new Vector3(-7.5f,3.5f,22.5f),
    new Vector3(-7.5f,3.5f,30f),
    new Vector3(-7.5f,3.5f,37.5f),
    new Vector3(-7.5f,3.5f,45f),
    new Vector3(-7.5f,3.5f, 52.5f),
    new Vector3(-37.5f,3.5f,15f),
    new Vector3(-37.5f,3.5f,22.5f),
    new Vector3(-37.5f,3.5f,30f),
    new Vector3(-37.5f,3.5f,37.5f),
    new Vector3(-37.5f,3.5f,45f),
    new Vector3(-37.5f,3.5f,52.5f),
    new Vector3(-52.5f,3.5f,15f),
    new Vector3(-52.5f,3.5f,22.5f),
    new Vector3(-52.5f,3.5f,30f),
    new Vector3(-52.5f,3.5f,37.5f),
    new Vector3(-52.5f,3.5f,45f),
    new Vector3(-52.5f,3.5f,52.5f),
    new Vector3(22.5f,3.5f,15f),
    new Vector3(22.5f,3.5f,22.5f),
    new Vector3(22.5f,3.5f,30f),
    new Vector3(22.5f,3.5f,37.5f),
    new Vector3(22.5f,3.5f,45f),
    new Vector3(22.5f,3.5f,52.5f)
};
}
public class SpawnPointslvl2
{
    public static Vector3[] spawn =
    {
    new Vector3(7.5f,3.5f,45f),
    new Vector3(-7.5f,3.5f,45f),
    new Vector3(-7.5f,3.5f,37.5f),
    new Vector3(-15f,3.5f,37.5f),
    new Vector3(-30f,3.5f,37.5f),    
    new Vector3(15f,3.5f,37.5f),
    new Vector3(30f,3.5f,7.5f),
    new Vector3(-30f,3.5f,7.5f),
    new Vector3(30f,3.5f,-7.5f),
    new Vector3(-30f,3.5f,-7.5f),
    new Vector3(30f,3.5f,52.5f),
    new Vector3(-52.5f,3.5f,52.5f),
    new Vector3(52.5f,3.5f,52.5f),
    new Vector3(-52.5f,3.5f,7.5f),
    new Vector3(52.5f,3.5f,7.5f),
    new Vector3(7.5f,3.5f,7.5f),
    new Vector3(-7.5f,3.5f,7.5f) 
};
}

public class Metrics
{
    public static float NODEHEADDIST = 7.5f;
    public static float NODESIZE = 7.5f;
}

public enum PlayerDirection
{   // Movements allowed
    LEFT = 0,
    UP = 1,
    RIGHT = 2,
    DOWN = 3,
    COUNT =  4
}
