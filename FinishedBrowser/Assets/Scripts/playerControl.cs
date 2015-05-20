using UnityEngine;
using System.Collections;

public class playerControl : MonoBehaviour 
{
	public AudioSource[] sounds;
	public AudioSource Jump;
	public AudioSource Death;

	public bool touchingGround = false;
	public bool touchingGround1 = false;
	public Transform lStart,lEnd;
	public GameObject Colectable;

	Animator anim;
	private int forceAppliesToJump = 700;
	private int rightLeftMovment = 3;

	public static int  ScoreCount  = 0;
	public static bool DestroyBrick = false;
	public static bool playerDead  = false;





	void Start()
	{
		anim = GetComponent<Animator>();
		//StartCoroutine (InnerTime());
		playerControl.ScoreCount = 0;
	}
	void OnCollisionEnter2D (Collision2D col)
	{
		if(col.gameObject.name == "cactus(Clone)")
		{
			//Destroy(gameObject);
			
			anim.SetTrigger ("PlayerHit");
			forceAppliesToJump = 1;
			StartCoroutine (InnerTime());
			rightLeftMovment = 0;
			//Application.LoadLevel ("MenuSystem");
			
			
			//touchingGround = false;
			
		}
		
		else if(col.gameObject.name == "Colectable(Clone)")
		{
		
			//Destroy(col.gameObject);
			ScoreCount++;

			DestroyBrick = true;
			
			
		}
		else if(col.gameObject.name == "Hills(Clone)" || col.gameObject.name == "Top(Clone)" || col.gameObject.name == "Hills" || col.gameObject.name == "Cat(Clone)" || col.gameObject.name == "Bird(Clone)")
		{
			//Destroy(gameObject);
			playerDead = true;
			anim.SetTrigger ("PlayerHit");
			forceAppliesToJump = 1;
			StartCoroutine (InnerTime());
			rightLeftMovment = 0;


			
		}
		
	}



	public void ChangeToScene (string sceneToChangeTo)
	{
		Application.LoadLevel (sceneToChangeTo);
		
	}

	void Update()
	{
		Movement();
		castRays ();
		//transform.Translate(Vector2.right * 3f * Time.deltaTime );
		Physics2D.IgnoreLayerCollision(4,0);

	}

	void castRays()
	{
		Debug.DrawLine (lStart.position,lEnd.position,Color.red);

		touchingGround = Physics2D.Linecast (lStart.position, lEnd.position, 1 << LayerMask.NameToLayer ("Ground")); 

		//touchingGround1 = Physics2D.Linecast (lStart.position, lEnd.position, 1 << LayerMask.NameToLayer ("Ground1")); 
	}
	
	
	

	void Movement()
	{

		//Vector2 movement = new Vector2(Input.acceleration.x,0.0f);
		//rigidbody2D.velocity = movement*6;

		//if (Input.touchCount > 0) 
		//{
			// code here for what you want to do when screen is touched
		//}



		anim.SetFloat ("verticalMovment", Mathf.Abs (Input.GetAxis ("Vertical")));


		if(Input.GetKey(KeyCode.D))
		{
			transform.Translate(Vector2.right * rightLeftMovment * Time.deltaTime );
		}
		if(Input.GetKey(KeyCode.A))
		{
			transform.Translate(-Vector2.right * rightLeftMovment * Time.deltaTime );
		}
		if(Input.GetKey (KeyCode.W )&& touchingGround == true  )
		{


			rigidbody2D.AddForce (Vector2.up * forceAppliesToJump);

			Vector2 v2 = rigidbody2D.velocity;
			v2.y = 0;
			rigidbody2D.velocity = v2;
			audio.Play();

			//print (forceAppliesToJump );
		}

	}


		


	IEnumerator InnerTime ()
	{
		PlayerPrefs.SetInt ("lastScore", playerControl.ScoreCount);



		if(playerControl.ScoreCount > PlayerPrefs.GetInt("highScore")){
			PlayerPrefs.SetInt ("highScore", playerControl.ScoreCount);
		}


		yield return new WaitForSeconds (3);
		Application.LoadLevel ("MenuSystem");
	}
	IEnumerator HartTime ()
	{

		yield return new WaitForSeconds (0.8f);


	}

}
