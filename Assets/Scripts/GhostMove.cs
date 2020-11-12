using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour
{
public Transform[] waypoints;
    int cur = 0;
	
    public int points = 400;//how many points you get for eating this ghost

    private bool killed = false;

    private Rigidbody2D rb2d;
    private CircleCollider2D cc2d;
    private SpriteRenderer sr;
    private AudioSource ghostEatenSound;
	
    public float speed = 0.3f;

	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        cc2d = GetComponent<CircleCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        ghostEatenSound = GetComponent<AudioSource>();
    }
	
    void FixedUpdate () {
// Waypoint not reached yet? then move closer
    if (transform.position != waypoints[cur].position) {
        Vector2 p = Vector2.MoveTowards(transform.position,
                                        waypoints[cur].position,
                                        speed);
        GetComponent<Rigidbody2D>().MovePosition(p);
    }
    // Waypoint reached, select next one
    else cur = (cur + 1) % waypoints.Length;
    }
	
	void OnTriggerEnter2D(Collider2D co) {
    if (co.name == "face"){
			    PlayerController playerController = co.gameObject.GetComponent<PlayerController>();
				
        //Destroy(co.gameObject);
		playerController.decreaseLife();
		playerController.lifeCheck();
	            //ghostEatenSound.Play();
	}
		

	}

    public void setKilled(bool isKilled)
    {
        killed = isKilled;
        if (killed)
        {
            cc2d.enabled = false;
           // ghostEatenSound.Play();
        }
        else
        {
            cc2d.enabled = true;
        }
    }
	

}

