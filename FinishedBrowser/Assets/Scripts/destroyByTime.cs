using UnityEngine;
using System.Collections;

public class destroyByTime : MonoBehaviour 
{
	public float timeToLife;
	
	
	void Start()
	{
		Destroy (gameObject,timeToLife);
	}
	
	
	
	
}
