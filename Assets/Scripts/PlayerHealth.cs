using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	private Animator anim; // Reference to the animator component.
	private HashIDs hash; // Reference to the HashIDs.
	private Rigidbody rb; //rigidbody of player

	public GameObject healthBar;
	private float healthBarY,healthBarX,healthBarZ,healthLoss;

	public float health = 30f; //starting health
	private bool dead = false;


	private float timer = 0; //timer until level restart
	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator> ();
		hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<HashIDs>();
		rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();

		healthBar = GameObject.Find ("HealthBar");
		healthBarY = healthBar.transform.localScale.y;
		healthBarX = healthBar.transform.localScale.x;
		healthBarZ = healthBar.transform.localScale.z;
		healthLoss = healthBarY/health;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Code from Morten
//		if (Input.anyKey) {
//			GetComponent<Animator> ().SetBool ("dead", true);
//			Debug.Log ("set dead to true");
//		}

		if (dead && timer < 3 ) {
			timer += Time.fixedDeltaTime;
			Debug.Log (timer);
		} else if (dead && (timer > 3) ) {
			Debug.Log ("restarting level");
			Application.LoadLevel("TestScene");
		} else if (health > 0 && !dead) {
			health = health - Time.fixedDeltaTime;
			StartCoroutine (UpdateHealth (healthLoss*Time.fixedDeltaTime)); 
			//Debug.Log("dying");
		} else if (health <= 0 && !dead) {
			anim.SetBool("Dead",true);

			rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
			StopCoroutine (UpdateHealth (healthLoss));

			rb.Sleep ();
			//Destroy(rb);

			dead = true;
			Debug.Log ("you died (lost all health/ran out of oxygen)");
		} else {
		//do nothing 
		}
	}

	IEnumerator UpdateHealth(float hLoss) {
		float newHealthBarY = (healthBarY - hLoss);
		healthBar.transform.localScale = new Vector3 (healthBarX, newHealthBarY , healthBarZ);
		healthBarY = newHealthBarY;
		//Debug.Log ("Health Bar should be shrinking");
		yield return new WaitForFixedUpdate(); 
	}

}
