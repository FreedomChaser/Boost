using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rocketRigidbody;
    AudioSource audioSource;

    [SerializeField] float mainThrust = 900f;
    [SerializeField] float rotateSpeed = 2f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainEngineParticle;
    // Start is called before the first frame update
    void Start()
    {
        rocketRigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rocketRigidbody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if (!mainEngineParticle.isPlaying)
            {
                mainEngineParticle.Play();
            }
            else
            {
                mainEngineParticle.Stop();
            }

            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotateSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotateSpeed);
        }
    }

    private void ApplyRotation(float vectorDirection)
    {
        rocketRigidbody.freezeRotation = true;
        transform.Rotate(Vector3.forward * vectorDirection * Time.deltaTime);
        rocketRigidbody.freezeRotation = false;
    }
}
