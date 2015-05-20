using UnityEngine;
using System.Collections;

public class BrickAnimation : MonoBehaviour 
{

	Animator anim;
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () 
	{

		if(playerControl.DestroyBrick == true)
		{
			//GameObject BrickWall = (GameObject)GameObject.Find("Brick5(Clone)");
			//anim.SetTrigger ("BrickExplosion");
			print ("Brick Explosion Script");

			//playerControl.DestroyBrick = false;
			//BrickExplosion
			//Destr(BrickWall.);
			//Destroy (BrickWall);
		}
	
	}
}
