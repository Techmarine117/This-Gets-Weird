using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformRotator : MonoBehaviour
{
    //[SerializeField] float turnspeed = 30f;

    public SwitchManager switchScript;

    public float rotationSpeed = 30f;
    public Transform Player;

    private Vector3 playerPosition;

    private void Update()
    {
        //if (switchScript.isSwitchOn == true)
        //{
        //    transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        //}
        //else if (switchScript.isSwitchOn == false)
        //{
        //    transform.Rotate(0, 0, 0);
        //}

        if (switchScript.isSwitchOn == true)
        {
            if (Player != null)
                playerPosition = transform.InverseTransformPoint(Player.position);

            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);

            if (Player != null)
                Player.position = transform.TransformPoint(playerPosition);
        }
        else if (switchScript.isSwitchOn == false)
        {
            transform.Rotate(0, 0, 0);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Player = collision.transform;
    }

    private void OnCollisionExit(Collision collision)
    {
        Player = null;
    }


}


