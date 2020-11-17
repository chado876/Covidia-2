using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanitizerScript : MonoBehaviour
{
	    public AudioClip collectSound;
		public bool sanitized = false;
		PlayerController playerController;

 public void OnCollisionEnter2D(Collision2D other)
     {
        if(other.gameObject.tag =="face"){
			collected(other);
			bool sanitized = true;
			playerController = other.gameObject.GetComponent<PlayerController>();
			playerController.isSanitized = true;
			playerController.speed = 3.8f;
			SpriteRenderer sr = other.gameObject.GetComponent<SpriteRenderer>();
			//sr.color = new Color(1f,1f,1f,1f);
			Invoke("deSanitize",8);
			//sr.color = new Color(0f,0f,0f,0f);

			//yield return new WaitForSeconds (10.0f);
			//playerController.isSanitized = false;

		}
		
     }
		
		    protected virtual void collected(Collision2D coll)
    {
        AudioSource.PlayClipAtPoint(collectSound, transform.position);
        gameObject.SetActive(false);
    }
	
	private void deSanitize(){
		 playerController.isSanitized= false;
		 playerController.speed = 3.0f;
	}
	

}
