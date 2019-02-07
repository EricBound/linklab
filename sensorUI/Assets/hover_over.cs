using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hover_over : MonoBehaviour
{

    public GameObject OpenPanel = null;

    // Use this for initialization
    void Start() {
        OpenPanel.SetActive(false);
    }

    void OnMouseEnter(){
        OpenPanel.SetActive(true);
    }

    void OnMouseExit(){
        OpenPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update(){

    }
}
