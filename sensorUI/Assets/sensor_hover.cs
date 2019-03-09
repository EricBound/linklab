using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sensor_hover : MonoBehaviour
{
    public GameObject info_title;
    public GameObject info_panel;
    public GameObject sensor;
    LineRenderer lr;
    //public Camera cam;
    // Start is called before the first frame update
    void Start()
    {

        lr = GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.startColor = Color.white;
        lr.endColor = Color.gray;
        /*
        lr.material = new Material(Shader.Find("Sprites/Default"));

        // Set some positions
        Vector3[] positions = new Vector3[3];
        positions[0] = new Vector3(-10.0f, -10.0f, 0.0f);
        positions[1] = new Vector3(0.0f, 10.0f, 0.0f);
        positions[2] = new Vector3(10.0f, -10.0f, 0.0f);
        lr.positionCount = positions.Length;
        lr.SetPositions(positions);

        // Set to face its Transform Component
        lr.alignment = LineAlignment.TransformZ;
        */       
        info_title.SetActive(false);
    }

    void OnMouseEnter()
    {
        info_title.SetActive(true);
        //info_title.transform.position = cam.WorldToScreenPoint(sensor.transform.position);
        lr.widthMultiplier = 1;
        lr.SetPosition(0, sensor.transform.position);
        lr.SetPosition(1, new Vector3(110, 90, 24));
    }

    void OnMouseDown()
    {
        if (info_panel.activeSelf == false)
        {
            info_panel.SetActive(true);
        }
        else
        {
            info_panel.SetActive(false);
        }
    }

    void OnMouseExit()
    {
        info_title.SetActive(false);
        info_panel.SetActive(false);
        lr.widthMultiplier = 0;
    }
    // Update is called once per frame
    void Update()
    {
           
    }
}
