using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rail : MonoBehaviour {
    public Transform[] nodes;

    private void Start()
    {
        nodes = GetComponentsInChildren<Transform>();
    }
   
    public Vector3 LinearPosition(int seg, float ratio)
    {
        Vector3 p1 = nodes[seg].position;
        Vector3 p2 = nodes[seg + 1].position;
        return Vector3.Lerp(p1, p2, ratio);
    }

    public Quaternion Orientation(int seg, float ratio)
    {
        Quaternion q1 = nodes[seg].rotation;
        Quaternion q2 = nodes[seg + 1].rotation;
        return Quaternion.Lerp(q1, q2, ratio);
    }
    
}
