using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DieuKhien : MonoBehaviour
{
    //public PhanCanhChinh phanCanhChinh;
    public GameObject PanelMenu;
    float khoigach = 0;
    public float tocdochoi = 1;
    bool Paused = false;

    //Toc do luc giu phim sang ngang va xuong duoi
    float DangNhanSangNgang = 0.05f;
    float DangNhanXuongDuoi = 0.02f;

    //Thoi gian
    float ThoiGianLapKhiGiuPhim = 0.2f;
    float ThoiGianSangNgang = 0;
    float ThoiGianXuongDuoi = 0;
    float ThoiGianNhanPhim = 0;

    //bool di chuyen
    bool DiChuyenChieuNgang = false;
    bool DiChuyenChieuDoc = false;
    public bool DuocPhepXoay = true;
    public bool XoayMotLan = false;

    //Cac thuoc tinh am thanh
    public AudioClip NguonDiChuyen;
    public AudioClip NguonRoiXuong;
    public AudioClip NguonXoay;
    private AudioSource AmThanh;

    private void Start()
    {
        AmThanh = GetComponent<AudioSource>();
    }

    private void AmThanhDiChuyen()
    {
        AmThanh.PlayOneShot(NguonDiChuyen);
    }
    private void AmThanhRoiXuong()
    {
        AmThanh.PlayOneShot(NguonRoiXuong);
    }
    private void AmThanhXoay()
    {
        AmThanh.PlayOneShot(NguonXoay);
    }
    // Update is called once per frame
    void Update()
    {
        KiemTraNhanPhim();
        Pause();
    }

    void SangTrai()
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
        transform.position += new Vector3(-1, 0, 0);
        if (!KiemTraVuotBien()) transform.position += new Vector3(1, 0, 0);
        AmThanhDiChuyen();
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
        AmThanhDiChuyen();
    }
    void Quay()
    {
        if (DuocPhepXoay)
        {
            if (XoayMotLan)
            {
                if (transform.rotation.eulerAngles.z >= 90) transform.Rotate(0, 0, -90); else transform.Rotate(0, 0, -90);
            }
            else transform.Rotate(0, 0, 90);
            AmThanhXoay();
        }
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
            AmThanhDiChuyen();
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
        else
        {
            transform.position += new Vector3(0, 1, 0);
            FindObjectOfType<Bien_Gioi>().XoaDong();
            AmThanhRoiXuong();
            if (FindObjectOfType<Bien_Gioi>().KiemTraKetThucGame(this)) FindObjectOfType<Bien_Gioi>().KetThucGame();
            enabled = false;
            FindObjectOfType<Bien_Gioi>().KhoiTaoKhoiGach();
        }
        khoigach = Time.time;
    }

    void KiemTraNhanPhim()
    {
        if (!Paused)
        {
            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.DownArrow))
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
            if (Input.GetKey(KeyCode.DownArrow) || Time.time - khoigach >= tocdochoi)
            {
                RoiXuong();
            }
        }
    }

    void Pause()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    if (Paused == true)
        //    {
        //        phanCanhChinh.gameObject.SetActive(PanelMenu.gameObject.activeSelf);
        //        PanelMenu.SetActive(false);
        //        Time.timeScale = 1.0f;
        //        Paused = false;
        //        Debug.Log("Unpause");
        //    }
        //    else
        //    {
        //        PanelMenu.SetActive(false);
        //        PanelMenu.SetActive(true);
        //        Time.timeScale = 0.0f;
        //        Paused = true;
        //        Debug.Log("Pause");
        //    }
        //}
    }

    public bool KiemTraVuotBien()
    {
        foreach (Transform khoigach in transform)
        {
            Vector2 kt = FindObjectOfType<Bien_Gioi>().Round(khoigach.position);
            if (FindObjectOfType<Bien_Gioi>().ConTrongLuoi(kt) == false) return false;
            if (FindObjectOfType<Bien_Gioi>().TonTaiGach(kt) != null && FindObjectOfType<Bien_Gioi>().TonTaiGach(kt).parent != transform) return false;
        }
        return true;
    }
}