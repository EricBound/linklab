﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class instantiate : MonoBehaviour
{
    public GameObject sensor;
    public TextAsset file;
    public TextAsset data;
    public Material mat1;
    public Material mat2;
    //public string[][] coords;
    public static string[] coord_1d;
    public static int count = -1;
    public static string[][] coords;
    public static string[][] data_array;
    // Start is called before the first frame update
    void Start()
    {
        /*
        string[] lines = file.text.Split("\n"[0]);


        for (int i = 0; i < lines.Length; i++)
        {
        Debug.Log(lines[i]);       
        coords[i] = lines[i].Split(","[0]);
        }

        for (int i = 0; i < coords.Length; i++)
        {
            Instantiate(sensor, new Vector3(int.Parse(coords[i][0]), int.Parse(coords[i][1]),
        int.Parse(coords[i][2])), transform.localRotation);
            
        }
    */
        string[] lines = file.text.Split("\n"[0]);
        int rows = lines.Length;
        //string[][] coords = new string[lines.Length][];
        coords = new string[lines.Length][];
        for (int i = 0; i < lines.Length; i++) // for each line
        {
        // Debug.Log(lines[i]);
            string[] stringsLine = lines[i].Split(","[0]);    
            coords[i] = stringsLine;
        }

        string[] data_lines = data.text.Split("\n"[0]);
        data_array = new string[data_lines.Length][];
        for (int i = 0; i < data_lines.Length; i++)
        {
            string[] data_string = data_lines[i].Split(","[0]);
            data_array[i] = data_string;
        }

        for (int i = 0; i < coords.Length; i++)
        {
            var newSensor = Instantiate(sensor, new Vector3(float.Parse(coords[i][1]), 0, float.Parse(coords[i][2])), transform.localRotation);
            newSensor.GetComponent<Renderer>().material = mat1;
            var test = newSensor.GetComponent<assign_data>();
            test.panel.text = "No data";

            for(int j = 0; j < data_array.Length; j++)
            {
                if (data_array[j][0] == coords[i][0])
                {
                    test.panel.text = "Temp: " + data_array[j][2] + "°C\nHumidity: " + data_array[j][1] + "%";
                    test.canvas.SetActive(true);
                    test.value.text = "Temp: " + data_array[j][2];
                    newSensor.GetComponent<Renderer>().material = mat2;
                }
            }
            //test.panel.text = "Temp: " + coords[i][3] + "\nHumidity: " + coords[i][4];
            test.title.text = "Sensor " + coords[i][0];
        }

        // below works
        /*
        coord_1d = file.text.Split(","[0]);
        for (int i = 0; i < 4; i++)
        {
            Debug.Log(coord_1d[i]);
        }
        Instantiate(sensor, new Vector3(int.Parse(coord_1d[0]), int.Parse(coord_1d[1]), 
        int.Parse(coord_1d[2])), transform.localRotation);
        */
        // after instantiation, set data values
        /*
        Instantiate(sensor, transform.localPosition, transform.localRotation);
        for (int i = 0; i < 10; i++)
        {
            Instantiate(sensor, new Vector3(i * 50.0F, 0, 0), transform.localRotation);
        }
        */
    }
        // Update is called once per frame
        void Update()
    {

    }
}
