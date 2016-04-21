using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	SphereCollider sphereCollider;
	public int visionRange = 3;
	public float speed;

	// Use this for initialization
	void Start () {

		sphereCollider = gameObject.GetComponent<SphereCollider> ();
		sphereCollider.radius = visionRange;

	}

	// Update is called once per frame
	void Update () {
		if ( (sphereCollider.radius != visionRange) ) { // || lt.range != visionRange) {
			sphereCollider.radius = visionRange;
		}

	}

	void FixedUpdate() {

	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject.tag == "Player") {
			GetComponent<Rigidbody>().AddForce ((other.transform.position-gameObject.transform.position)*speed);
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.name == "Player") {
			GetComponent<Rigidbody> ().velocity = Vector3.zero; 
 		}
	}

	void OnCollisionEnter(Collision collision) { 
		if (collision.gameObject.transform.name == "Player") {
			Application.LoadLevel ("MiniGame");
		}

	}
}
