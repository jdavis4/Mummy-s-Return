using UnityEngine;
using System.Collections;

public class Story : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			Debug.Log ("Que Story or starter instructions!");
			Destroy (this.gameObject);
		}
	}

}
