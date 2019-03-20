using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ShowOnEnter : MonoBehaviour {
    public List<GameObject> go;
	// Use this for initialization
	void Start () {
        activate(false);
    }
	
    public void activate(bool b) {
        for (int n = 0; n < go.Count; n++) {
            go[n].SetActive(b);
        }
    }

	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name == "Arsalan") {
            activate(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.name == "Arsalan") {
            activate(false);
        }
    }
}
