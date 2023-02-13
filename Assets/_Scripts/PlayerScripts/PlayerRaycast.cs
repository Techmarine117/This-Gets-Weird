using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    public GameObject cam;
    public GameObject popUp;
    private GameObject pickUpobj;
    public float Raylength;
    public bool isPickup;
    public Transform pickupPlacholder;
    public AlphaChange alphaChange;
    public RaycastHit hit;
    //public PrototypeMovement pm;



    //public Switch switchh;
    void Update()
    {
        // to stop any further action that has to do with raycasting while an object is picked up
        if (isPickup == true && pickUpobj)
        {
            //pm.canSprint = false;         
            pickUpobj.transform.rotation = transform.rotation;
            pickUpobj.transform.position = pickupPlacholder.position;
            if (Input.GetKeyDown(KeyCode.E))
            {
                //pickUpobj.AddComponent<Rigidbody>();
                isPickup = false;
                pickUpobj = null;
                //pm.canSprint = true;



            }
            return;
        }

        

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Raylength))
        {
            if (hit.collider.tag == "interactible")
            {
                //do action
               // hit.collider.GetComponent<interactibleObj>().Action();
                popUp.SetActive(true);
                Debug.Log("hit");



            }


            if (hit.collider.tag == "pickUp")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    isPickup = true;
                    pickUpobj = hit.collider.gameObject;

                    //Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
                    //Destroy(rb);



                    Debug.Log("it worked");
                }
            }
           
        }

    }
}
