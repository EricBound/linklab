using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class instantiate : MonoBehaviour
{
    public GameObject sensor;
    public TextAsset file;
    //public string[][] coords;
    public static string[] coord_1d;
    public static int count = -1;
    public static string[][] coords;
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
        for (int i = 0; i < lines.Length; i++)
        {
        // Debug.Log(lines[i]);
        string[] stringsLine = lines[i].Split(","[0]);    
        coords[i] = stringsLine;
        }
        for (int i = 0; i < coords.Length; i++)
        {
            var newSensor = Instantiate(sensor, new Vector3(int.Parse(coords[i][0]), int.Parse(coords[i][1]), int.Parse(coords[i][2])), transform.localRotation);
            var test = newSensor.GetComponent<assign_data>();
            test.panel.text = "Temp: " + coords[i][3] + "\nHumidity: " + coords[i][4];
            test.title.text = "Sensor " + (i + 1);
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
