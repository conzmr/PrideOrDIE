using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour
{
	public string levelToLoad;
	public int currentMaxLevel;
	public int levelNum;
	public int unlockLevel;
	private bool playerInZone;

	// Use this for initialization
	void Start ()
	{
		playerInZone = false;
		this.currentMaxLevel = PlayerPrefs.GetInt ("CurrentMaxLevel");
	}
	
	// Update is called once per frame
	void Update ()
	{
 
		if (Input.GetAxisRaw ("Vertical") > 0 && this.playerInZone && (this.levelNum <= this.currentMaxLevel)) {
			if (this.unlockLevel>this.currentMaxLevel) {
				this.currentMaxLevel = this.unlockLevel;
				PlayerPrefs.SetInt ("CurrentMaxLevel", this.currentMaxLevel);
			}
			print ("current max level " + currentMaxLevel);
			print ("levelNum " + this.levelNum);
			print ( (this.levelNum <= this.currentMaxLevel));
			Application.LoadLevel (this.levelToLoad);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player") {
			this.playerInZone = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.name == "Player") {
			this.playerInZone = false;
		}
	}
}
