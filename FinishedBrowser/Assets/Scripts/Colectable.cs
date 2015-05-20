using UnityEngine;
using System.Collections;

public class Colectable : MonoBehaviour 
{

	bool startAnimation = false;

	//TouchedByHart
	Animator anim;
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(-Vector2.right * 2f * Time.deltaTime );

		if(startAnimation ==  true)
		{
			//anim.SetTrigger ("HartTouched");
			//rigidbody2D = false;
			//collider.enabled = false;

			anim.SetTrigger ("TouchedByHart");
			StartCoroutine (InnerTime());
			startAnimation = false;

		}


	
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.name == "Bird(Clone)") {
			//
			startAnimation =  true;
			
		}
		if(playerControl.DestroyBrick ==  true)
		{
			anim.SetTrigger ("HartTouched");

			StartCoroutine ( InnerTimeHart ());
		}
	}


	IEnumerator InnerTime ()
	{

		yield return new WaitForSeconds (0.8f);
		Destroy(gameObject);
	}
	IEnumerator InnerTimeHart ()
	{
		audio.Play();
		yield return new WaitForSeconds (0.6f);
		Destroy(gameObject);
	}







}
