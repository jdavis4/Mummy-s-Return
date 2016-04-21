using UnityEngine;
using System.Collections;

public class AutoLight : MonoBehaviour {

	public Light lt;
	public SphereCollider sphereCollider;
	public float triggerRange = 6.5f;

	// Use this for initialization
	void Start () {
		lt = gameObject.GetComponent<Light>();
		Debug.Log (lt.enabled);
		//lt.range = lightRange;

		sphereCollider = gameObject.GetComponent<SphereCollider> ();
		sphereCollider.radius = triggerRange;

		lt.enabled = false;
		Debug.Log (lt.enabled);

	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log (lt.enabled);
//		if ( (sphereCollider.radius != lightRange) || lt.range != lightRange) {
//			sphereCollider.radius = lightRange;
//			lt.range = lightRange;
//		}
			
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			//Debug.Log ("player is triggering light");
			lt.enabled = true;

		}
	}

	void OnTriggerExit(Collider other) {
		//if (other.name == "Player")
			//lt.enabled = false; //turn light off when players exits trigger
	}
}
