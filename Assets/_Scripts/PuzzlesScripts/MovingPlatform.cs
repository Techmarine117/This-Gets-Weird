using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    
    [SerializeField] GameObject[] waypoints;
    [SerializeField] Transform Player = null;

    int currentIndex;

    [SerializeField] float platSpeed = 1f;

    public PressurePlate pp;

    Vector3 playerPosition;
    float tempJumpStremgth;
    bool onPlatform = false;
    public Jump jump;

    private void Start()
    {
        tempJumpStremgth = jump.jumpStrength;
    }
    private void FixedUpdate()
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

            if (Player != null && onPlatform == true)
                playerPosition = transform.InverseTransformPoint(Player.position);

            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentIndex].transform.position, platSpeed * Time.deltaTime);

            if (Player != null && onPlatform == true)
                Player.position = transform.TransformPoint(playerPosition);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        onPlatform = true;
        Player = collision.transform;
        jump.jumpStrength = jump.jumpStrength * 1.33f;
    }

    private void OnCollisionExit(Collision collision)
    {
        onPlatform = false;
        Player = null;
        jump.jumpStrength = tempJumpStremgth;
    }
}
