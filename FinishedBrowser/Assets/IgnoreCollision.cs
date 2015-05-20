using UnityEngine;
using System.Collections;

public class IgnoreCollision : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		Physics2D.IgnoreLayerCollision(0,4);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
