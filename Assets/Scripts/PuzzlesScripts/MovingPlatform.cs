using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    
    [SerializeField] GameObject[] waypoints;

    int currentIndex;

    [SerializeField] float platSpeed = 1f;

    public PressurePlate pp;

    private void Update()
    {
        if (pp.isPlateActive)
        {
            if (Vector3.Distance(transform.position, waypoints[currentIndex].transform.position) < 0.5f)
            {
                currentIndex++;
                if (currentIndex >= waypoints.Length)
                {
                    currentIndex = 0;
                }
            }

            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentIndex].transform.position, platSpeed * Time.deltaTime);
        }
        
    }
}
