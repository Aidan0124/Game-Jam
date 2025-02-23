using UnityEngine;

public class Health_Up_Detector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Sphere"))
        {
            if (other.TryGetComponent<Health>(out Health health))
            {
                health.health += 10f;
            }
            Destroy(gameObject);
            Debug.Log("Player has picked up the health power up!");
        }
    }
}
