using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

 public float speed;//the speed pacman can travel
    public int score = 0;//the score
    public int livesLeft = 2;//how many extras lives pacman has left

    public Text scoreText;//the Text UI Component that shows the score
    public Image life1;
    public Image life2;

    private Vector2 direction;//the direction pacman is going
    private bool alive = true;

    //References
    private Rigidbody2D rb2d;
    private Animator anim;
	
	private Sprite faceSprite, maskFaceSprite;
	
	SpriteRenderer mySpriteRenderer;
	

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	mySpriteRenderer = GetComponent<SpriteRenderer>();
			Debug.Log(mySpriteRenderer.sprite.name);
		maskFaceSprite =Resources.Load<Sprite>("Sprites/Characters/face_mask");


	}
	
	void FixedUpdate () {
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
        scoreText.text = ""+score;
    }

    public void setAlive(bool isAlive)
    {
        alive = isAlive;
    }

    public void setLivesLeft(int lives)
    {
        livesLeft = lives;
        life1.enabled = livesLeft >= 1;
        life2.enabled = livesLeft >= 2;
    }
}
