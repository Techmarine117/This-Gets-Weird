using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Prompt : MonoBehaviour
{
    public TextMeshProUGUI prompt;
    

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<TextMeshProUGUI>().enabled = true;
        
    }

    private void OnTriggerExit(Collider other)
    {
        FindObjectOfType<TextMeshProUGUI>().enabled = false;
    }

}
