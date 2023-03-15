using UnityEngine;

public class AIRayCast : MonoBehaviour
{
    public float ViewRadius;
    [Range(0, 360)] public float ViewAngle;
    public bool PlayerHit;
    public LayerMask ObstacleMask;
    public GameObject PlayerReference;

    private void Start()
    {
        PlayerReference = GameObject.FindGameObjectWithTag("FPSPlayer");
    }

    private void Update()
    {
        FindVisibleTargets();
    }

    public void FindVisibleTargets()
    {
        PlayerHit = false;
        var playerIOnRange = IsPlayerInRange();
        var dir = IsPlayerInFOV(out var playerInFOV);
        var hasLineOfSight = IsThereAnObjectBetweenPlayerAndMe(dir);
        if (playerIOnRange && playerInFOV && hasLineOfSight)
        {
            PlayerHit = true;
        }
    }

    private bool IsThereAnObjectBetweenPlayerAndMe(Vector3 dir)
    {
        bool hasLineOfSight = !Physics.Raycast(transform.position, dir, ViewRadius, ObstacleMask);
        return hasLineOfSight;
    }

    private Vector3 IsPlayerInFOV(out bool playerInFOV)
    {
        Vector3 dir = (PlayerReference.transform.position - transform.position).normalized;
        playerInFOV = Vector3.Angle(transform.forward, dir) < ViewAngle / 2;
        return dir;
    }

    private bool IsPlayerInRange()
    {
        float distance = Vector3.Distance(transform.position, PlayerReference.transform.position);
        bool playerIOnRange = distance < ViewRadius;
        return playerIOnRange;
    }
}