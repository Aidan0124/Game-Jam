using Unity.VisualScripting;
using UnityEngine;

public class JumpUpPower : MonoBehaviour
{
    public bool isJumpUpPower = false;
    public int jumpCount = 2;
    public int powerUpTime = 10;
    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            isJumpUpPower = true;
            Destroy(gameObject);
        }
        
    }

    void Update()
    {
        if(isJumpUpPower == true) 
        {
            if(jumpCount > 0)
            {
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    GetComponent<Rigidbody>().AddForce(Vector3.up * 10, ForceMode.Impulse);
                    jumpCount--;
                }
            }
        }
        while(powerUpTime > 0)
        {
            powerUpTime--;
        }
        if(powerUpTime == 0)
        {
            isJumpUpPower = false;
            jumpCount = 2;
            powerUpTime = 10;
        }
    }
}
