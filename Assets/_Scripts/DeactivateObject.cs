using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateObject : MonoBehaviour
{
    [SerializeField] GameObject obj;
    void Start()
    {
        obj.SetActive(false);
    }

    
}
