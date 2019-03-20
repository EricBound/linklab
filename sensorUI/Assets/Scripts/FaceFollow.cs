using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceFollow : MonoBehaviour {
    public Transform leader;
	
	// Update is called once per frame
	void Update () {
		if (leader!= null) {
            transform.position = leader.transform.position;
        }
	}
}
