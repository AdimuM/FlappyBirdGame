using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody2D rb;
    public bool isDead = false;
    
    // Add AudioClip for collision sound
    public AudioClip collisionSound;
    private AudioSource audioSource;
    private Animator animator;

    void Start()
    {
        // Get Rigidbody2D Component of the Bird
        rb = GetComponent<Rigidbody2D>();
        
        // Get AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component missing from Player GameObject");
        }
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * speed;
        }
    }

    private bool soundPlayed = false;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!soundPlayed)  // Check if the sound has already played
        {
            audioSource.PlayOneShot(collisionSound);
            soundPlayed = true;  // Prevent further sound playing
        }
    
        isDead = true;
        animator.enabled = false;
    }

}

