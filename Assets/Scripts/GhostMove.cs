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
    public AudioClip killSound;
	public AudioClip coughSound;
	public GameObject stateManager;

	
    public float speed = 0.3f;

	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        cc2d = GetComponent<CircleCollider2D>();
        sr = GetComponent<SpriteRenderer>();
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
	
	public void OnTriggerEnter2D(Collider2D co) {
	PlayerController playerController = co.gameObject.GetComponent<PlayerController>();

    if (co.name == "face"){
		if(playerController.isSanitized){
				StateManager sm = stateManager.GetComponent<StateManager>();
				sm.covidKilled = true;
				AudioSource.PlayClipAtPoint(killSound, transform.position);
				gameObject.SetActive(false);
				// yield return new WaitForSeconds (7f);
				 //gameObject.SetActive(true);


			} else if (playerController.isMasked) {
				
			} else {
		AudioSource.PlayClipAtPoint(coughSound, transform.position);
		playerController.decreaseLife();
		playerController.lifeCheck();
			}
				
        //Destroy(co.gameObject);

	            //ghostEatenSound.Play();
	}
		
	
	}

	

}

