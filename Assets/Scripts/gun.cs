using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    public UnityEvent OnGunShoot;
    public float FireCooldown = 0;

    // Semi auto gun
    public bool Automatic;

    public AudioClip shootingSound; // Add AudioClip variable
    private AudioSource audioSource; // Reference to the AudioSource component

    private float CurrentCooldown;

    void Start()
    {
        CurrentCooldown = FireCooldown;
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Automatic)
        {
            if (Input.GetMouseButton(0))
            {
                if (CurrentCooldown <= 0f)
                {
                    Shoot();
                    CurrentCooldown = FireCooldown;
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (CurrentCooldown <= 0f)
                {

                    Shoot();
                    Debug.Log("Shoot");
                    CurrentCooldown = FireCooldown;
                }
            }
        }

        CurrentCooldown -= Time.deltaTime;
    }

    void Shoot()
    {
        // Invoke UnityEvent
        OnGunShoot?.Invoke();

        // Play shooting sound
        if (shootingSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(shootingSound);
        }
    }
}
