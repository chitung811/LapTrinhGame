using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bien_Gioi : MonoBehaviour
{
    public static int Luoi_Rong = 10;
    public static int Luoi_Cao = 20;
    public bool ConTrongLuoi(Vector2 kt)
    {
        return ((int)kt.x >= 0 && (int)kt.x < Luoi_Rong && (int)kt.y >= 0);
    }

    public Vector2 Round(Vector2 vt)
    {
        return new Vector2(Mathf.Round(vt.x), Mathf.Round(vt.y));
    }
}
