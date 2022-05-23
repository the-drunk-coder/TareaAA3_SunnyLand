using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    bool isJumping = false;
    bool isPlaying = false;

    Rigidbody2D rb;
    AudioSource runningSource;
    AudioSource jumpSource;
    AudioSource cherrySource;

    public AudioClip jumpSound;
    public AudioClip landSound;
    public AudioClip crouchSound;
	
    void Start()
    {
	rb = GetComponent<Rigidbody2D>();
	runningSource = GetComponents<AudioSource>()[0];
	jumpSource = GetComponents<AudioSource>()[1];
	cherrySource = GetComponents<AudioSource>()[2];	       
    }
    
    void FixedUpdate()
    {	
	float v = rb.velocity.magnitude;
	if ( v > 1 && !isPlaying && !isJumping) {
	    runningSource.Play();
	    isPlaying = true;
	} else if ( v < 1 && isPlaying ) {	    
	    runningSource.Stop();
	    isPlaying = false;
	}
	
	if (isJumping) {
	    runningSource.Stop();
	    isPlaying = false;
	}
    }
    
    public void OnLanding() {
        isJumping = false;
	jumpSource.clip = landSound;

	int randomNumber = Random.Range(0, 2);
	if (randomNumber == 1) {
	    jumpSource.pitch = 1.0f + Random.Range(-0.4f, 0.4f);
	} else {
	    jumpSource.pitch = 1.0f;
	}
	
	jumpSource.Play();
        print("the fox has landed");	
    }
    
    public void OnCrouching() {
	jumpSource.clip = crouchSound;
	jumpSource.Play();
        print("the fox is crouching");
    }
 
    public void OnJump() {
        isJumping = true;
	jumpSource.clip = jumpSound;
	jumpSource.pitch = 1.0f + Random.Range(-0.3f, 0.3f);		
	jumpSource.Play();
        print("the fox has jumped");
    }
    
    public void OnCherryCollect() {
	cherrySource.Play();
        print("the fox has collected a cherry");
    }
}
