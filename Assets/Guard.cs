using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour {
    
    public Transform pathHolder;
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    void OnDrawGizmos() {
        Vector3 startingPosition = pathHolder.GetChild(0).position;
        Vector3 previousPosition = startingPosition;
        foreach (Transform waypoint in pathHolder) {
            Gizmos.DrawSphere(waypoint.position, .3f);
            Gizmos.DrawLine (previousPosition, waypoint.position);
            previousPosition = waypoint.position;
        }
        Gizmos.DrawLine(previousPosition, startingPosition);
    }
}
