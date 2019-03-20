using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public Animator animator;

    public GameObject OpenPanel = null;

    private bool _isInsideTrigger = false;

    // Use this for initialization
    void Start()
    {
        //animator = transform.Find("slide").GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        _isInsideTrigger = true;
        OpenPanel.SetActive(true);
        /*
        if (other.tag == "Player")
        {
            _isInsideTrigger = true;
            OpenPanel.SetActive(true);
        }
        */
    }

    void OnTriggerExit(Collider other)
    {
        _isInsideTrigger = false;
        OpenPanel.SetActive(false);
        //animator.SetBool("open", false);
        /*
        if (other.tag == "Player")
        {
            _isInsideTrigger = false;
            //_animator.SetBool("open", false);
            OpenPanel.SetActive(false);
        }
        */
    }

    private bool IsOpenPanelActive
    {
        get
        {
            return OpenPanel.activeInHierarchy;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (IsOpenPanelActive && _isInsideTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (animator.GetBool("open") == false)
                {
                    OpenPanel.SetActive(false);
                    animator.SetBool("open", true);
                }
                else
                {
                    animator.SetBool("open", false);
                }
            }
        }
    }
}
