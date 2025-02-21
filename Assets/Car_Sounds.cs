using UnityEngine;

public class Car_Sounds : MonoBehaviour
{
    public AudioSource engineAudioSource;
    public AudioClip engineIdleClip;
    public AudioClip[] accelerationClips;

    [SerializeField]
    private Rigidbody carRigidbody;

    private AudioClip nextClip;
    private float nextVolume;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (carRigidbody == null)
        {
            carRigidbody = GetComponent<Rigidbody>();
        }
        engineAudioSource.clip = engineIdleClip;
        engineAudioSource.loop = false;
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
            volume = 0.2f; // Set volume for this clip
        }
        else if (speed > 10f && speed <= 20f)
        {
            selectedClip = accelerationClips[1];
            volume = 0.4f; // Set volume for this clip
        }
        else if (speed > 20f && speed <= 30f)
        {
            selectedClip = accelerationClips[2];
            volume = 0.6f; // Set volume for this clip
        }
        else if (speed > 30f)
        {
            selectedClip = accelerationClips[3];
            volume = 0.8f; // Set volume for this clip
        }

        if (engineAudioSource.clip != selectedClip)
        {
            nextClip = selectedClip;
            nextVolume = volume;
        }

        if (!engineAudioSource.isPlaying && nextClip != null)
        {
            Debug.Log($"Switching to clip: {nextClip.name} with volume: {nextVolume}");
            engineAudioSource.clip = nextClip;
            engineAudioSource.volume = nextVolume; // Set the volume before playing
            engineAudioSource.Play();
            nextClip = null;
        }
    }
}
