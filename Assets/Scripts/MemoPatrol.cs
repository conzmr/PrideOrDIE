using UnityEngine;
using System.Collections;

public class MemoPatrol : MonoBehaviour
{

	public float moveSpeed;
	public bool moveRight;
	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatIsWall;
	//public Transform edgeCheck;

	public PlayerController player;
	public EnemyChamController Cham;
	private new Rigidbody2D rigidbody2D;
	private bool hittingWall;
	//private bool notAtEdge;
	public float tiempo;
	public int hp;
	private bool cambioSpeed;
	// Use this for initialization
	void Start ()
	{
		this.rigidbody2D = GetComponent<Rigidbody2D> ();
		this.Cham = FindObjectOfType<EnemyChamController> ();
		this.player = FindObjectOfType<PlayerController> ();
		this.hp = this.Cham.enemyHealth;
		this.cambioSpeed = false;
		tiempo = 3;
	}

	// Update is called once per frame
	void Update ()
	{	
		this.hp = this.Cham.enemyHealth;
		tiempo -= Time.deltaTime;
		if (tiempo <= 0) {
			this.Jump ();
			tiempo = 4;
			if (this.hp <= 80) {
				tiempo = 2;
			}

		}

		if (this.player.transform.position.x < transform.position.x && this.moveRight == true && this.player.transform.position.x < transform.position.x - 5) {
			this.moveRight = !this.moveRight;
		}

		if (this.player.transform.position.x > transform.position.x && this.moveRight == false && this.player.transform.position.x > transform.position.x + 5) {
			this.moveRight = !this.moveRight;
		}

		//if (transform.localScale.x > 0 && this.player.transform.position.x < transform.position.x && this.player.transform.position.x < transform.position.x - 5) {
		//	this.moveRight = !this.moveRight;
		//}

		if (this.hp == 50 && this.cambioSpeed == false) {
			this.moveSpeed += 2;
			this.cambioSpeed = true;
		}
		this.hittingWall = Physics2D.OverlapCircle (this.wallCheck.position, this.wallCheckRadius, this.whatIsWall);
		//this.notAtEdge = !Physics2D.OverlapCircle (this.edgeCheck.position, this.wallCheckRadius, this.whatIsWall);

		if (this.hittingWall ) {
			this.moveRight = !this.moveRight;
		}

		if (this.moveRight) {
			transform.localScale = new Vector3 (-0.75f, .9f, 1f);
			this.rigidbody2D.velocity = new Vector2 (moveSpeed, this.rigidbody2D.velocity.y);
		} else {
			transform.localScale = new Vector3 (0.75f, .9f, 1f);
			this.rigidbody2D.velocity = new Vector2 (-moveSpeed, this.rigidbody2D.velocity.y);
		}
	}

	public void Jump()
	{
		//this.notAtEdge = false;
		this.rigidbody2D.velocity = new Vector2(this.rigidbody2D.velocity.x, 5);
		//this.notAtEdge = false;
	}
}
