using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementModel : MonoBehaviour {
    public MoodDisplayer mdis;
    Vector3 currentTarget;
    bool isRightHanded = true;
    int stuckCheck;

    public float movementSpeed = 5;
    public float toleranceDistance = 0.1f;
    [Tooltip("For much wider does the character look for collisions")]
    public float characterCheckRadiusRatio = 5;
    //public List<Transform> movementNodes;
    public Node previousNode;
    public Node currentNode;

    public Text footstepsText;
    float footsteps;

    public Text heartrateText;
    int heartRate = 60;
    public int HeartRate {
        set {
            heartRate = Mathf.Clamp(value, Random.Range(60,70), Random.Range(90,110));
        }
        get {
            return heartRate;
        }
    }

    Rigidbody2D rb;

    /*
	 * Randomly choose between a few places to move:
	 * 	Own office, Nicola's Office, Brad's Office, Alan's Desk, Arash's Desk, Salwa's Desk, Bathroom Leave and Office leave, to move
	 * 	Each location has a wait associated, then the guy moves to the next step based on random rolls
	 */

    // Use this for initialization
    [HideInInspector]
    public float timeUntilNextMove;
    

	void Start () {
        if (currentNode== null){
            Debug.LogError("Movement model does not have a starting node");
        }
        currentTarget = currentNode.transform.position;

        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("DisplayMood", 0, 3);
        InvokeRepeating("UpdateHeartrate", 0, 1);
        heartRate = Random.Range(60, 80);
    }

    void DisplayMood() {
        mdis.displayRandomMood();
    }

    void UpdateHeartrate() {
        HeartRate += Random.Range(-10, 7);
        heartrateText.text = "Heart rate: " + HeartRate + " bpm";
    }

	// Update is called once per frame
	void Update () {
        DefaultRandomMovement();
    }

    void DefaultRandomMovement() {
        if (currentTarget != null && Time.time > timeUntilNextMove) {
            if (Vector2.Distance(transform.position, currentTarget) > toleranceDistance) {
                Debug.DrawLine(transform.position, currentTarget, Color.gray);
                Vector3 localPosition = currentTarget - transform.position;
                RotateTowardsPosition(currentTarget); //Rotating towards the target is what makes the get next movable location thing work, so do it!
                localPosition = localPosition.normalized; // The normalized direction in LOCAL space
                localPosition = getNextMovableLocation().normalized; //CHECKING HERE
                transform.position += localPosition * Time.deltaTime * movementSpeed;
                //rb.velocity += new Vector2(localPosition.x, localPosition.y) * Time.deltaTime * movementSpeed;  //funny!
                footsteps += 0.1f;
                footstepsText.text = "Footsteps: " + Mathf.RoundToInt(footsteps);
                HeartRate += Random.Range(-1, 3);
            } else {
                timeUntilNextMove = Time.time + Random.Range(0, currentNode.waitTimeMax);
                if (currentNode.isTransitionNode) {
                    currentTarget= chooseOtherLocationThan();
                } else {
                    currentTarget = chooseOtherLocation(); //Maybe only get easy corresponding nodes that Ars can arrive using simple move?
                                                           //Make a node class that you can connect other node classes to
                }
            }
        }
    }

    public Vector2 chooseOtherLocationThan() {
        List<Node> copiedConnectionList = new List<Node>(currentNode.connectedNodes); //clone the list
        Node badNode = previousNode;
        previousNode = currentNode;
        if (copiedConnectionList.Contains(badNode) && copiedConnectionList.Count > 1) {
            copiedConnectionList.Remove(badNode);
            currentNode = copiedConnectionList[Random.Range(0, copiedConnectionList.Count)];
        } else {
            currentNode = currentNode.connectedNodes[Random.Range(0, currentNode.connectedNodes.Count)];
        }
        return currentNode.transform.position;
    }

    public Vector2 chooseOtherLocation() {
        //return movementNodes[Random.Range(0, movementNodes.Count)].position;
        previousNode = currentNode;
        currentNode = currentNode.connectedNodes[Random.Range(0, currentNode.connectedNodes.Count)];
        return currentNode.transform.position;
    }

    public void move(Vector2 loc) {
        currentTarget = loc;
    }
		
	public bool canMoveForward(Vector2 dir) {
		bool answer = true;
		//RaycastHit2D hit = new RaycastHit2D();
		//Ray2D ray2D = new Ray2D(transform.position, transform.up);
		int checkedLayers = LayerMask.GetMask("Stage");
		float characterRadius = GetComponent<CircleCollider2D>().radius * characterCheckRadiusRatio;

		RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, characterRadius, checkedLayers); //use twice the radius instead of movement speed

		if (hit.collider!=null){
			answer = false;
		}

		if (answer) { //if can move
			if (hit.collider == null) {
				Debug.DrawRay(transform.position, dir * characterRadius, Color.cyan);
			}else {
				Debug.DrawRay(transform.position, dir * characterRadius, Color.green);
			}
		}else { //if can't move
			Debug.DrawRay(transform.position, dir * characterRadius, Color.red);
		}

		return answer;
	}

	public Vector2[] getCheckDirs(bool rightHanded) {
		List<Vector2> checkOrder = new List<Vector2>();

		for (int n = 0; n < 4; n++) {
			if (rightHanded) {
				checkOrder.Add(Quaternion.Euler(0, 0, -90 + 45 * n) * transform.up);
			}else {
				checkOrder.Add(Quaternion.Euler(0, 0, 90 - 45 * n) * transform.up);
			}
		}

		return checkOrder.ToArray();
	}

	public void RotateTowardsPosition(Vector3 targetPosition) {
		//https://answers.unity.com/questions/585035/lookat-2d-equivalent-.html
		Vector3 diff = targetPosition - transform.position;
		diff.Normalize();

		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90); //original
	}


    public Vector2 getNextMovableLocation() {
        /*
         * Assume there is really only 8 directions to move, and the character is doing simple move, so 
         * Check the 5 directions closest towards the player, move in that direction this turn instead
         * Instead of trying something complicated to limit the search times, instead make on complex "head" that the neighboring characters might later follow?
         * 
         */

        Vector2 firstCheckVec = transform.up;
        Vector2 answerDir = firstCheckVec;
        Vector2[] checkDirs = getCheckDirs(isRightHanded);

        if (canMoveForward(firstCheckVec)) { //well if you can move towards your target, then don't care
                                             //Debug.Log("Can forward");
            answerDir = firstCheckVec;
        } else {
            for (int n = 0; n < checkDirs.Length; n++) {
                if (canMoveForward(checkDirs[n])) {
                    //Debug.Log("Can move: " + checkDirs[n]);
                    answerDir = checkDirs[n];
                    break;
                }
                if (n > 1) {
                    stuckCheck += 1;
                }
            }
        }

        //Debug.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y) + (answerDir * soul.movementSpeed * 2), Color.green);
        //Debug.Log("Stuck check: " + stuckCheck);

        if (stuckCheck > 20) {
            Debug.Log("Flipped");
            isRightHanded = !isRightHanded; //flip hands
            stuckCheck = 0;
        }

        return answerDir;
    }
    private void OnDrawGizmos() {
		//if (chaseTarget == null) {
		//	Gizmos.color = Color.white;
		//} else {
		//	Gizmos.color = Color.green;
		//}
		//Gizmos.DrawWireSphere(transform.position, searchRadius);
		//Gizmos.color = Color.gray;
		//Gizmos.DrawWireSphere(transform.position, giveUpChaseRadius);
	}
}



