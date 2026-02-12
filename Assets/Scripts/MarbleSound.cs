using UnityEngine;

public class MarbleSound : MonoBehaviour
{
    public AudioClip[] woodImpactSounds;
    public AudioClip[] xyloSounds;

    public AudioClip[] billeImpactSounds;
    public AudioSource oneShotAudioSource;
    public AudioSource rollingAudioSource;

    private Rigidbody rb;
    public float currentVelocity;
    public float velMultiplier;
    private float soundMultiplier;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }


    void Update()
    {
        currentVelocity = rb.linearVelocity.magnitude;
        velMultiplier = Mathf.InverseLerp(-3, 3, currentVelocity);

        if (currentVelocity < 0.1f)
        {
            rollingAudioSource.volume = 0f;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Wood>() != null)
        {
            if (currentVelocity > 3f)
            {
                int randomIndex = Random.Range(0, woodImpactSounds.Length);
                oneShotAudioSource.pitch = 1;
                oneShotAudioSource.pitch += currentVelocity / 3f;
                oneShotAudioSource.volume = 0f;
                oneShotAudioSource.volume += currentVelocity / 3f;
                oneShotAudioSource.PlayOneShot(woodImpactSounds[randomIndex]);

                int randomIndex2 = Random.Range(0, xyloSounds.Length);
                oneShotAudioSource.PlayOneShot(xyloSounds[randomIndex2]);
            }
        }
    }

    void OnCollisionStay(Collision other)
    {
        //HIT BLOCK WOOD
        if (other.gameObject.CompareTag("Block"))
        {
            if (currentVelocity > 0.4f)
            {
                rollingAudioSource.pitch = 1;
                rollingAudioSource.pitch += currentVelocity / 3f;
                rollingAudioSource.volume = 0f;
                rollingAudioSource.volume += currentVelocity / 3f;
            }

        }

        //HIT MARBLE
        if (other.gameObject.CompareTag("Marble"))
        {
            if (currentVelocity > 2.6f)
            {
                int randomIndex = Random.Range(0, woodImpactSounds.Length);
                oneShotAudioSource.pitch = 1;
                oneShotAudioSource.pitch += Random.Range(-0.1f, 0.1f);
                oneShotAudioSource.PlayOneShot(billeImpactSounds[randomIndex]);
            }

        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Block"))
        {
            rollingAudioSource.volume = 0f;
        }
    }
}
