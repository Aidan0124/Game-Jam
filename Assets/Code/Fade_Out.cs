using UnityEngine;
using System.Collections;

public class Fade_Out : MonoBehaviour
{
 private float destroyTime = 15.0f;
 private float maxDistance = 30.0f; // Maximum distance to destroy the object
    private Transform playerTransform;
    private float elapsedTime = 0f;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (playerTransform != null)
        {
            float distance = Vector3.Distance(transform.position, playerTransform.position);
            if (elapsedTime > destroyTime && distance > maxDistance)
            {
                Destroy(gameObject);
            }
        }
    }
}
