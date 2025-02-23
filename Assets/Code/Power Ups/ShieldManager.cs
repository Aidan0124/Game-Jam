using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    public bool isShield = false;
    public float shieldDuration = 10f; // Duration for the shield in seconds
    private float shieldTimer;

    void Start()
    {
        shieldTimer = shieldDuration;
    }

    void Update()
    {
        // Handle shield timer countdown
        if (isShield)
        {
            shieldTimer -= Time.deltaTime; // Count down the shield timer
            if (shieldTimer <= 0)
            {
                isShield = false; // Deactivate shield
                shieldTimer = 0; // Reset the timer
                Debug.Log("Shield deactivated");
            }
        }
    }

    public void ActivateShield()
    {
        // Activate shield and reset the timer
        isShield = true;
        shieldTimer = shieldDuration;
        Debug.Log("Shield activated for " + shieldDuration + " seconds");
    }

    public bool IsShieldActive()
    {
        return isShield;
    }
}
