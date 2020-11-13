using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacdot : MonoBehaviour
{
	    public int points = 100;//how many points to give the player upon collection
	    public AudioClip collectSound;

 void OnCollisionEnter2D(Collision2D other)
     {
        if(other.gameObject.tag =="face"){
			collected(other);
		}
		
     }
		
		    protected virtual void collected(Collision2D coll)
    {
        AudioSource.PlayClipAtPoint(collectSound, transform.position);
        gameObject.SetActive(false);
    }
	
	    protected virtual void collected2(Collider2D coll)
    {	
		ScoreScript.scoreValue += 100;
        //coll.gameObject.GetComponent<PlayerController>().addPoints(points);
        AudioSource.PlayClipAtPoint(collectSound, transform.position);
        gameObject.SetActive(false);
    }

void OnTriggerEnter2D(Collider2D co) {
	if (co.name == "face"){
		collected2(co);
	gameObject.SetActive(false);
	}
               }
			   
			   
}


