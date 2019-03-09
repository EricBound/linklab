using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch_cam : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;
    // Start is called before the first frame update
    void Start()
    {
        cam1.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (cam1.gameObject.activeSelf == true)
            {
                cam1.gameObject.SetActive(false);
                cam2.gameObject.SetActive(true);
            }
            else if (cam2.gameObject.activeSelf == true)
            {
                cam2.gameObject.SetActive(false);
                cam1.gameObject.SetActive(true);
            }
            /*
            if (cam1.enabled)
            {
                cam1.enabled = false;
                cam2.tag = "MainCamera";
                cam2.enabled = true;
            }
            else if (cam2.enabled)
            {
                cam2.enabled = false;
                cam1.tag = "MainCamera";
                cam1.enabled = true;
            }
            */
        }
    }
}
