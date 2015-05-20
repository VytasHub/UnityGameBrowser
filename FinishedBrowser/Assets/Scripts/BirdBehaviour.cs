using UnityEngine;
using System.Collections;

public class BirdBehaviour : MonoBehaviour {

	Animator anim;
		
	// Use this for initialization
	void Update()
	{
		//OnCollisionEnter();
		BirdBehavior ();

	}
	



	void BirdBehavior()
	{
		transform.Translate(-Vector2.right * 2f * Time.deltaTime );
		transform.Translate(Vector2.up * 3f * Time.deltaTime );
	}

	void Start()
	{
		anim = GetComponent<Animator>();
		
	}
	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.name == "Colectable(Clone)") 
		{
			//anim.SetTrigger ("TouchedByHart");
			//Destroy(col.gameObject);
			//anim.StartPlayback();
			audio.Play ();
			
		}
	}
	

}
