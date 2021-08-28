using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatDauGame : MonoBehaviour
{
    public void ChoiMoi()
    {
        Time.timeScale = 1.0f;
        Debug.Log("Đang gọi Phân cảnh chính");
        Application.LoadLevel("PhanCanhChinh");
    }
    public void ThoatGame()
    {
        Debug.Log("Yêu cầu kết thúc game");
        Application.Quit();
    }
}
