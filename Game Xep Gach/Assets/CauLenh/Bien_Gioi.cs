using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bien_Gioi : MonoBehaviour
{
    public static int Luoi_Rong = 10;
    public static int Luoi_Cao = 20;
    public static Transform[,] luoi = new Transform[Luoi_Rong, Luoi_Cao];
    private GameObject khoigachhientai, khoigachtieptheo;
    private bool BatDauChoi = false;
    private Vector2 HienHinhTiepTheo = new Vector2(15.15f, 15.75f);

    //Tạo số điểm khi xóa dòng cùng lúc
    public int XoaMotDong = 100;
    public int XoaHaiDong = 300;
    public int XoaBaDong = 800;
    public int XoaBonDong = 1200;

    public Text HienThiDiemSo;
    public Text HienThiCapDo;
    public Text HienThiDongXoa;

    private int SoDongBiXoa = 0;
    private int TongSoDongBiXoa = 0;
    private int CapDo = 0;
    private int DiemSoNguoiChoi = 0;
    private int SoDongTangCap = 5;
    private void UpdateDiemSo()
    {
        if(SoDongBiXoa > 0)
        {
            switch (SoDongBiXoa)
            {
                case 1:
                    {
                        DiemSoNguoiChoi += XoaMotDong;
                        TongSoDongBiXoa += 1;
                        break;
                    }
                case 2:
                    {
                        DiemSoNguoiChoi += XoaHaiDong;
                        TongSoDongBiXoa += 2;
                        break;
                    }
                case 3:
                    {
                        DiemSoNguoiChoi += XoaBaDong;
                        TongSoDongBiXoa += 3;
                        break;
                    }
                case 4:
                    {
                        DiemSoNguoiChoi += XoaBonDong;
                        TongSoDongBiXoa += 4;
                        break;
                    }
                default: break;
            }
            SoDongBiXoa = 0;
        }
    }



    void UpdateUI()
    {
        HienThiDiemSo.text = DiemSoNguoiChoi.ToString();
        HienThiCapDo.text = CapDo.ToString();
        HienThiDongXoa.text = TongSoDongBiXoa.ToString();
    }
   void UpdateCapDo()
    {
        if(TongSoDongBiXoa >= SoDongTangCap)
        {
            CapDo = TongSoDongBiXoa / SoDongTangCap;
        }
    }

    public bool ConTrongLuoi(Vector2 kt)
    {
        return ((int)kt.x >= 0 && (int)kt.x < Luoi_Rong && (int)kt.y >= 0);
    }

    private void Start()
    {
        KhoiTaoKhoiGach();
    }
    void Update()
    {
        UpdateDiemSo();
        UpdateCapDo();
        UpdateUI();
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
        if (!BatDauChoi)
        {
            BatDauChoi = true;

            khoigachhientai = (GameObject)Instantiate(Resources.Load(TaoNgauNhienGach(), typeof(GameObject)), new Vector2(5.0f, 20.0f), Quaternion.identity);
            khoigachtieptheo = (GameObject)Instantiate(Resources.Load(TaoNgauNhienGach(), typeof(GameObject)), HienHinhTiepTheo, Quaternion.identity);
            khoigachtieptheo.GetComponent<DieuKhien>().enabled = false;
        }
        else
        {
            khoigachtieptheo.transform.localPosition = new Vector2(5.0f, 20.0f);
            khoigachhientai = khoigachtieptheo;
            khoigachtieptheo.GetComponent<DieuKhien>().enabled = true;
            khoigachtieptheo = (GameObject)Instantiate(Resources.Load(TaoNgauNhienGach(), typeof(GameObject)), HienHinhTiepTheo, Quaternion.identity);
            khoigachtieptheo.GetComponent<DieuKhien>().enabled = false;
        }


    }
    public Transform TonTaiGach(Vector2 kt)
    {
        if (kt.y > Luoi_Cao - 1) return null; else return luoi[(int)kt.x, (int)kt.y];
    }

    public void UpdateLuoi(DieuKhien khoigach)
    {
        for(int y=0;y< Luoi_Cao; ++y)
        {
            for(int x=0; x< Luoi_Rong; ++x)
            {
                if (luoi[x, y] != null) if (luoi[x, y].parent == khoigach.transform) luoi[x, y] = null;
            }
        }
        foreach (Transform kt in khoigach.transform)
        {
            Vector2 vt = Round(kt.position);
            if (vt.y < Luoi_Cao) luoi[(int)vt.x, (int)vt.y] = kt;
        }
    }
    //Bao cao da day dong

    public bool DaDayDong(int y)
    {
        for(int x=0;x < Luoi_Rong;++x)
        {
            if (luoi[x, y] == null) return false;
        }
        SoDongBiXoa++;
        return true;
    }

    public void ChuyenXuong(int y)
    {
        for(int x=0; x < Luoi_Rong;++x)
        {
            if(luoi[x,y] != null)
            {
                luoi[x, y - 1] = luoi[x, y];
                luoi[x, y] = null;
                luoi[x, y - 1].position += new Vector3(0, -1, 0);
            }
        }
    }

    public void ChuyenHetXuong(int y)
    {
        for(int i=y; i < Luoi_Cao;++i)
        {
            ChuyenXuong(i);
        }
    }

    public void XoaDongDay(int y)
    {
        for(int x=0; x < Luoi_Rong; ++x)
        {
            Destroy(luoi[x, y].gameObject);
            luoi[x, y] = null;
        }
    }

    public void XoaDong()
    {
        for(int y=0; y < Luoi_Cao; ++y)
        {
            if (DaDayDong(y))
            {
                XoaDongDay(y);
                ChuyenHetXuong(y + 1);
                --y;
            }
        }
    }

    public bool KiemTraKetThucGame(DieuKhien khoigach)
    {
        for(int x=0; x<Luoi_Rong; ++x)
        {
            foreach(Transform kt in khoigach.transform)
            {
                Vector2 gach = Round(kt.position);
                if(gach.y > Luoi_Cao - 1) return true;
            }
        }
        return false;
    }
    public void KetThucGame()
    {
        Application.LoadLevel("KetThucGame");
    }
    public void ThoatGame()
    {
        Debug.Log("Yêu cầu kết thúc game");
        Application.Quit();
    }
}
