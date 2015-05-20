using UnityEngine;
using System.Collections;

public class Ground0 : MonoBehaviour {

	void Update()
	{
		GroundBehavior();
		
	}
	
	void GroundBehavior()
	{
		transform.Translate(-Vector2.right * 1f * Time.deltaTime );
	}
}
