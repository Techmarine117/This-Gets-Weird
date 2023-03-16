using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformRotator : MonoBehaviour
{
    [SerializeField] float turnspeed = 30f;

    public SwitchManager switchScript;

    public float rotationSpeed = 30f;
    public Transform Player = null;

    private Vector3 playerPosition;

    bool onPlatform = false;

    public FirstPersonAudio firstPersonAudio2;

    private void Update()
    {
        if (switchScript.isSwitchOn == true)
        {
            if (Player != null && onPlatform == true)
                playerPosition = transform.InverseTransformPoint(Player.position);

            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);

            if (Player != null && onPlatform == true)
                Player.position = transform.TransformPoint(playerPosition);
        }
        else if (switchScript.isSwitchOn == false)
        {
            transform.Rotate(0, 0, 0);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        onPlatform = true;
        firstPersonAudio2.velocityThreshold = 20f;
        Player = collision.transform;
    }

    private void OnCollisionExit(Collision collision)
    {
        onPlatform = false;
        firstPersonAudio2.velocityThreshold = 0.01f;
        Player = null;
    }

}


