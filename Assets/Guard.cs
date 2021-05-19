using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour {

    IEnumerator currentMoveCoroutine;
    int i = 0;
    float speed = 6;
    
    public Transform pathHolder;
    void Start() {
        Vector3[] waypoints = new Vector3[pathHolder.childCount];
        for (int i = 0; i < waypoints.Length; i++) {
            waypoints[i] = pathHolder.GetChild(i).position;
        }
    }
    
    void Update() {
        // for (int i = 0; i < pathHolder.childCount; i++) {
            if (Input.GetKeyDown (KeyCode.Space)) {
                if (currentMoveCoroutine != null) {
                    StopCoroutine(currentMoveCoroutine);
                }
                currentMoveCoroutine = MoveGuard (pathHolder.GetChild(i).position);
                StartCoroutine (currentMoveCoroutine);
                i ++;
                i = i % pathHolder.childCount;
            }
        // }
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

    IEnumerator MoveGuard (Vector3 destination) {
        
        while (transform.position != destination) {

            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            yield return null;
        }
    }
}
