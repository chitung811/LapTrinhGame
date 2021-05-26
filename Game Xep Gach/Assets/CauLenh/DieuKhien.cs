using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieuKhien : MonoBehaviour
{
    float khoigach = 0;
    public float tocdochoi = 1;
    // Update is called once per frame
    void Update()
    {
        KiemTraNhanPhim();
    }

    void SangTrai()
    {
        transform.position += new Vector3(-1, 0, 0);
        if(!KiemTraVuotBien()) transform.position += new Vector3(1, 0, 0);
    }
    void SangPhai()
    {
        transform.position += new Vector3(1, 0, 0);
        if (!KiemTraVuotBien()) transform.position += new Vector3(-1, 0, 0);
    }
    void Quay()
    {
        transform.Rotate(0, 0, 90);
        if (!KiemTraVuotBien()) transform.Rotate(0, 0, -90);
    }
    void RoiXuong()
    {
        transform.position += new Vector3(0, -1, 0);
        if (!KiemTraVuotBien()) transform.position += new Vector3(0, 1, 0);
        khoigach = Time.time;
    }

    void KiemTraNhanPhim()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SangTrai();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SangPhai();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Quay();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time-khoigach >= tocdochoi)
        {
            RoiXuong();
        }
    }

    public bool KiemTraVuotBien()
    {
        foreach(Transform khoigach in transform)
        {
            Vector2 kt = FindObjectOfType<Bien_Gioi>().Round(khoigach.position);
            if (FindObjectOfType<Bien_Gioi>().ConTrongLuoi(kt) == false) return false;
        }
        return true;
    }
}
