using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    // keep track of the jumping state ... 
    bool isJumping = false;
    bool isPlaying = false;
    // make sure to keep track of the movement as well !

    Rigidbody2D rb; // note the "2D" prefix 
    AudioSource runningSource;
    AudioSource jumpSource;
    AudioSource cherrySource;

    public AudioClip jumpSound;
    public AudioClip landSound;
    public AudioClip crouchSound;
	
    // Start is called before the first frame update
    void Start()
    {
	rb = GetComponent<Rigidbody2D>();
	runningSource = GetComponents<AudioSource>()[0];
	jumpSource = GetComponents<AudioSource>()[1];
	cherrySource = GetComponents<AudioSource>()[2];	
	// get the references to your audio sources here !        
    }

    // FixedUpdate is called whenever the physics engine updates
    void FixedUpdate()
    {
	// Use the ridgidbody instance to find out if the fox is
	// moving, and play the respective sound !
	// Make sure to trigger the movement sound only when
	// the movement begins ...

	// Use a magnitude threshold of 1 to detect whether the
	// fox is moving or not !
	// i.e.
	float v = rb.velocity.magnitude;
	if ( v > 1 && !isPlaying && !isJumping) {
	    runningSource.Play();
	    isPlaying = true;
	    // play sound here !
	} else if ( v < 1 && isPlaying ) {
	    // stop sound here !
	    runningSource.Stop();
	    isPlaying = false;
	}

	
	if (isJumping) {
	    runningSource.Stop();
	    isPlaying = false;
	}
    }
    
    // trigger your landing sound here !
    public void OnLanding() {
        isJumping = false;
	jumpSource.clip = landSound;

	// slightly more complex solution ...
	int randomNumber = Random.Range(0, 2);
	if (randomNumber == 1) {
	    jumpSource.pitch = 1.0f + Random.Range(-0.4f, 0.4f);
	} else {
	    jumpSource.pitch = 1.0f;
	}
	
	jumpSource.Play();
        print("the fox has landed");
	// to keep things cleaner, you might want to
	// play this sound only when the fox actually jumoed ...
    }

    // trigger your crouching sound here
    public void OnCrouching() {
	jumpSource.clip = crouchSound;
	jumpSource.Play();
        print("the fox is crouching");
    }
 
    // trigger your jumping sound here !
    public void OnJump() {
        isJumping = true;
	jumpSource.clip = jumpSound;

	// the minimalist solution ...
	jumpSource.pitch = 1.0f + Random.Range(-0.3f, 0.3f);
		
	jumpSource.Play();
	//runningSource.Stop();
	//isPlaying = false;
        print("the fox has jumped");
    }

    // trigger your cherry collection sound here !
    public void OnCherryCollect() {
	cherrySource.Play();
        print("the fox has collected a cherry");
    }
}
