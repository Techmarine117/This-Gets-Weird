using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    
    public Vector3 PlayerPosition, AIPosition;
    public bool Mask1,Mask2,Mask3;
    

    //the value we defined in this constructor will be the default values
    public GameData()
    {
        
        PlayerPosition = new Vector3(80,51,9);
        AIPosition = Vector3.zero;
        Mask1 = false;
        Mask2 = false;
        Mask3 = false;

    }
}
