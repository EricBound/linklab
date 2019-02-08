using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class display_data : MonoBehaviour
{
    Text data;
    int temp;

    // Start is called before the first frame update
    void Start()
    {
        data = GetComponent<Text>();
        data.text = "Hello world";
    }

    // Update is called once per frame
    void Update()
    {
        temp = Random.Range(0, 100);
        data.text = "Temperature: " + temp.ToString() + "\nHumidity: " + temp.ToString() + "\nLux: " + temp.ToString();

    }
}
