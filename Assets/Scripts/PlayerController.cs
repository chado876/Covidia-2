using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController: MonoBehaviour
{
	public float speed;	//the speed pacman can travel
	public int score = 0;	//the score
	public int lives = 2;	//how many extras lives pacman has left
	public int life = 2;
	public int livesLeft = 2;	//how many extras lives pacman has left

	private Vector2 direction;	//the direction pacman is going
	public bool alive = true;
	public bool isSanitized = false;
	public bool isMasked = false;
	public int maxHealth = 100;
	public int currentHealth;

	public GameObject stateManager;
	
	//References
	private Rigidbody2D rb2d;

	private Sprite faceSprite, maskFaceSprite;
	//public Image heart1, heart2;

	public HealthBar healthBar;

	SpriteRenderer mySpriteRenderer;

	// Use this for initialization
	void Start()
	{
		currentHealth = maxHealth;
		rb2d = GetComponent<Rigidbody2D> ();
		mySpriteRenderer = GetComponent<SpriteRenderer> ();
		maskFaceSprite = Resources.Load<Sprite> ("Sprites/Characters/face_mask");
		healthBar.SetMaxHealth(maxHealth);

	}

	void FixedUpdate()
	{

		if(alive){
		if (Input.GetAxis("Horizontal") < 0)
		{
			direction = Vector2.left;
					            Debug.Log("You are holding down the 'left' on the Trigger");

		}
		else if (Input.GetAxis("Horizontal") > 0)
		{
			direction = Vector2.right;
								            Debug.Log("You are holding down the 'right' on the Trigger");

		}

		if (Input.GetAxis("Vertical") < 0)
		{
			direction = Vector2.down;
								            Debug.Log("You are holding down the 'down' on the Trigger");

		}
		else if (Input.GetAxis("Vertical") > 0)
		{
			direction = Vector2.up;
								            Debug.Log("You are holding down the '' on the Trigger");

		}

		rb2d.velocity = direction * speed;
		transform.up = direction;
		if (rb2d.velocity.x == 0)
		{
			transform.position = new Vector2(Mathf.Round(transform.position.x), transform.position.y);
		}

		if (rb2d.velocity.y == 0)
		{
			transform.position = new Vector2(transform.position.x, Mathf.Round(transform.position.y));
		}

		}    
	}

	IEnumerator OnCollisionEnter2D(Collision2D other)
	{	
		if (other.gameObject.tag == "mask")
		{
	Debug.Log("HERE" + other.gameObject.tag);
					isMasked = true;
				Destroy(other.gameObject);

			//ChangeFace("face_mask");
	mySpriteRenderer.sprite = Resources.Load<Sprite>("Sprites/Characters/face_mask");
    yield return new WaitForSeconds (8f);
    mySpriteRenderer.sprite = Resources.Load<Sprite>("Sprites/Characters/face");
	isMasked = false;
		} 
		else if (other.gameObject.tag == "sanitizer"){
	StateManager sm = stateManager.GetComponent<StateManager>();
	sm.super = true;
	mySpriteRenderer.sprite = Resources.Load<Sprite>("Sprites/sanitized_face");
    yield return new WaitForSeconds (8f);
    mySpriteRenderer.sprite = Resources.Load<Sprite>("Sprites/Characters/face");
		}
	}

	 public IEnumerator ChangeFace (string spriteName)
{
	Debug.Log("Changing" +spriteName);
    mySpriteRenderer.sprite = Resources.Load<Sprite>("Sprites/Characters/" + spriteName);
    yield return new WaitForSeconds (8f);
    mySpriteRenderer.sprite = Resources.Load<Sprite>("Sprites/Characters/face");
}

 public IEnumerator killVirusActivated ()
{	
	isSanitized = true;
    yield return new WaitForSeconds (5f);
	isSanitized = false;
}

	public void addPoints(int pointsToAdd)
	{
		score += pointsToAdd;
	}

	public void setAlive(bool isAlive)
	{
		alive = isAlive;
	}

	public void setLivesLeft(int lives)
	{
		life = lives;
		if (life < 2)
		{
		//	heart1.enabled = false;
		}
	}

	public void lifeCheck()
	{
	//	if (life == 1)
	//	{
	//		heart1.enabled = false;
//		}
//		else if (life == 0)
//		{
////			heart2.enabled = false;

//		}
	}

	public int getLives()
	{
		return life;
	}

	public void setLives(int num)
	{
		life = num;
	}

	public void decreaseLife()
	{
			StateManager sm = stateManager.GetComponent<StateManager>();

		if(currentHealth == 0){
		setAlive(false);
		sm.alive2 = false;
		}

		TakeDamage(25);
	}

	public void Sanitize(bool val)
	{
		if (val == true)
		{
			isSanitized = true;
			Debug.Log("truuue");
		//	StartCoroutine(timeOut());
		//	isSanitized = false;
		}
		else
		{
			isSanitized = false;
		}
	}

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		healthBar.SetHealth(currentHealth);
	}
	
	public void regenHealth(){
		currentHealth = maxHealth;
		healthBar.SetHealth(currentHealth);
	}
}