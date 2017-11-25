using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MendezController : MonoBehaviour 
{
	//public string levelToLoad;

	public EnemyMendezController Mendez;
	public bool alive;
	private float time;

	// Use this for initialization
	void Start ()
	{
		this.Mendez = FindObjectOfType<EnemyMendezController> ();
		this.alive = true;
		time = 2;
	}

	// Update is called once per frame
	void Update ()
	{

		if (this.alive == false) {
			time -= Time.deltaTime;
			if (time <= 0) {
				Application.LoadLevel ("Level Select");
			}
		}
	}

}
