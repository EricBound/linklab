using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class display_data : MonoBehaviour
{
    Text data;
    //string[] coord_1d;
    int temp;
    public int id = 0;

    // Start is called before the first frame update
    void Start()
    {
        data = GetComponent<Text>();
        //data.text = "Hello world";
        //Debug.Log(instantiate.count);
        Debug.Log(id);
        data.text = "Temp: " + instantiate.coords[instantiate.count][3] + "\nHumidity: " + 
        instantiate.coords[instantiate.count][4];
    }

    // Update is called once per frame
    void Update()
    {
        //update with random
        //temp = Random.Range(0, 100);
        //data.text = "Temperature: " + temp.ToString() + "\nHumidity: " + temp.ToString() + "\nLux: " + temp.ToString();

    }
}
