using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Destructable : MonoBehaviour
{
    [SerializeField] private GameObject destroyedVersion;
    [SerializeField] private FollowCamera cameraFollow; // Reference to FollowCamera script

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (destroyedVersion != null)
            {
                Instantiate(destroyedVersion, transform.position, transform.rotation);
                Destroy(gameObject);

                // Trigger camera shake
                if (cameraFollow != null)
                {
                    StartCoroutine(cameraFollow.Shake(0.5f, 0.2f)); // Adjust duration and magnitude as needed
                }
                else
                {
                    Debug.LogWarning("FollowCamera reference is not assigned.");
                }
            }
            else
            {
                Debug.LogWarning("Destroyed version is not assigned.");
            }
        }
    }
}