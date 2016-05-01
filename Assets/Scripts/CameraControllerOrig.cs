using UnityEngine;
using System.Collections;

public class CameraControllerOrig : MonoBehaviour 

{
	public GameObject player;
	//private Vector3 offset;
	public float offsetTest = 2f;

	public float turnSmoothing = 2f;	// A smoothing value for turning the player.

	// Use this for initialization
	void Start () {
		//offset = transform.position;
		player = GameObject.FindGameObjectWithTag ("Player");
		//Debug.Log (player);
		//Debug.Log (player.transform.position);
	}

	// Update is called once per frame
	void LateUpdate () {
		//transform.position = player.transform.position + offset;
		this.transform.position = new Vector3((player.transform.position.x), player.transform.position.y+offsetTest, (player.transform.position.z-offsetTest*2)) ;

//		Quaternion targetRotation = Quaternion.LookRotation(player.transform.forward, Vector3.up);
//		Quaternion newRotation = Quaternion.Lerp(this.transform.rotation, targetRotation, turnSmoothing * Time.deltaTime);
//		this.transform.rotation = newRotation;
	}
}
