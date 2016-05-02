using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	private Animator anim; // Reference to the animator component.
	private Rigidbody rb; //rigidbody of player
	public Text healthText;

	public GameObject healthBar;
	private float healthBarY,healthBarX,healthBarZ,healthLoss;

	public float health = 30f; //starting health
	private bool dead = false;

	private float timer = 0; //timer until level restart

	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator> ();
		rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();

		healthBar = GameObject.Find ("HealthBar");
		healthBarY = healthBar.transform.localScale.y;
		healthBarX = healthBar.transform.localScale.x;
		healthBarZ = healthBar.transform.localScale.z;
		healthLoss = healthBarY/(health-1);

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (dead && timer < 4 ) {
			timer += Time.fixedDeltaTime;
			//Debug.Log (timer);
		} else if (dead && (timer > 4) ) {
			Debug.Log ("restarting level");
			Application.LoadLevel("TestScene");
		} else if (health > 0.75 && !dead) {
			health = health - Time.fixedDeltaTime;
			StartCoroutine (UpdateHealth (healthLoss*Time.fixedDeltaTime)); 
			UpdateHealthText ();
			//Debug.Log("dying");
		} else if (health < 0.75 && !dead) {
			anim.SetBool("Dead",true);

			rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
			StopCoroutine (UpdateHealth (healthLoss));

			rb.Sleep ();
			//Destroy(rb);

			dead = true;
			healthText.text = "You're out of oxygen! GAME OVER";
			Debug.Log ("you died (lost all health/ran out of oxygen)");
		} else {
		//do nothing 
		}
	}

	IEnumerator UpdateHealth(float hLoss) {
		float newHealthBarY = (healthBarY - hLoss);
		if (newHealthBarY > 0)
			healthBar.transform.localScale = new Vector3 (healthBarX, newHealthBarY , healthBarZ);
		else 
			healthBar.transform.localScale = new Vector3 (healthBarX, 0, healthBarZ);
		healthBarY = newHealthBarY;
		//Debug.Log ("Health Bar should be shrinking");
		yield return new WaitForFixedUpdate(); 
	}

	void UpdateHealthText() {
		float min = Mathf.Floor (health / 60f);
		int sec = (int) health % 60;

		if (sec < 10)
			healthText.text = "Remaining Oxygen: " + min + ":0" + sec;
		else
			healthText.text = "Remaining Oxygen: " + min + ":" + sec;
		//Debug.Log (healthText.text);
	}
}
