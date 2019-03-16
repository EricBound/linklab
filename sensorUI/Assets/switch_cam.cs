using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch_cam : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;
    public GameObject img;
    public GameObject eye;
    public GameObject top;
    public GameObject vis_prompt;
    // Start is called before the first frame update
    void Start()
    {
        cam1.gameObject.SetActive(true);
        cam1.tag = "MainCamera";
        Cursor.lockState = CursorLockMode.None;
        img.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (cam1.gameObject.activeSelf == true)
            {
                cam1.gameObject.SetActive(false);
                cam2.gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.Locked;
                img.SetActive(true);
                eye.SetActive(true);
                top.SetActive(false);
                vis_prompt.SetActive(true);
            }
            else if (cam2.gameObject.activeSelf == true)
            {
                cam2.gameObject.SetActive(false);
                cam1.gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                img.SetActive(false);
                eye.SetActive(false);
                top.SetActive(true);
                vis_prompt.SetActive(false);
            }
        }
    }
}
