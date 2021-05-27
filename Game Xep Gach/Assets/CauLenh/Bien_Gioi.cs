using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bien_Gioi : MonoBehaviour
{
    public static int Luoi_Rong = 10;
    public static int Luoi_Cao = 10;
    public bool ConTrongLuoi(Vector2 kt)
    {
        return ((int)kt.x >= 0 && (int)kt.x < Luoi_Rong && (int)kt.y >= 0);
    }

    private void Start()
    {
        KhoiTaoKhoiGach();
    }

    public Vector2 Round(Vector2 vt)
    {
        return new Vector2(Mathf.Round(vt.x), Mathf.Round(vt.y));
    }

    //Ham tao ngau nhien gach
    string TaoNgauNhienGach()
    {
        int SoNgauNhien = Random.Range(1, 8);
        string KhoiGachNhauNhien = "MauVat/Khoi_O";
        switch (SoNgauNhien)
        {
            case 1: KhoiGachNhauNhien = "MauVat/Khoi_O"; break;
            case 2: KhoiGachNhauNhien = "MauVat/Khoi_I"; break;
            case 3: KhoiGachNhauNhien = "MauVat/Khoi_T"; break;
            case 4: KhoiGachNhauNhien = "MauVat/Khoi_J"; break;
            case 5: KhoiGachNhauNhien = "MauVat/Khoi_L"; break;
            case 6: KhoiGachNhauNhien = "MauVat/Khoi_Z"; break;
            case 7: KhoiGachNhauNhien = "MauVat/Khoi_S"; break;
            default : KhoiGachNhauNhien = "MauVat/Khoi_O"; break;
        }
        return KhoiGachNhauNhien;
    }

    //Khoi tao gach
    public void KhoiTaoKhoiGach()
    {
        GameObject khoigachhientai = (GameObject)Instantiate(Resources.Load(TaoNgauNhienGach(), typeof(GameObject)), new Vector2(5.0f, 19.0f), Quaternion.identity);
    }
}
