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
		Debug.Log ("minigame trigger entered: " + this.name);
		if (other.name == "Player") {
			Debug.Log ("player touched minigame trigger");
			Application.LoadLevel (nextScene);
		}
	}

}
