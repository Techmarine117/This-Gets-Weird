using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject DoorCollider;
    [SerializeField]
    bool IsTimer, IsKey;
    [SerializeField]
    private float Timer, TimeLimit;
    public bool isUnlocked, TimeStarted;

    // Update is called once per frame
    void Update()
    {
        if (IsTimer)
        {
            if (TimeStarted)
            {
                
                DoorCollider.SetActive(false);
                Timer += Time.deltaTime;
                if (Timer >= TimeLimit)
                {
                    TimeStarted = false;
                    DoorCollider.SetActive(true);
                    
                }
                return;
            }
            Timer = 0;
        }

        if (IsKey)
        {
            if (isUnlocked)
            {
                
                DoorCollider.SetActive(false);
            }
        }
    }

    public void OpenDoorTimer()
    {
        TimeStarted = true;
        Timer = 0;
    }
    public void OpenDoorKey()
    {
        isUnlocked = true;
    }
}
