using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public enum GameState
    {
        PLAY, SUPER_PLAYER, MASKED_PLAYER, PLAYER_DEAD, GAME_OVER, GAME_WON
    };
    public GameState gameState = GameState.PLAY;
	public GameObject player;
    public List<GameObject> enemies;
    public List<GameObject> fruits;
	public List<GameObject> sanitizers;
	public List<GameObject> masks;
	public GameObject vaccine;
	
	public bool collectedAllFruits = false;
	public bool covidKilled = false;
	public bool vaccineActive = true;
	public bool alive2 = true;
	public bool super = false;
	
	public AudioSource playerKilledSound;
    public AudioClip gameWonSound;
    public AudioClip gameOverSound;
	public AudioClip playerDead;
	public AudioClip superPlayer;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		Debug.Log(covidKilled);
        switch(gameState)
		{
			case GameState.PLAY:
				bool foundFruit = false;
				 foreach (GameObject fruit in fruits)
                {
                    if (fruit.activeSelf)
                    {	
						foundFruit = true;
                        collectedAllFruits = false;
                        break;
                    } 
                }
                if (!foundFruit)
                {
                    gameState = GameState.GAME_WON;
                }
				break;
			
			case GameState.GAME_OVER:
				AudioSource.PlayClipAtPoint(playerDead, transform.position);
				break;
			case GameState.GAME_WON:
				AudioSource.PlayClipAtPoint(gameWonSound, transform.position);
				break;

		}
		
			//Invoke("respawnEnemy",3f);
			if(covidKilled){
				Debug.Log("DEH YAH!!!!!!!!!!!!!!!");
						Invoke("respawnEnemy",10f);
						covidKilled = false;
			}
			
			if(!vaccine.activeSelf){
			Invoke("respawnVaccine",20f);
			}
               
			if(!alive2){
				gameState = GameState.GAME_OVER;
			}
			
			if(super){
				AudioSource.PlayClipAtPoint(superPlayer, transform.position);
				super = false;
			}
    }
	
	
	public void respawnEnemy()
	{
		Debug.Log("RESPAWNING");
		 foreach (GameObject enemy in enemies)
                {	
				Debug.Log(enemy.activeSelf);
					if(!enemy.activeSelf){
						enemy.SetActive(true);
					}
                }
			
	}
	
	public void respawnVaccine()
	{
		vaccine.SetActive(true);
		vaccine.GetComponent<VaccineScript>().isActive = true;
		

	}
	
	void setEnemyActive(){
		
	}
	
	
	
}
