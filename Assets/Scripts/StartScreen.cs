using UnityEngine;
using System.Collections;

public class StartScreen : MonoBehaviour {

	private Animator anim; // Reference to the animator component.
	public string nextScene = "TestScene";

	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator> ();
		anim.SetBool("Stand",true);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			Application.LoadLevel (nextScene);
		}
	}

}
