using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	private Animator anim; // Reference to the animator component.
	private HashIDs hash; // Reference to the HashIDs.
	private Rigidbody rb; //rigidbody of player

	public GameObject healthBar;
	private float healthBarY,healthBarX,healthBarZ,healthLoss;

	public float health = 30f;
	private bool dead = false;

	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator> ();
		hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<HashIDs>();
		rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();

		healthBar = GameObject.Find ("HealthBar");
		healthBarY = healthBar.transform.localScale.y;
		healthBarX = healthBar.transform.localScale.x;
		healthBarZ = healthBar.transform.localScale.z;
//		Debug.Log (healthBar.transform.localScale);
//		Debug.Log (healthBarX);
		healthLoss = healthBarY/health;
		Debug.Log(new Vector3 (healthBarX, (healthBarY - healthLoss), healthBarZ));

	}
	
	// Update is called once per frame
	void FixedUpdate () {
//		health = health - Time.fixedDeltaTime;
//		StartCoroutine (UpdateHealth (healthLoss)); //healthBar.transform.localScale = new Vector3 (healthBarX, (healthBarY - healthLoss), healthBarZ);
		//Debug.Log ("healthBar.transform.localScale: "+healthBar.transform.localScale); 

		if (health > 0 && !dead) {
			health = health - Time.fixedDeltaTime;
			StartCoroutine (UpdateHealth (healthLoss*Time.fixedDeltaTime)); //healthBar.transform.localScale = new Vector3 (healthBarX, (healthBarY - healthLoss), healthBarZ);
			//Debug.Log ("healthBar.transform.localScale: "+healthBar.transform.localScale); 
			Debug.Log("dying");
		} else if (health <= 0 && !dead) {
			anim.SetTrigger (hash.dieBool);
			rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
			StopCoroutine (UpdateHealth (healthLoss));

			rb.Sleep ();
			//Destroy(rb);

			dead = true;
			Debug.Log ("should be dead");
		} else if (health <= -3 && dead) {
//			rb.Sleep ();
			anim.enabled = false;
			Debug.Log ("really dead");
		} else {
		//do nothing 
		}
	}

	IEnumerator UpdateHealth(float hLoss) {
		float newHealthBarY = (healthBarY - hLoss);
		Debug.Log (newHealthBarY);
		healthBar.transform.localScale = new Vector3 (healthBarX, newHealthBarY , healthBarZ);
		healthBarY = newHealthBarY;
		//Debug.Log ("Health Bar should be shrinking");
		yield return new WaitForFixedUpdate(); 
	}

}
