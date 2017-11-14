using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class schoot : MonoBehaviour {



    void OnTriggerEnter(Collider other)
    {        
       Debug.Log(other.gameObject.name);
        blockArrow(other.gameObject);
    }

    //TODO
    public void blockArrow(GameObject obj)
    {
       
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
