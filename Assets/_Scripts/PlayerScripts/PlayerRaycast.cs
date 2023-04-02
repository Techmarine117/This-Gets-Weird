using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class PlayerRaycast : MonoBehaviour
{
    public GameObject cam;
    public GameObject popUp;
    public GameObject pickUpobj;
    public float Raylength;
    public bool isPickup;
    public Transform pickupPlacholder;
    //public AlphaChange alphaChange;
    public RaycastHit hit;
    public float SphereRadius;
    public float SphereOffset;
    public LayerMask raycastMask;
    //public PrototypeMovement pm;
    [SerializeField] Selector selector;


    private void Start()
    {
        //var selectorComponent = Selector;
        //selectorComponent = GameObject.Find("FirstPersonController").GetComponent<Selector>();
    }
    //public Switch switchh;
    void Update()
    {
        // to stop any further action that has to do with raycasting while an object is picked up
        if (isPickup == true && pickUpobj)
        {
            //pm.canSprint = false;
            //pickUpobj.transform.rotation = transform.rotation;
            //pickUpobj.transform.position = pickupPlacholder.position;
            pickUpobj.transform.parent = pickupPlacholder.transform;
            pickUpobj.transform.rotation = pickupPlacholder.rotation;
            pickUpobj.transform.localPosition = Vector3.zero;

            if (Input.GetKeyDown(KeyCode.E))
            {
                pickUpobj.AddComponent<Rigidbody>();
                isPickup = false;
                pickUpobj.transform.parent = null;
                selector.enabled = true;
                //pm.canSprint = true;

            }
            return;
        }

        

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Raylength,raycastMask))
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
                    
                    Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
                    Destroy(rb);

                    Debug.Log("it worked");
                }
            }
           
        }

    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        //Gizmos.DrawSphere(transform.position + (transform.forward * SphereOffset), SphereRadius);
    }
}
