using UnityEngine;
using System.Collections;

public class NPCPathFollower : MonoBehaviour
{
    public Transform[] waypoints; // List of waypoints
    public float speed = 3f; // Movement speed
    public float waitTime = 1f; // Time to wait at waypoints
    public float detectionRadius = 3f; // Player detection radius
    public LayerMask playerLayer; // Assign to Player layer
    public float rotationAngle = 90f; // Editable rotation amount

    private int currentWaypointIndex = 0;
    private bool isWaiting = false;

    void Update()
    {
        if (!isWaiting && waypoints.Length > 0 && !IsPlayerNearby())
        {
            MoveToWaypoint();
        }
    }

    void MoveToWaypoint()
    {
        Transform targetWaypoint = waypoints[currentWaypointIndex];

        // Move toward the target waypoint
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        // Check if the NPC has reached the waypoint
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            StartCoroutine(RotateAndWait());
        }
    }

    IEnumerator RotateAndWait()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);

        // Rotate by the user-defined amount
        transform.Rotate(0, rotationAngle, 0);

        // Move to the next waypoint
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        isWaiting = false;
    }

    bool IsPlayerNearby()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, playerLayer);
        return colliders.Length > 0;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
