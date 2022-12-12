using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{

    public DataManager dataManager;

    // Start is called before the first frame update
    void Start()
    {
        dataManager = GameObject.FindObjectOfType<DataManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Players")
        {
            Debug.Log("Triggered");
            dataManager.SaveGame();
            
        }
    }


}
