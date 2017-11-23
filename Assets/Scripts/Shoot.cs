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

    void OnTriggerEnter()
    {
        blockArrow();
    }

    public void blockArrow()
    {
        if (!isAttached && OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0)
        {
            ArrowManager.Instance.AttachBowToArrow();
            isAttached = true;
        }
    }
}
