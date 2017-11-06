using UnityEngine;
using System.Collections;

public class ChamController : MonoBehaviour
{
	//public string levelToLoad;

	public EnemyHealthManager Cham;
	public bool alive;
	private float time;

	// Use this for initialization
	void Start ()
	{
		this.Cham = FindObjectOfType<EnemyHealthManager> ();
		this.alive = true;
		time = 3;
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
