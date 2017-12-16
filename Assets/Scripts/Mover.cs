using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mover : MonoBehaviour
{
    public Rail rail;
    public GameObject car;
    public float speed = 10f;

    private int currentSeg;
    private float transition;
    private bool isCompleted;

    private void Update()
    {
        if (!rail)
            return;
        if (!isCompleted)
        {
            Play();
            car.transform.position = new Vector3 (transform.position.x, transform.position.y - 3.5f, transform.position.z);
            car.transform.rotation = transform.rotation;
        }

    }

    private void Play()
    {
        float m = (rail.nodes[currentSeg + 1].position - rail.nodes[currentSeg].position).magnitude;
        float s = (Time.deltaTime * 1 / m) * speed;
        transition += s;
        if (transition > 1)
        {
            transition = 0;
            currentSeg++;
            if (currentSeg == rail.nodes.Length - 1)
            {
                isCompleted = true;
                return;
            }
        }
        else if (transition < 0)
        {
            transition = 1;
            currentSeg--;
        }
        transform.position = rail.LinearPosition(currentSeg, transition);
        transform.rotation = rail.Orientation(currentSeg, transition);
    }
}
