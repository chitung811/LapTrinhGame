using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieuKhien : MonoBehaviour
{
    float khoigach = 0;
    public float tocdochoi = 1;

    //Toc do luc giu phim sang ngang va xuong duoi
    float DangNhanSangNgang = 0.05f;
    float DangNhanXuongDuoi = 0.1f;

    //Thoi gian
    float ThoiGianLapKhiGiuPhim = 0.2f;
    float ThoiGianSangNgang = 0;
    float ThoiGianXuongDuoi = 0;
    float ThoiGianNhanPhim = 0;

    //bool di chuyen
    bool DiChuyenChieuNgang = false;
    bool DiChuyenChieuDoc = false;

    // Update is called once per frame
    void Update()
    {
        KiemTraNhanPhim();
    }

    void SangTrai()
    {
        if (DiChuyenChieuNgang)
        {
            if(ThoiGianNhanPhim < ThoiGianLapKhiGiuPhim)
            {
                ThoiGianNhanPhim += Time.deltaTime;
                return;
            }
            if(ThoiGianSangNgang < DangNhanSangNgang)
            {
                ThoiGianSangNgang += Time.deltaTime;
                return;
            }
        }
        else
        {
            DiChuyenChieuNgang = true;
        }
        ThoiGianSangNgang = 0;
        transform.position += new Vector3(-1, 0, 0);
        if(!KiemTraVuotBien()) transform.position += new Vector3(1, 0, 0);
    }
    void SangPhai()
    {
        if (DiChuyenChieuNgang)
        {
            if (ThoiGianNhanPhim < ThoiGianLapKhiGiuPhim)
            {
                ThoiGianNhanPhim += Time.deltaTime;
                return;
            }
            if (ThoiGianSangNgang < DangNhanSangNgang)
            {
                ThoiGianSangNgang += Time.deltaTime;
                return;
            }
        }
        else
        {
            DiChuyenChieuNgang = true;
        }
        ThoiGianSangNgang = 0;
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
        if (DiChuyenChieuDoc)
        {
            if (ThoiGianNhanPhim < ThoiGianLapKhiGiuPhim)
            {
                ThoiGianNhanPhim += Time.deltaTime;
                return;
            }
            if (ThoiGianXuongDuoi < DangNhanXuongDuoi)
            {
                ThoiGianXuongDuoi += Time.deltaTime;
                return;
            }
        }
        else
        {
            DiChuyenChieuDoc = true;
        }
        ThoiGianXuongDuoi = 0;
        transform.position += new Vector3(0, -1, 0);
        if (KiemTraVuotBien())
        {
            FindObjectOfType<Bien_Gioi>().UpdateLuoi(this);
        }
        else{ 
            transform.position += new Vector3(0, 1, 0);
            enabled = false;
            FindObjectOfType<Bien_Gioi>().KhoiTaoKhoiGach();
        }
        khoigach = Time.time;
    }

    void KiemTraNhanPhim()
    {
        if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            DiChuyenChieuNgang = false;
            DiChuyenChieuDoc = false;
            ThoiGianSangNgang = 0;
            ThoiGianXuongDuoi = 0;
            ThoiGianNhanPhim = 0;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            SangTrai();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            SangPhai();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Quay();
        }
        if (Input.GetKey(KeyCode.DownArrow) || Time.time-khoigach >= tocdochoi)
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
            if (FindObjectOfType<Bien_Gioi>().TonTaiGach(kt) != null && FindObjectOfType<Bien_Gioi>().TonTaiGach(kt).parent != transform) return false;
        }
        return true;
    }
}
