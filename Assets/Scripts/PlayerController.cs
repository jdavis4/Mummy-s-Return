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

	private Animator anim; // Reference to the animator component.
	private HashIDs hash; // Reference to the HashIDs.
	public float turnSmoothing = 15f;	// A smoothing value for turning the player. <-- lower means slower
	public float speedDampTime = 0.1f;	// The damping for the speed parameter
	public float movementSpeed = 10f;
	public Transform m_Cam;

	public Vector3 oldForward;
	public float m_ForwardAmount;

	void Awake()
	{
		//count = 0;
		//SetCountText();
		//winText.text = "";
		//numberOfGameObjects = GameObject.FindGameObjectsWithTag("PickUp").Length;

		anim = GetComponent <Animator> ();
		hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<HashIDs>();

		m_Cam = Camera.main.transform;
		oldForward = transform.forward;


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
		//Debug.Log("Input.GetAxis(\"Horizontal\"):" + moveHorizontal);
		float moveVertical = Input.GetAxis("Vertical");
		//Debug.Log("Input.GetAxis(\"Vertical\"):" + moveVertical);
		
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); //currently controls movement
		//GetComponent<Rigidbody>().AddForce (movement * speed * Time.deltaTime); //currently controls movement

		//Vector3 m_Mov = moveVertical*m_Cam.forward + moveHorizontal*m_Cam.right;
		//Vector3 m_Mov = moveVertical*transform.forward + moveHorizontal*m_Cam.right;
		Vector3 m_Mov = moveVertical*transform.forward + moveHorizontal*transform.right;
		Vector3 mVel = Move(m_Mov);

		if (oldForward != transform.forward)
			Debug.Log (transform.forward);
		oldForward = transform.forward;

//		if (transform.forward.z < 0)
//			mVel = new Vector3(mVel.x,mVel.y,mVel.z * -1);
	

		if (moveHorizontal != 0f || moveVertical != 0f) {
			// ... set the players rotation and set the speed parameter to 5.5f.
			Rotating(moveHorizontal, moveVertical);
			//anim.SetFloat (hash.speedFloat, 5.5f, speedDampTime, Time.deltaTime);
			anim.SetFloat ("Run", m_ForwardAmount, speedDampTime, Time.deltaTime);
			anim.SetTrigger (hash.runBool);

			//Debug.Log ("mVel: "+mVel);
			this.GetComponent<Rigidbody> ().velocity = mVel;
		} else {
			// Otherwise set the speed parameter to 0.
			//anim.SetFloat (hash.speedFloat, 0);
			anim.SetFloat ("Run", m_ForwardAmount, speedDampTime, Time.deltaTime);
			anim.SetTrigger (hash.idleBool);

			//Debug.Log ("mVel: "+mVel);
			this.GetComponent<Rigidbody> ().velocity = mVel;
		}



		if (Input.GetKeyDown(KeyCode.Space) && !activated) //&& grounded)
		{
			GetComponent<Rigidbody>().AddForce(new Vector3(0f, jumpForce, 0f));
			activated = true;
		}
//		if (Input.GetKeyDown (KeyCode.Space) && win) {
//			Application.LoadLevel ("TestScene");
//		}
	}

	void Rotating (float horizontal, float vertical)
	{
		// Create a new vector of the horizontal and vertical inputs.
		Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);

		// Create a rotation based on this new vector assuming that up is the global y axis.
		Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);

		// Create a rotation that is an increment closer to the target rotation from the player's rotation.
		Quaternion newRotation = Quaternion.Lerp(GetComponent<Rigidbody>().rotation, targetRotation, turnSmoothing * Time.deltaTime);

		// Change the players rotation to this new rotation.
		GetComponent<Rigidbody>().MoveRotation(newRotation);
	}

//	public void Move(Vector3 move, bool crouch, bool jump)
	public Vector3 Move(Vector3 move)
	{

		// convert the world relative moveInput vector into a local-relative
		// turn amount and forward amount required to head in the desired
		// direction.
		if (move.magnitude > 1f) move.Normalize();
		move = transform.InverseTransformDirection(move);
//		CheckGroundStatus();
		//move = Vector3.ProjectOnPlane(move, m_GroundNormal); //orig code line
		move = Vector3.Project(move, this.transform.forward);
		//Debug.Log (move);
//		m_TurnAmount = Mathf.Atan2(move.x, move.z);
		m_ForwardAmount = move.z;

//		ApplyExtraTurnRotation();

//		// control and velocity handling is different when grounded and airborne:
//		if (m_IsGrounded)
//		{
//			HandleGroundedMovement(crouch, jump);
//		}
//		else
//		{
//			HandleAirborneMovement();
//		}
//
//		ScaleCapsuleForCrouching(crouch);
//		PreventStandingInLowHeadroom();
//
//		// send input and other state parameters to the animator
		Vector3 mVelocity = (move*movementSpeed);
		return mVelocity;
	}
	
//	void OnTriggerEnter(Collider other) 
//	{
//		if(other.gameObject.tag == "PickUp")
//		{
//			other.gameObject.SetActive(false);
//			//count = count + 1;
//			//SetCountText();
//		}
//	}
	
//	void SetCountText ()
//	{
//		countText.text = "Count: " + count.ToString();
//		if(count >= numberOfGameObjects)
//		{
//			winText.text = "YOU WIN! Press the space bar to restart. ";
//		}
//	}
}
