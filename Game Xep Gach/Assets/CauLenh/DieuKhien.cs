using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieuKhien : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        KiemTraNhanPhim();
    }

    void SangTrai()
    {
        transform.position += new Vector3(-1, 0, 0);
    }
    void SangPhai()
    {

    }
    void Quay()
    {

    }
    void RoiXuong()
    {

    }

    void KiemTraNhanPhim()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SangTrai();
        }
    }
}
