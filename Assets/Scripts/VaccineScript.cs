using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaccineScript : MonoBehaviour
{
		public AudioClip collectSound;
		PlayerController playerController;
			public GameObject stateManager;
			public bool isActive = true;
			
 public void OnCollisionEnter2D(Collision2D other)
     {
        if(other.gameObject.tag =="face"){
			AudioSource.PlayClipAtPoint(collectSound, transform.position);
			playerController = other.gameObject.GetComponent<PlayerController>();
			playerController.regenHealth();
			Destroy(gameObject);

		}
		
     }
		
		protected virtual void collected(Collision2D coll)
    {
        AudioSource.PlayClipAtPoint(collectSound, transform.position);
        gameObject.SetActive(false);
    }
	
}
