using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    public bool isShield = false;
    public float shieldDuration = 10f; 
    private float shieldTimer;

    void Start()
    {
        shieldTimer = shieldDuration;
    }

    void Update()
    {
        if (isShield)
        {
            if(shieldTimer > 0)
            {
                shieldTimer -= Time.deltaTime;
                Debug.Log(shieldTimer);
            }
            else
            {
                isShield = false; 
                shieldTimer = shieldDuration; 
                Debug.Log("Shield deactivated");
            }
        }
    }

    public void ActivateShield()
    {

        isShield = true;
        shieldTimer = shieldDuration;
        Debug.Log("Shield activated for " + shieldDuration + " seconds");
    }

    public bool IsShieldActive()
    {
        return isShield;
    }
}
