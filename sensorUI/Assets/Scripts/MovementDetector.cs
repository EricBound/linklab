using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class MovementDetector : MonoBehaviour {
    [HideInInspector]
    public MovementSquareController msc;
    private int collideCount = 0;
    public int CollideCount {
        set {
            if (value > msc.highestCollideCount) {
                msc.highestCollideCount = value;
                msc.UpdateSquareColors();
            }
            collideCount = value;
        }
        get {
            return collideCount;
        }
    }

    public float timeFrame = 1;
    bool collidedThisTimeFrame = false;
    [HideInInspector]
    public SpriteRenderer sr;
    Color destinationColor;

	// Use this for initialization
	void Start () {
        InvokeRepeating("ClearCollisionBlock", 0, 1);
        sr = GetComponent<SpriteRenderer>();
        destinationColor = sr.color;
    }

    //private void Update() {
    //    sr.color = Color.Lerp(sr.color, destinationColor, Time.time);
    //}
    
    void ClearCollisionBlock() {
        collidedThisTimeFrame = false;
    }

    public void updateColor() {
        sr.color = msc.getColorByCount(collideCount);
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.name == "Arsalan") {
            if (!collidedThisTimeFrame) {
                CollideCount += 1;
                collidedThisTimeFrame = true;
                //destinationColor = new Color32(255, 0, 0, (byte)(collideCount*50 % 256));
                sr.color = msc.getColorByCount(collideCount);
                //Debug.Log("Object trigger entered: " + collideCount);
            }
        }
    }


    //private void OnTriggerEnter2D(Collider2D collision) {
    //    Debug.Log("collision with " + collision.gameObject);
    //    if (collision.name=="Arsalan") {
    //        collideCount += 1;
    //        collidedThisTimeFrame = true;
    //        destinationColor = new Color32(255, 0, 0, (byte) (collideCount*50 % 256));
    //        Debug.Log("Object trigger entered!");
    //    }
    //}
}
