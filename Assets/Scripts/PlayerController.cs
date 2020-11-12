using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

 public float speed;//the speed pacman can travel
    public int score = 0;//the score
    public int lives = 2;//how many extras lives pacman has left
	public int life = 2;
	    public int livesLeft = 2;//how many extras lives pacman has left

    private Vector2 direction;//the direction pacman is going
    private bool alive = true;

	public int maxHealth = 100;
	public int currentHealth;
	
    //References
    private Rigidbody2D rb2d;
    private Animator anim;
	
	private Sprite faceSprite, maskFaceSprite;
	public Image heart1,heart2;
	
	public HealthBar healthBar;
	
	SpriteRenderer mySpriteRenderer;
	

	// Use this for initialization
	void Start () {
		
		currentHealth = maxHealth;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	mySpriteRenderer = GetComponent<SpriteRenderer>();
		maskFaceSprite =Resources.Load<Sprite>("Sprites/Characters/face_mask");
		healthBar.SetMaxHealth(maxHealth);

	}
	
	void FixedUpdate () {
		if(alive){
		anim.SetFloat("currentSpeed", rb2d.velocity.magnitude);
		if (Input.GetAxis("Horizontal") < 0)
        {
            direction = Vector2.left;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            direction = Vector2.right;
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            direction = Vector2.down;
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            direction = Vector2.up;
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
  void OnCollisionEnter2D(Collision2D other)
     {
         if (other.gameObject.tag == "mask"){
			StartCoroutine (ChangeFace("face_mask"));
		 			Destroy(other.gameObject);

         }else{
			 Debug.Log("Not hit");
			 Debug.Log(other.gameObject.tag);
     
	 }
	 }
	 public IEnumerator ChangeFace (string spriteName)
{
    mySpriteRenderer.sprite = Resources.Load<Sprite>("Sprites/Characters/" + spriteName);
    yield return new WaitForSeconds (10.0f);
    mySpriteRenderer.sprite = Resources.Load<Sprite>("Sprites/Characters/face");
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
		if(life<2){
			heart1.enabled = false;
		}

    }
	
	    public void lifeCheck()
    {
		if(life == 1){
			heart1.enabled = false;
		} else if (life == 0){
			heart2.enabled = false;
			
		}

    }
	
		public int getLives()
	{
		return life;
	}
	
	public void setLives(int num)
	{
		life = num;
	}
	
	public void decreaseLife(){
		//life = life - 1;
		//if(life == 0){
		//	setAlive(false);
		//}
		
		TakeDamage(10);
	}
	
	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		healthBar.SetHealth(currentHealth);
	}
}
