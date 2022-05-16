using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAudioController : MonoBehaviour
{

    bool isPlaying = false;
    // make sure to keep track of the movement as well !

    Rigidbody2D rb; // note the "2D" prefix 
    AudioSource movementSource;
    AudioSource impactSource;
    
    // Start is called before the first frame update
    void Start()
    {
	rb = GetComponent<Rigidbody2D>();
	movementSource = GetComponents<AudioSource>()[0];
	impactSource = GetComponents<AudioSource>()[1];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float v = rb.velocity.magnitude;
	if ( v > 1 && !isPlaying) {
	    movementSource.Play();
	    isPlaying = true;
	    // play sound here !
	} else if ( v < 1 && isPlaying ) {
	    // stop sound here !
	    movementSource.Stop();
	    isPlaying = false;
	}
    }

    void OnCollisionEnter2D(Collision2D coll) {
	impactSource.pitch = 0.8f + Random.Range(-0.2f, 0.2f);
	impactSource.Play();
    }
}
