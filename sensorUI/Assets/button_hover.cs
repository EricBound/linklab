using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_hover : MonoBehaviour
{

    public GameObject info_toggle = null;
    public GameObject info_panel = null;

    // Use this for initialization
    void Start() {
        info_toggle.SetActive(false);
    }

    void OnMouseEnter(){
        info_toggle.SetActive(true);
    }

    void OnMouseExit(){
        info_toggle.SetActive(false);
        info_panel.SetActive(false);
    }

    // Update is called once per frame
    void Update(){

    }
}
