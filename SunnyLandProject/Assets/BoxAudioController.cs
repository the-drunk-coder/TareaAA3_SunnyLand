using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAudioController : MonoBehaviour
{

    bool isPlaying = false;

    Rigidbody2D rb;
    AudioSource movementSource;
    AudioSource impactSource;
        
    void Start()
    {
	rb = GetComponent<Rigidbody2D>();
	movementSource = GetComponents<AudioSource>()[0];
	impactSource = GetComponents<AudioSource>()[1];
    }
    
    void FixedUpdate()
    {
        float v = rb.velocity.magnitude;
	if ( v > 1 && !isPlaying) {
	    movementSource.Play();
	    isPlaying = true;
	} else if ( v < 1 && isPlaying ) {	    
	    movementSource.Stop();
	    isPlaying = false;
	}
    }

    void OnCollisionEnter2D(Collision2D coll) {	
	impactSource.Play();
    }
}
