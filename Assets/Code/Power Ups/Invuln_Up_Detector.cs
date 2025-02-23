using UnityEngine;

public class Invuln_Up_Detector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Sphere"))
        {
            ShieldManager isShield = other.GetComponent<ShieldManager>();
            if (isShield != null)
            {
                isShield.ActivateShield();
            }
            Destroy(gameObject);
            Debug.Log("Player has picked up the invulnerability power up!");
        }
    }
}
