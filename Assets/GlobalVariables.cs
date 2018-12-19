using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GlobalVariables : MonoBehaviour
{
    //Global Variables

    //Gamemode stuff.
    public int Wave;

    //Land Stuff
    public int MapLength = 10;
    public int MapLengthExpander = 1;
    public int heightScale = 5;
    public float detailScale = 1f;

    //Enemy Stuff
    public int EnemyLimit;
    public int EnemyStartSpeed;
    public int EnemySpeedIncrease;
}
