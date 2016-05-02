using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{	
	public float speed;

	private Animator anim; // Reference to the animator component.
	public float turnSmoothing = 15f;	// A smoothing value for turning the player. <-- lower means slower
	public float speedDampTime = 0.1f;	// The damping for the speed parameter
	public float movementSpeed = 10f;
	public Transform m_Cam;


	public float m_ForwardAmount;

	void Awake()
	{
		anim = GetComponent <Animator> ();
		m_Cam = Camera.main.transform;
	}
		
	
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		//Debug.Log("Input.GetAxis(\"Horizontal\"):" + moveHorizontal);
		float moveVertical = Input.GetAxis("Vertical");
		//Debug.Log("Input.GetAxis(\"Vertical\"):" + moveVertical);

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); //currently controls movement

		if (moveHorizontal != 0.0f) {
			float rotationSpeed = 1.5f;
			// rotate player 
			GetComponent<Rigidbody> ().rotation = GetComponent<Rigidbody> ().rotation * Quaternion.Euler (0, moveHorizontal * rotationSpeed, 0);
		}

		Vector3 m_Mov = moveVertical*transform.forward + moveHorizontal*transform.right;
		Vector3 mVel = Move(m_Mov);
		

		if (moveHorizontal != 0f || moveVertical != 0f) {
			anim.SetBool ("Move", true);
			anim.SetBool ("Stand", false);

			this.GetComponent<Rigidbody> ().velocity = mVel;
		} else {
			anim.SetBool("Move",false);
			anim.SetBool("Stand",true);

			this.GetComponent<Rigidbody> ().velocity = mVel;
		}
			

	}
		

	public Vector3 Move(Vector3 move) //Ethan code. Mostly commented out stuff, but there have been some changes as well.
	{
		// convert the world relative moveInput vector into a local-relative
		// turn amount and forward amount required to head in the desired
		// direction.
		if (move.magnitude > 1f) move.Normalize();
		//move = transform.InverseTransformDirection(move); //when this line is commented out the desired movement mechanics are used up until the first turn in the maze
		//move = Vector3.ProjectOnPlane(move, m_GroundNormal); //orig code line
		move = Vector3.Project(move, this.transform.forward);

		// send input and other state parameters to the animator
		Vector3 mVelocity = (move*movementSpeed);
		return mVelocity;
	}

}
