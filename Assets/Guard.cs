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
        foreach (Transform waypoint in pathHolder) {
            Gizmos.DrawSphere(waypoint.position, .3f);
        }
    }
}
