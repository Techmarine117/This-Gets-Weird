using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshToggle : MonoBehaviour
{
    public bool isMeshActive = true;
    void Update()
    {
        if (!isMeshActive)
        {
            Renderer[] rs = GetComponentsInChildren<Renderer>();
            foreach (Renderer r in rs)
                r.enabled = false;
        }
        
    }
}
