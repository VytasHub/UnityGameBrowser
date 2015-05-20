using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (playerControl.playerDead == true) 
		{
			print ("DeathSound");
			audio.Play();

		}
	}
}
