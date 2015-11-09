using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class Waypoints : MonoBehaviour {

    public Vector3[] localWaypoints;
    public Vector3[] globalWaypoints;

    void Start()
    {
        globalWaypoints = new Vector3[localWaypoints.Length];
        for(int i=0; i < localWaypoints.Length; i++)
        {
            globalWaypoints[i] = localWaypoints[i] + transform.position;
        }
    }

    void OnDrawGizmos()
    {
        if(localWaypoints != null)
        {
            Gizmos.color = Color.blue;
            float size = .4f;

            for(int i = 0; i < localWaypoints.Length; i++)
            {
                Vector3 globalWaypointPos = (Application.isPlaying)? globalWaypoints[i]: localWaypoints[i] + transform.position;
                Gizmos.DrawLine(globalWaypointPos - Vector3.up * size, globalWaypointPos + Vector3.up * size);
                Gizmos.DrawLine(globalWaypointPos - Vector3.left * size, globalWaypointPos + Vector3.left * size);
            }
        }
    }

}
