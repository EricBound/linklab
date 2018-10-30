using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMouse : MonoBehaviour {

    Vector2 mouseLook; // keeps track of mouse movement
    Vector2 smoothV; // smooth movement of mouse, not necessary
    public float sensitivity = 5.0F; 
    public float smoothing = 2.0F;

    GameObject character;

	// Use this for initialization
	void Start () {
        character = this.transform.parent.gameObject; // character set to parent of camera
	}
	
	// Update is called once per frame
	void Update () {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")); // mouse delta

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1F / smoothing); // linear interpretation of movement
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1F / smoothing);
        mouseLook += smoothV;

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right); // mouseLook.y about x axis
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up); // mouseLook.x about character's up axis, move entire character
    }
}
