using UnityEngine;
using System.Collections;

public class Ground1 : MonoBehaviour {

	void Update()
	{
		GroundBehavior();
		
	}
	
	void GroundBehavior()
	{
		transform.Translate(-Vector2.right * 3f * Time.deltaTime );
	}
}
