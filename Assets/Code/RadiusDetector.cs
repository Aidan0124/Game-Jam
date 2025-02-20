


    /*
        Objective, create a script that creates a 10f radius around its origin.
        This radius first checjs if the object that entered it is a child object.
        Then if that object is a child object it will check if it has the tag sphere.
        If both are true it will not collide with that object.
        But it will collide with any other object that enters the radius.
    */
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame


using UnityEngine;

public class IgnoreSphereInTrigger : MonoBehaviour
{
    private Collider mainCollider;  // The main collider on the sphere (non-trigger)
    private Collider triggerCollider; // The trigger collider around the object
    private bool isSphereInside = false;

    void Start()
    {
        // Ensure the object has a main collider (non-trigger) and a trigger collider
        mainCollider = GetComponent<Collider>();
        triggerCollider = GetComponentInChildren<Collider>();  // This should be the trigger collider

        if (mainCollider == null || triggerCollider == null || !triggerCollider.isTrigger)
        {
            Debug.LogError("Missing required colliders or invalid trigger setup.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering object is tagged as "Sphere"
        if (other.CompareTag("Sphere"))
        {
            // Ignore collisions between the main sphere collider and this object
            Physics.IgnoreCollision(mainCollider, other, true); // Ignore collision
            isSphereInside = true;
            Debug.Log("Sphere entered trigger, ignoring collision.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // When the sphere exits the trigger zone, restore collision
        if (other.CompareTag("Sphere"))
        {
            Physics.IgnoreCollision(mainCollider, other, false); // Restore collision
            isSphereInside = false;
            Debug.Log("Sphere exited trigger, collisions restored.");
        }
    }
}