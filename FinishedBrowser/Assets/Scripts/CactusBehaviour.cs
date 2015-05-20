using UnityEngine;
using System.Collections;

public class CactusBehaviour : MonoBehaviour 
{
	void Update()
	{
		CactusBehavior();

	}

	void CactusBehavior()
	{
		transform.Translate(-Vector2.right * 2.5f * Time.deltaTime );
	}

}
