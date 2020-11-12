using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{	
	
	public GameObject heart1,heart2;
	public static int lives;
	
    // Start is called before the first frame update
    void Start()
    {
        heart1.gameObject.SetActive(true);
		heart2.gameObject.SetActive(true);
		lives = 2;

    }

    // Update is called once per frame
    void Update()
    {
		switch(lives){
			case 1:
				heart1.gameObject.SetActive(false);
			break;
		}
    }
}
