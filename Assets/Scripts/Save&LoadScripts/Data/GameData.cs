using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public int Test;

    //the value we defined in this constructor will be the default values
    public GameData()
    {
        this.Test = 0;
    }
}
