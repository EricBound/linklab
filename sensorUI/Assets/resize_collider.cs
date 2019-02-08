using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resize_collider : MonoBehaviour
{
    BoxCollider re_collider;
    // Start is called before the first frame update
    void Start()
    {
        // Fetch Collider from GameObject
        re_collider = GetComponent<BoxCollider>();
    }
    /*
    private void OnCollisionEnter(BoxCollider re_collider)
    {
        re_collider.size = new Vector3(10, 10, 10);
    }
    */
    void OnMouseOver()
    {
        re_collider.size = new Vector3(10, 10, 10);
    }

    void OnMouseExit()
    {
        re_collider.size = new Vector3(5, 5, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
