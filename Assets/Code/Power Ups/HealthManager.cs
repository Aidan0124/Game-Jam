using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public Health healthComponent;

    void Start()
    {
        // Find MainCarJoined to get the Health component
        GameObject mainCar = GameObject.Find("MainCarJoined");

        if (mainCar != null)
        {
            healthComponent = mainCar.GetComponent<Health>();
        }

        if (healthComponent == null)
        {
            Debug.LogError("Health component not found on MainCarJoined!");
        }
    }

    public void AddHealth()
    {
        if (healthComponent != null)
        {
            healthComponent.health += 10f;

            if (healthComponent.health > healthComponent.maxHealth)
            {
                healthComponent.health = healthComponent.maxHealth;
            }

            Debug.Log("Health added! Current Health: " + healthComponent.health);
        }
        else
        {
            Debug.LogError("No Health component found!");
        }
    }
}
