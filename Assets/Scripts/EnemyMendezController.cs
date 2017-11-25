using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMendezController : MonoBehaviour 
{
	public int enemyHealth;
	public GameObject deathEffect;
	public int pointsOnDeath;
	public MendezController mendez;

	private AudioSource audio;

	// Use this for initialization
	void Start ()
	{
		this.audio = GetComponent<AudioSource> ();
		mendez = FindObjectOfType<MendezController> ();
	}

	// Update is called once per frame
	void Update ()
	{
		if (enemyHealth <= 0) {
			Instantiate (this.deathEffect, transform.position, transform.rotation);
			ScoreManager.AddPoints(this.pointsOnDeath);
			mendez.alive = false;
			Destroy (gameObject);
		}
	}

	public void giveDamage (int damageToGive)
	{
		this.enemyHealth -= damageToGive;
		this.audio.Play ();
	}
}
