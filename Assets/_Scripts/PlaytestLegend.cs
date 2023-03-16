using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaytestLegend : MonoBehaviour
{
    [SerializeField] Transform p1;
    [SerializeField] Transform p2;
    [SerializeField] Transform p3;
    [SerializeField] Transform intro;
    [SerializeField] Transform cube;
    [SerializeField] Transform player;
    [SerializeField] GameObject placeholder;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            player.transform.position = p1.transform.position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            player.transform.position = p2.transform.position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            player.transform.position = p3.transform.position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            player.transform.position = intro.transform.position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Instantiate(cube, placeholder.transform.position, transform.rotation);
        }
    }
}
