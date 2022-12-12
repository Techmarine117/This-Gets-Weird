using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public int Test;
    public Vector3 PlayerPosition, AIPosition;
    

    //the value we defined in this constructor will be the default values
    public GameData()
    {
        this.Test = 0;
        PlayerPosition = Vector3.zero;
        AIPosition = Vector3.zero;

    }
}
