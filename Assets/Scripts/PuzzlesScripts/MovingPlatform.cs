using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] GameObject platStart;
    [SerializeField] GameObject platEnd;
    public int platSpeed = 1;
    [SerializeField] float timer = 4f;

    public Vector3 startPos;
    public Vector3 endPos;

    public PressurePlate pp;

    private void Start()
    {
        startPos = platStart.transform.position;
        endPos = platEnd.transform.position;
    }

    private void FixedUpdate()
    {
        if (pp.isPlateActive)
        {
            if (transform.position == endPos)
            {
                StartCoroutine(V3Lerp(gameObject, startPos, platSpeed));
            }

            if (transform.position == startPos)
            {
                StartCoroutine(V3Lerp(gameObject, endPos, platSpeed));
            }
        }
        
    }
    public IEnumerator V3Lerp(GameObject obj, Vector3 target, float speed)
    {
        Vector3 startPosition = obj.transform.position;
        float time = 0f;

        while (obj.transform.position != target)
        {
            obj.transform.position = Vector3.Lerp(startPosition, target, (time / Vector3.Distance(startPosition, target))) * speed;
            time += Time.deltaTime;
            yield return null;
        }

    }

}
