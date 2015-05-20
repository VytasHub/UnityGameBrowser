using UnityEngine;
using System.Collections;

public class BrickDestruction : MonoBehaviour 
{
	Animator anim;
	string BrickName1 = "Brick";
	string BrickName2 = "(Clone)";
	string BrickFullName = "";


	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () 
	{

		//var x = gameObject.Br.x;
		//var z = target1.position.z;



		if(playerControl.DestroyBrick == true)
		{
			//Destroy (gameObject);
			//Destroy (GameControls.BrickArray[5]); 
			//print (BrickWall.name+counting);
			BrickFullName = BrickName1 + playerControl.ScoreCount + BrickName2;
			//Destroy (newObject);
			if(gameObject.name == BrickFullName)
			{
			//print("MSG SENT ---->" + gameObject.name.ToString() );
			anim.SetTrigger ("BrickExplosion");

			
				print (BrickFullName);

			StartCoroutine (InnerTime());
			playerControl.DestroyBrick = false;
			}
		}
	}


	IEnumerator InnerTime ()
	{
		
		yield return new WaitForSeconds (0.5f);
		Destroy(gameObject);

	}

}





















