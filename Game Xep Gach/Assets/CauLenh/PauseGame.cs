using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    bool Paused = false;
    public GameObject PauseMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused == true)
            {
                //phanCanhChinh.gameObject.SetActive(PanelMenu.gameObject.activeSelf);
                PauseMenu.SetActive(false);
                Time.timeScale = 1.0f;
                Paused = false;
                Debug.Log("Unpause");
            }
            else
            {
                //PanelMenu.SetActive(false);
                PauseMenu.SetActive(true);
                Time.timeScale = 0.0f;
                Paused = true;
                Debug.Log("Pause");
            }
        }
    }
}
