using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSquareController : MonoBehaviour {
    public GameObject movementSquare;
    public int highestCollideCount = 0;
    public int mapWidth = 40;
    public int mapHeight = 20;
    List<MovementDetector> spawnedMds;

	// Use this for initialization
	void Start () {
		if (movementSquare== null) {
            Debug.LogError("Movement square is null");
        }
        spawnedMds = new List<MovementDetector>();
        GenerateSquares();
    }
	
    void GenerateSquares() {
        for (int y = 0; y < mapHeight; y++) {
            for (int x = 0; x < mapWidth; x++) {
                GameObject spawnedMovementSquare = Instantiate(movementSquare, transform, true);
                spawnedMovementSquare.transform.position = transform.position;
                MovementDetector mdSpawned = spawnedMovementSquare.GetComponent<MovementDetector>();
                mdSpawned.msc = this;
                float squareWidth = movementSquare.GetComponent<Collider2D>().bounds.extents.x*2;
                float squareHeight = movementSquare.GetComponent<Collider2D>().bounds.extents.y*2;
                spawnedMovementSquare.transform.position += new Vector3(squareWidth * x, squareHeight*y);
                spawnedMds.Add(mdSpawned);
                //InventoryItemButton iibCreated = Instantiate(itemButtonGoRef, inventoryScreen.transform, true).GetComponent<InventoryItemButton>();
                //itemButtonIIBs.Add(iibCreated);
                //Vector3 position = itemButtonIIBs[itemButtonIIBs.Count - 1].transform.position;
                ////Debug.Log("Position normal: " + position);
                //position += new Vector3(Constants.xItemOffset * x, -Constants.yItemOFfset * y, 0);
                ////Debug.Log("Added position: " + position);
                //iibCreated.transform.position = position;
                ////iibCreated.transform.parent = inventoryScreen.transform;
            }
        }
    }

    public void UpdateSquareColors() {
        for (int n = 0; n < spawnedMds.Count; n++) {
            spawnedMds[n].updateColor();
        }
    }

    public Color getColorByCount(int collideCount) {
        //Debug.Log("alpha number: " + (collideCount / (float) highestCollideCount) * 256);
        return new Color32(255, 0, 0, (byte)((collideCount / (float) highestCollideCount)*150));
    }

	// Update is called once per frame
	void Update () {
		
	}
}
