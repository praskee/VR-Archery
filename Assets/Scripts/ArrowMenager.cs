using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMenager : MonoBehaviour {


    public OVRInput.Controller controller;
    public GameObject controler;


    private GameObject currentArrow;
    public GameObject arrowPrefab;
    public TextMesh debug;
    public GameObject LastArrrow;

    private bool hasArrow = false;


    // Use this for initialization
    void Start () {
	
      
	}
	
	// Update is called once per frame
	void Update () {

        

        debug.text = controler.transform.rotation.x.ToString()+
            "\n"+ controler.transform.rotation.y.ToString() +
             "\n" + controler.transform.rotation.z.ToString();
    
        if (!hasArrow)
        {
            //TODO ten warunek bo nei zawsze działa. rozwiązac to cwanie
            if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0)
                AttachArrow();


            // if ((controler.transform.localRotation.z < -0.8 || controler.transform.localRotation.z > 0.8) &&(controler.transform.localRotation.x < -0.8|| controler.transform.localRotation.x > 0.8))
            // if (controler.transform.localRotation.y < -0.2 || controler.transform.localRotation.y > 0.2)




        }
        else
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0)
        {
           
        }
        else throwArrow();
        
     

    }

 public void throwArrow()
    {
        LastArrrow = currentArrow;
        currentArrow = null;
       
        LastArrrow.transform.parent = null;
      
        LastArrrow.GetComponent<Rigidbody>().isKinematic = false;

        LastArrrow.GetComponent<Rigidbody>().angularVelocity = OVRInput.GetLocalControllerAngularVelocity(controller);
        LastArrrow.GetComponent<Rigidbody>().velocity = OVRInput.GetLocalControllerVelocity(controller);

        hasArrow = false;

    }
    //TODO
    public void playSound()
    {
      
    }


    public void AttachArrow()
    {
        if (currentArrow==null)
            { 
                currentArrow = Instantiate(arrowPrefab, controler.transform); 
                currentArrow.transform.localPosition = new Vector3 (0.1f, 0f,0.3f);
                currentArrow.GetComponent<Rigidbody>().isKinematic = true;
                hasArrow = true;
       
            
            //sound.Play();
        }
    }


}
