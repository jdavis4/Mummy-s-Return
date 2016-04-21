using UnityEngine;
using System.Collections;

public class CameraControllerOrig : MonoBehaviour 

{
	public GameObject player;
	private Vector3 offset;
	public float offsetTest = 2f;
	// Use this for initialization
	void Start () {
		offset = transform.position;
		player = GameObject.FindWithTag ("Player");
	}

	// Update is called once per frame
	void LateUpdate () {
		//transform.position = player.transform.position + offset;
		transform.position = new Vector3((player.transform.position.x), player.transform.position.y+offsetTest, (player.transform.position.z-offsetTest*2)) ;
	}
}
