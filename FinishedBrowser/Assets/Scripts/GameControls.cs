using UnityEngine;
using System.Collections;



public class GameControls : MonoBehaviour {
	public GameObject Top;
	public GameObject Hills;
	public GameObject cactus;
	public GameObject Ground;
	public GameObject Ground1;
	public GameObject Ground2;
	public GameObject Colectable;
	public GameObject BrickWall;
	//public GameObject CatHills;
	public GameObject FreeYourMind;
	public GameObject GetLucky;
	public GameObject HakunaMatata;
	public GameObject LifeGood;
	public GameObject StayWild;
	public GameObject TodayIsTheDay;
	public GameObject WanderLust;
	public GameObject Bird;
	public GameObject Controls;
	public GameObject Cat;
	public int[] BrickDestructionArray = new int[552] ;

	//public GameObject[] Bricks;
	public  GUIText ScoreText;
	private int LocalScore;
	Animator anim;

	//public float cactusSpawn;



	void Populate()
	{
		for(int i = 0; i<=550; i++)
		{
			BrickDestructionArray[i] = i;
		}

		for (int i = BrickDestructionArray.Length-1; i > 0; i--)
		{
			// Randomize a number between 0 and i (so that the range decreases each time)
			int rnd = Random.Range(0,i);
			
			// Save the value of the current i, otherwise it'll overright when we swap the values
			int temp = BrickDestructionArray[i];
			
			// Swap the new and old values
			BrickDestructionArray[i] = BrickDestructionArray[rnd];
			BrickDestructionArray[rnd] = temp;
		}
		for(int i = 0; i<=550; i++)
		{
			print(BrickDestructionArray[i]);
		}
	}



	void Update()
	{
		ScoreCountMethod ();
		ControlsDisplay ();

		//BrickDestruction ();
		//DestroyRedBrick ();

		//print (Bricks);
		//Destroy(Brick.gameObject);


	}

	void ControlsDisplay()
	{
		if(playerControl.ScoreCount == 3)
		{


				
			Controls.active = false;
			//print ("Loop Reached");
		}
	}

	void ScoreCountMethod()
	{

		ScoreText.text = "Score: "+playerControl.ScoreCount;

	}




	public void Start ()
	{
		Populate ();


		anim = GetComponent<Animator>();
		StartCoroutine (SpawnCactus ());
		SpawnIntialTop ();
		StartCoroutine (SpawnBrickWall());
		StartCoroutine (SpawnTop());

		StartCoroutine (SpawnColectable());
		StartCoroutine (SpawnGround1());

		StartCoroutine (Ground2Wait ());
		StartCoroutine (Ground2Colectable ());

		StartCoroutine (Ground3Wait ());
		StartCoroutine (Ground3Colectable ());


		StartCoroutine (SpawnKillerBirds());



		StartCoroutine (SpawnKillerCats ());


		playerControl.DestroyBrick = false;


	}





	void SpawnIntialTop()
	{
		float x = -8.4f;
		float y = 6.1f;
		
		Vector2 spawnLocationIntial = new Vector2 (x,y);
		Quaternion spawnQ = Quaternion.identity;
		Instantiate (Top,spawnLocationIntial,spawnQ);
	}



	IEnumerator SpawnCloudText()
	{

		Object[] CloudArray = new Object[] { FreeYourMind, GetLucky, HakunaMatata, LifeGood, StayWild, TodayIsTheDay, WanderLust };
		float x = 14.7f;
		float y = 2f;

		//Object test = FreeYourMind;

		while (true)
		{
			int range = Random.Range (0,6);
			Object choosenObj = CloudArray[range];

			Vector2 spawnLocation = new Vector2 (x,y);
			Quaternion spawnQ = Quaternion.identity;
			Instantiate (choosenObj,spawnLocation,spawnQ);
			

			
			yield return new WaitForSeconds (7f);
		}

	}

	IEnumerator SpawnTop()
	{
		

		float x = 10.75f;
		float y = 5.35f;
		
		//Object test = FreeYourMind;
		
		while (true)
		{

			
			Vector2 spawnLocation = new Vector2 (x,y);
			Quaternion spawnQ = Quaternion.identity;
			Instantiate (Hills,spawnLocation,spawnQ);
			
			
			
			yield return new WaitForSeconds (3.45f);
		}
		//x5.7
		//y-2.0
	}
	//Hills
	IEnumerator SpawnBirds ()
	{
		float x = 8.9f;
		float y = 2.875f;
		//float range;
		
		while (true)
		{
			
			Vector2 spawnLocation = new Vector2 (x,y);
			Quaternion spawnQ = Quaternion.identity;
			Instantiate (Bird,spawnLocation,spawnQ);
			

			
			yield return new WaitForSeconds (3.48f);
		}
		//x5.7
		//y-2.0
	}

	IEnumerator SpawnCactus ()
	{
		float x = 8.7f;
		float y = -3.7f;
		float range;

			while (true)
			{
		
				Vector2 spawnLocation = new Vector2 (x,y);
				Quaternion spawnQ = Quaternion.identity;
				Instantiate (cactus,spawnLocation,spawnQ);

				range = Random.Range (3f,7f);

			yield return new WaitForSeconds (range);
			}
		//x5.7
		//y-2.0
	}

	IEnumerator SpawnGround1()
	{
		float x = 13.0f;
		float y = -4.8f;
		//float range;
		
		while (true)
		{
			
			Vector2 spawnLocation = new Vector2 (x,y);
			Quaternion spawnQ = Quaternion.identity;
			Instantiate (Ground,spawnLocation,spawnQ);
			
			//range = Random.Range (1f,4f);
			
			yield return new WaitForSeconds (0.5f);
		}
		//x5.7
		//y-2.0
	}

	IEnumerator SpawnGround2()
	{
		float x = 13.0f;
		float y = -2.8f;
		//float range;
		
		while (true)
		{
			
			Vector2 spawnLocation = new Vector2 (x,y);
			Quaternion spawnQ = Quaternion.identity;
			Instantiate (Ground1,spawnLocation,spawnQ);
			
			//range = Random.Range (1f,4f);
			
			yield return new WaitForSeconds (4f);
		}
		//x5.7
		//y-2.0
	}
	IEnumerator SpawnGround3()
	{
		float x = 13.0f;
		float y = -0.5f;
		//float range;
		
		while (true)
		{
			
			Vector2 spawnLocation = new Vector2 (x,y);
			Quaternion spawnQ = Quaternion.identity;
			Instantiate (Ground2,spawnLocation,spawnQ);
			
			//range = Random.Range (1f,4f);
			
			yield return new WaitForSeconds (7f);
		}
		//x5.7
		//y-2.0
	}
	IEnumerator SpawnColectable()
	{
		float x = 13.0f;
		float location = -3.75f;
		//float y = -4.5f;
		//float range;
		
		while (true)
		{


			//location = Random.Range (-3.7f,5f);
			Vector2 spawnLocation = new Vector2 (x,location);
			Quaternion spawnQ = Quaternion.identity;
			Instantiate (Colectable,spawnLocation,spawnQ);
			
			float range = Random.Range (4.0f,5.0f);
			
			yield return new WaitForSeconds (range);
		}
		//x5.7
		//y-2.0
	}
	IEnumerator SpawnColectableGround2()
	{
		float x = 13.0f;
		float location = -1.75f;
		//float y = -4.5f;
		//float range;
		
		while (true)
		{
			
			
			//location = Random.Range (-3.7f,5f);
			Vector2 spawnLocation = new Vector2 (x,location);
			Quaternion spawnQ = Quaternion.identity;
			Instantiate (Colectable,spawnLocation,spawnQ);
			
			float range = Random.Range (3.0f,4.0f);
			
			yield return new WaitForSeconds (range);
		}
		//x5.7
		//y-2.0
	}

	IEnumerator SpawnColectableGround3()
	{
		float x = 13.0f;
		float location = 2.0f;
		//float y = -4.5f;
		//float range;
		
		while (true)
		{
			
			
			//location = Random.Range (-3.7f,5f);
			Vector2 spawnLocation = new Vector2 (x,location);
			Quaternion spawnQ = Quaternion.identity;
			Instantiate (Colectable,spawnLocation,spawnQ);
			
			float range = Random.Range (2.0f,3.0f);
			
			yield return new WaitForSeconds (range);
		}
		//x5.7
		//y-2.0
	}

	IEnumerator SpawnCats ()
	{
		float y = 8.0f;
		float location = 2.0f;
		//float y = -4.5f;
		//float range;
		
		while (true)
		{
			
			
			location = Random.Range (-2.7f,6f);
			Vector2 spawnLocation = new Vector2 (location,y);
			Quaternion spawnQ = Quaternion.identity;
			Instantiate (Cat,spawnLocation,spawnQ);
			
			float range = Random.Range (2.0f,3.0f);
			
			yield return new WaitForSeconds (range);
		}
		//x5.7
		//y-2.0
	}

	IEnumerator SpawnBrickWall()
	{
		float x = -8.18f;
		float y = -4.4f;
		int xLenght = 18;
		int counting = 0;
		// BrickCounting = 0;
		//GameObject[] BrickList = new GameObject[510] ;
		//float y = -4.5f;
		//float range;
		
		for(int i = 1; i<=xLenght; i++)
		{
			
			

			Vector2 spawnLocation = new Vector2 (x,y);
			Quaternion spawnQ = Quaternion.identity;
			Instantiate (BrickWall,spawnLocation,spawnQ);

			counting++;

			BrickWall.name = "Brick" + BrickDestructionArray[counting];
			//print (BrickWall.name.ToString());
			//BrickWall.



			x = x +0.95f;
		
			//print (BrickArray[BrickCounting]);
			if(i==18)
			{
				i = -1;
				x = -8.18f;
				y = y + 0.35f;

			}
			else if(y>5.45f)
			{
				i = 42;
			}

			//range = Random.Range (1f,4f);
			yield return new WaitForSeconds (0.001f);
		}
		//x5.7
		//y-2.0
	}

	IEnumerator Ground2Wait ()
	{
		
		yield return new WaitForSeconds (5f);
		StartCoroutine (SpawnGround2());
		
	}

	IEnumerator Ground3Wait ()
	{
		
		yield return new WaitForSeconds (10f);
		StartCoroutine (SpawnGround3());
		
	}

	IEnumerator Ground2Colectable ()
	{
		
		yield return new WaitForSeconds (10f);
		StartCoroutine (SpawnColectableGround2());
		
	}

	IEnumerator Ground3Colectable ()
	{
		
		yield return new WaitForSeconds (15f);
		StartCoroutine (SpawnColectableGround3());
		
	}

	IEnumerator SpawnKillerBirds ()
	{
		
		yield return new WaitForSeconds (15f);
		StartCoroutine (SpawnBirds ());
		
	}

	IEnumerator SpawnKillerCats ()
	{
		
		yield return new WaitForSeconds (20f);
		StartCoroutine (SpawnCats ());
		
	}





}
