using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaChange : MonoBehaviour
{
    public Renderer TargetObj;
    public PlayerRaycast playerRaycast;

    private void Start()
    {
        //playerRaycast= GetComponent<PlayerRaycast>();
    }

    private void Update()
    {
        if(playerRaycast.isPickup == true)
        {
            SetTransparent();
        }
        else if(playerRaycast.isPickup == false)
        {
            ResetAlpha();
        }
        
    }


     public void SetTransparent()
     {
        
         Color color =  TargetObj.material.color;
         color.a = 0.5f;
         TargetObj.material.color = color;
     }

    public void ResetAlpha()
    {

        Color color = TargetObj.material.color;
        color.a = 1f;
        TargetObj.material.color = color;
    }



}