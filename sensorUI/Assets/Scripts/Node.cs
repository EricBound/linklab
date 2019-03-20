using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
    public float waitTimeMax = 0;
    public List<Node> connectedNodes;
    [Tooltip("If it is a transition node, tells the walker try not to go to the previous node if possible")]
    public bool isTransitionNode = false;

    void Start() {
        for (int n = 0; n < connectedNodes.Count; n++) { //deal with all the non-doubly connected nodes
            if (!connectedNodes[n].connectedNodes.Contains(this)) {
                connectedNodes[n].connectedNodes.Add(this);
                //Debug.Log(name + " added itself to " + connectedNodes[n]);
            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        if (waitTimeMax > 0) {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawWireSphere(transform.position, 0.1f);
        if (isTransitionNode) {
            Gizmos.DrawWireSphere(transform.position, 0.2f);
        }


        Gizmos.color = Color.green;        

        for (int n = 0; n < connectedNodes.Count; n++) {
            if (connectedNodes[n] != null) {
                Gizmos.DrawLine(transform.position, connectedNodes[n].transform.position);
            }
        }
    }
}
