using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{
    public static int Up = 1;
    public static int UpRight = 2;
    public static int Right = 3;
    public static int DownRight = 4;
    public static int Down = 5;
    public static int DownLeft = 6;
    public static int Left = 7;
    public static int UpLeft = 8;
    public static int player1Direction = 1;
    public static int player2Direction = 1;
    public static bool p1Priority;
    public static bool noPriority = true;
    public static GameObject player1;
    public static GameObject player2;
    public static int fromDirection; // 1 = right, 0 = center, -1 = left
    public static bool startedGame = false;
}
