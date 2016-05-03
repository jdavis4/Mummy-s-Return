using UnityEngine;
using System.Collections;

public class AutoLight : MonoBehaviour {

	public Light lt;
	public SphereCollider sphereCollider;
	public float triggerRange = 6.5f;

	// Use this for initialization
	void Start () {
		lt = gameObject.GetComponent<Light>();

		sphereCollider = gameObject.GetComponent<SphereCollider> ();
		sphereCollider.radius = triggerRange;

		lt.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			//Debug.Log ("player is triggering light");
			lt.enabled = true;
		}
	}

}
