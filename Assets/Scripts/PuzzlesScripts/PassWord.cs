using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PassWord : MonoBehaviour
{
    public string PassCode;
    public GameObject TargetObj;
    public GameObject TargetObj2;
    public TMP_InputField Answer;
    

    public void Update()
    {
        if(Answer.text == PassCode)
        {
            Debug.Log("it works");
            TargetObj2.SetActive(true);
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            
            TargetObj.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            Time.timeScale = 0f;



        }
        if (Input.GetKey(KeyCode.Q))
        {
            Close();
            
        }

    }

    public void Close()
    {
        TargetObj.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;

    }

    

   
}