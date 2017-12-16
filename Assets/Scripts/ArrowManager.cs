using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : MonoBehaviour
{
    private GameObject currentArrow;
    public static ArrowManager Instance;
    public OVRInput.Controller controller;
    public GameObject controler;
    public GameObject arrowPrefab;
    public GameObject LastArrow;
    public GameObject arrowStartPoint;
    public TextMesh debug;
    private bool hasArrow = false;
    private bool isAttached = false;
    private float bowPositionZ;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }

    void Update()
    {
        debug.text = controler.transform.rotation.x.ToString() +
                     "\n" + controler.transform.rotation.y.ToString() +
                     "\n" + controler.transform.rotation.z.ToString();
        if (!hasArrow)
        {
            AttachArrow();
        }
        else if (isAttached)
        {
            float dist = (arrowStartPoint.transform.position - controler.transform.position).magnitude;
            if (dist < .6f)
            {
                currentArrow.transform.localPosition = new Vector3(
                   currentArrow.transform.localPosition.x,
                   currentArrow.transform.localPosition.y,
                   bowPositionZ - dist
               );
            }
            Fire(dist);
        }
    }

    public void AttachArrow()
    {
        if (currentArrow == null)
        {
            currentArrow = Instantiate(arrowPrefab, controler.transform);
            currentArrow.transform.localPosition = new Vector3(0.1f, 0f, 0.33f);
            currentArrow.GetComponent<Rigidbody>().isKinematic = true;
            hasArrow = true;
            bowPositionZ = currentArrow.transform.localPosition.z;
        }
    }

    private void Fire(float dist)
    {
        if (isAttached && OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) < .9f)
        {
            Debug.Log("fiore2");
            //float dist = (arrowStartPoint.transform.position - controler.transform.position).magnitude;
            LastArrow = currentArrow;
            LastArrow.transform.parent = null;
            Rigidbody r = LastArrow.GetComponent<Rigidbody>();
            r.velocity = -LastArrow.transform.up * 25f * dist;
            r.useGravity = true;
            r.isKinematic = false;
            currentArrow = null;
            hasArrow = false;
            isAttached = false;
        }
    }

    public void ThrowArrow()
    {
        if (currentArrow != null)
        {
            LastArrow = currentArrow;
            currentArrow = null;
            LastArrow.transform.parent = null;
            LastArrow.GetComponent<Rigidbody>().isKinematic = false;
            LastArrow.GetComponent<Rigidbody>().angularVelocity = OVRInput.GetLocalControllerAngularVelocity(controller);
            LastArrow.GetComponent<Rigidbody>().velocity = OVRInput.GetLocalControllerVelocity(controller);
            hasArrow = false;
            isAttached = false;
        }
    }

    public void AttachBowToArrow()
    {
        currentArrow.transform.parent = arrowStartPoint.transform;
        currentArrow.transform.position = arrowStartPoint.transform.position;
        currentArrow.transform.rotation = arrowStartPoint.transform.rotation;
        currentArrow.transform.localRotation *= Quaternion.Euler(-90, 1, 1);
        currentArrow.transform.localPosition = new Vector3(
            currentArrow.transform.localPosition.x + 0.065f,
            currentArrow.transform.localPosition.y,
            currentArrow.transform.localPosition.z
        );
        isAttached = true;
    }

    public void playSound()
    {

    }
}