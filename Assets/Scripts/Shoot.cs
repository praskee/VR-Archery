using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private bool isAttached = false;
    void OnTriggerStay()
    {
        blockArrow();
    }

    void Update()
    {
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) == 0)
        {
            isAttached = false;
        }
    }

    public void blockArrow()
    {
        //Debug.Log(OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger));
        if (!isAttached && OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > .9f)
        {
            ArrowManager.Instance.AttachBowToArrow();
            isAttached = true;
        }
    }
}
