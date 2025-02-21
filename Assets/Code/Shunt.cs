using UnityEngine;

public class Shunt : MonoBehaviour
{
    public float powerUpTime = 10f;
    public float teleportDistance = 5f; // Distance to teleport
    private float powerUpTimer;
    public bool isShunt = false;

    void Start()
    {
        powerUpTimer = powerUpTime;
    }

    void Update()
    {
        if (isShunt)
        {
            if (powerUpTimer > 0)
            {
                powerUpTimer -= Time.deltaTime;
                Debug.Log("Power-up time left: " + powerUpTimer);
            }
            else
            {
                isShunt = false; // Disable teleporting after time runs out
                Debug.Log("Shunt power-up expired!");
            }
        }

        // Only teleport if power-up is active
        if (isShunt && Input.GetKeyDown(KeyCode.LeftShift))
        {
            Teleport();
        }
    }

    void Teleport()
    {
        Vector3 newPosition = transform.position;


        if (Input.GetKey(KeyCode.D)) 
        {
            newPosition.x += teleportDistance;
        }
        else if (Input.GetKey(KeyCode.A)) 
        {
            newPosition.x -= teleportDistance;
        }


        if (Input.GetKey(KeyCode.W)) 
        {
            newPosition.z += teleportDistance;
        }
        else if (Input.GetKey(KeyCode.S)) 
        {
            newPosition.z -= teleportDistance;
        }

        transform.position = newPosition;
        Debug.Log("Teleported to: " + newPosition);
    }


    public void ActivateShunt()
    {
        isShunt = true;
        powerUpTimer = powerUpTime; 
        Debug.Log("Shunt power-up activated!");
    }
}
