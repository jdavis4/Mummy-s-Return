using UnityEngine;
using System.Collections;

public class MiniGameTrigger : MonoBehaviour {

	public string nextScene;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.name == "Player")
			Application.LoadLevel (nextScene);
	}

}
