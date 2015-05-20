using UnityEngine;
using System.Collections;

public class Do_Epic : MonoBehaviour {

	void Update()
	{
		DoEpic();
		
	}
	
	void DoEpic()
	{
		transform.Translate(-Vector2.right * 1f * Time.deltaTime );
	}
}
