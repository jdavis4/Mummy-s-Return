using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{	
	public float speed;
	//public GUIText countText;
	//public GUIText winText;
	//private int count;
	//private int numberOfGameObjects;

	private float jumpForce = 500f;
	private bool activated = false;
	public float timeSince = 0;

	private bool win = false;
	
	void Start()
	{
		//count = 0;
		//SetCountText();
		//winText.text = "";
		//numberOfGameObjects = GameObject.FindGameObjectsWithTag("PickUp").Length;

	}

	void Update () {
		//Debug.Log (timeSince);
		CheckActivated ();
	
//		if (gameObject.transform.position.y <= 0) {
//			winText.text = "You've jumped to your death! Restarting level...";
//		} 
		if (gameObject.transform.position.y <= -10) {
			Application.LoadLevel ("TestScene");
		}
	
//		if (winText.text == "YOU WIN! Press the space bar to restart. ") 
//			win = true;

	}

	void CheckActivated() {
		if (activated) {
			if (timeSince > 3) {
				activated = false;
				timeSince = 0;
			} else {
				timeSince += Time.deltaTime;
			}
		}
	}
	
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		GetComponent<Rigidbody>().AddForce (movement * speed * Time.deltaTime);


		if (Input.GetKeyDown(KeyCode.Space) && !activated) //&& grounded)
		{
			GetComponent<Rigidbody>().AddForce(new Vector3(0f, jumpForce, 0f));
			activated = true;
		}

		if (Input.GetKeyDown (KeyCode.Space) && win) {
			Application.LoadLevel ("TestScene");
		}
	}
	
	void OnTriggerEnter(Collider other) 
	{
//		if(other.gameObject.tag == "PickUp")
//		{
//			other.gameObject.SetActive(false);
//			//count = count + 1;
//			//SetCountText();
//		}
	}
	
//	void SetCountText ()
//	{
//		countText.text = "Count: " + count.ToString();
//		if(count >= numberOfGameObjects)
//		{
//			winText.text = "YOU WIN! Press the space bar to restart. ";
//		}
//	}
}
