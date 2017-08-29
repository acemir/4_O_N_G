using UnityEngine;
using System.Collections;

/// <summary>
/// This behaviour is attached to a player.
/// It controls the movement of the player with the keyboard.
/// </summary>
public class Player : MonoBehaviour
{
	
	/// <summary>
	/// The units a player moves per second along the z axis.
	/// </summary>
	public float speed = 15f;
	/// <summary>
	/// Indicates this player position.
	/// </summary>
	public ePlayer player;

	private Rigidbody rb;

	void Start ()
	{

		rb = GetComponent<Rigidbody> ();
	}

	/// <summary>
	/// Updates the player position.
	/// We use FixedUpdate() instead of Update(), because the collision of the player is controlled by the physic engine.
	/// </summary>
	void FixedUpdate ()
	{
		// input speed of keyboard from -1 to 1
		float inputSpeed = 0f;
		if (player == ePlayer.Front) {
			inputSpeed = Input.GetAxisRaw ("PlayerFront");
		} else if (player == ePlayer.Left) {
			inputSpeed = Input.GetAxisRaw ("PlayerFront");
		} else if (player == ePlayer.Back) {
			inputSpeed = Input.GetAxisRaw ("PlayerBack");
		} else if (player == ePlayer.Right) {
			inputSpeed = Input.GetAxisRaw ("PlayerBack");
		}

		if (player == ePlayer.Front || player == ePlayer.Back) {
			// moves player along the x axis
			transform.position += new Vector3 (inputSpeed * speed * Time.deltaTime, 0f, 0f);

			/// <summary>
			/// Limits position to the court (needed if no rigibody)
			/// </summary>
			// var position = transform.position;
			// position.x = Mathf.Clamp (transform.position.x, -5.25f, 5.25f);
			// transform.position = position;
		} else if (player == ePlayer.Left || player == ePlayer.Right) {
			// moves player along the y axis
			transform.position += new Vector3 (0f, 0f, inputSpeed * speed * Time.deltaTime);

			/// <summary>
			/// Limits position to the court (needed if no rigibody)
			/// </summary>
			// var position = transform.position;
			// position.z = Mathf.Clamp (transform.position.z, -5.25f, 5.25f);
			// transform.position = position;
			
		}

		if (rb != null) {
			// GetComponent<Rigidbody>().AddForce(0);
			rb.velocity = Vector3.zero;
		}
	}

	void OnCollisionEnter(Collision col)
	{
		// Has the GameObject that collides the Ball component?
		Ball ball = col.gameObject.GetComponent<Ball>();

		/// <summary>
		/// Maskes the Bump rotate a little depending o the side it hits the ball
		/// </summary>
		// if (ball != null) {
		// 	var direction = transform.InverseTransformPoint (col.transform.position);

		// 	var rotationVector = transform.rotation.eulerAngles;

		// 	if (direction.x > 0f) { //Change the axis to fit your needs
		// 		rotationVector.y -= 15f;
		// 	} else if (direction.x < 0f) {
		// 		rotationVector.y += 15f;
		// 	}

		// 	transform.rotation = Quaternion.Euler(rotationVector);
		// }
	}
}
