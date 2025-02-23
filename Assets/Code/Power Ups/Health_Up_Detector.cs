using UnityEngine;

public class Health_Up_Detector : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Sphere")) 
        {
            GameObject mainCar = GameObject.Find("MainCarJoined");

            if (mainCar != null)
            {
                HealthManager healthManager = mainCar.GetComponent<HealthManager>();

                if (healthManager != null)
                {
                    healthManager.AddHealth();
                    Destroy(gameObject);
                    Debug.Log("Player has picked up the health power-up!");
                }
                else
                {
                    Debug.LogError("HealthManager not found on MainCarJoined!");
                }
            }
            else
            {
                Debug.LogError("MainCarJoined GameObject not found in the scene!");
            }
        }
    }
}
