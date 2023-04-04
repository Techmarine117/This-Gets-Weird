using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DelayTimer());
    }
    public IEnumerator DelayTimer()
    {
        yield return new WaitForSeconds(4f);
    }
}
