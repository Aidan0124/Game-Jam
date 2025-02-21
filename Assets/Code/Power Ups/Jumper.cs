using UnityEngine;

public class Jumper : MonoBehaviour
{
    public bool isJumpUpPower = false;

    public bool grounded = true;
    public int jumpCount = 2;
    public float powerUpTime = 10f;

    private float powerUpTimer;

    void Start()
    {
        powerUpTimer = powerUpTime;
    }

    void Update()
    {
        if (isJumpUpPower)
        {

            if (powerUpTimer > 0)
            {
                powerUpTimer -= Time.deltaTime;
                Debug.Log(powerUpTimer);
            }
            else
            {

                isJumpUpPower = false;
                jumpCount = 2;
                powerUpTimer = powerUpTime;
            }
        }

        if (isJumpUpPower && grounded)
        {
            if (jumpCount > 0 && Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * 10, ForceMode.Impulse);
                jumpCount--;

                if (jumpCount == 0)
                {
                    grounded = false;
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            jumpCount = 2;
        }
    }
}
