using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Destructable : MonoBehaviour
{
    [SerializeField] private GameObject destroyedVersion;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (destroyedVersion != null)
            {
                Instantiate(destroyedVersion, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("Destroyed version is not assigned.");
            }
        }
    }
}
