using UnityEngine;
using System.Collections;

public class Speed_Up_Detector : MonoBehaviour
{
    public float speedBoostAmount = 50f;
    public float reverseBoostAmount = 25f;
    public float turnBoostAmount = 50f;
    public float boostDuration = 10f; // Duration of the speed boost

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CarFinal car = other.GetComponent<CarFinal>();
            if (car != null)
            {
                StartCoroutine(TemporarySpeedBoost(car));
                Debug.Log("Speed Up!");
            }

            Destroy(gameObject); // Remove the power-up object after activation
        }
    }

    IEnumerator TemporarySpeedBoost(CarFinal car)
    {
        // Store original values
        float originalMoveSpeed = car.moveSpeed;
        float originalReverseSpeed = car.reverseSpeed;
        float originalTurnSpeed = car.turnSpeed;

        // Apply temporary boost
        car.moveSpeed += speedBoostAmount;
        car.reverseSpeed += reverseBoostAmount;
        car.turnSpeed += turnBoostAmount;

        Debug.Log("Boost applied: MoveSpeed = " + car.moveSpeed + ", ReverseSpeed = " + car.reverseSpeed + ", TurnSpeed = " + car.turnSpeed);

        // Wait for the boost duration
        yield return new WaitForSeconds(boostDuration);

        // Revert to original values
        car.moveSpeed = originalMoveSpeed;
        car.reverseSpeed = originalReverseSpeed;
        car.turnSpeed = originalTurnSpeed;

        Debug.Log("Speed boost ended! Values reverted.");
    }
}
