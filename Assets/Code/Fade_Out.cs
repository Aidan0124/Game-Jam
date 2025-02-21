using UnityEngine;
using System.Collections;

public class Fade_Out : MonoBehaviour
{
    [SerializeField] private float destroyTime = 15.0f;
    [SerializeField] private float maxDistance = 30.0f; // Maximum distance to destroy the object
    [SerializeField] private AudioClip[] startSounds; // Array of start sound effects
    private AudioSource audioSource;
    private Transform playerTransform;
    private float elapsedTime = 0f;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        audioSource = gameObject.AddComponent<AudioSource>();
        PlayRandomStartSound();
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

    void PlayRandomStartSound()
    {
        if (startSounds.Length > 0)
        {
            int randomIndex = Random.Range(0, startSounds.Length);
            AudioClip randomClip = startSounds[randomIndex];
            audioSource.PlayOneShot(randomClip);
        }
        else
        {
            Debug.LogWarning("No start sounds assigned.");
        }
    }
}
