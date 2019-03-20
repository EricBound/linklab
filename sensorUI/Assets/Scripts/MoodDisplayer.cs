using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoodDisplayer : MonoBehaviour {
    public SpriteRenderer moodSr;
    public Animator animCont;
    public List<Sprite> moods;

	// Use this for initialization
	void Start () {
		if (moodSr== null || animCont == null) {
            Debug.LogError("Mood displayer startup error");
        }
	}

    public void displayRandomMood() {
        displayMood(moods[Random.Range(0, moods.Count)].name);
    }
	
    public void displayMood(string moodStr) {
        for (int n = 0; n < moods.Count; n++) {
            if (moods[n].name== moodStr) {
                moodSr.sprite = moods[n];
                break;
            }
        }

        animCont.SetTrigger("DisplayMood");
    }
}
