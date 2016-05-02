using UnityEngine;
using System.Collections;

public class MiniGameTrigger : MonoBehaviour {

	public string nextScene;

	// Use this for initialization
	void Start () {
		if (nextScene == "" || nextScene == null)
			GetComponent<BoxCollider> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
//		Debug.Log ("minigame trigger entered: " + this.name);
//		Debug.Log (other + "entered trigger zone");
		if (other.tag == "Player") {
			Debug.Log ("player touched minigame trigger");
			Application.LoadLevel (nextScene);
		}
	}

}
