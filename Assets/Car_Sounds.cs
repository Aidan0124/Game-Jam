using UnityEngine;

public class Car_Sounds : MonoBehaviour
{
    public AudioSource engineAudioSource;
    public AudioClip engineIdleClip;
    public AudioClip[] accelerationClips;

    private Rigidbody carRigidbody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        carRigidbody = GetComponent<Rigidbody>();
        engineAudioSource.clip = engineIdleClip;
        engineAudioSource.loop = true;
        engineAudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = carRigidbody.linearVelocity.magnitude;
        AudioClip selectedClip = engineIdleClip;
        float volume = engineAudioSource.volume; // Use the initial volume set in the inspector

        if (speed > 0.1f && speed <= 10f)
        {
            selectedClip = accelerationClips[0];
            volume = 0.1f; // Set volume for this clip
        }
        else if (speed > 10f && speed <= 20f)
        {
            selectedClip = accelerationClips[1];
            volume = 0.2f; // Set volume for this clip
        }
        else if (speed > 20f && speed <= 30f)
        {
            selectedClip = accelerationClips[2];
            volume = 0.3f; // Set volume for this clip
        }
        else if (speed > 30f)
        {
            selectedClip = accelerationClips[3];
            volume = 0.4f; // Set volume for this clip
        }

        if (engineAudioSource.clip != selectedClip)
        {
            engineAudioSource.clip = selectedClip;
            engineAudioSource.volume = volume; // Set the volume before playing
            engineAudioSource.Play();
        }
    }
}
