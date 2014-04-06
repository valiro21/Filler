using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public float MovementForce = 3f;

	// Use this for initialization
	void Start () {
		rigidbody.AddForce ( transform.position - new Vector3( 0f, 0f, 0f ) * MovementForce, ForceMode.Impulse );
	}
	
	// Update is called once per frame
	void Update () {
		float x = rigidbody.velocity.x > 0 ? 1 : (rigidbody.velocity.x < 0) ? -1 : 0;
		float y = rigidbody.velocity.y > 0 ? 1 : (rigidbody.velocity.y < 0) ? -1 : 0;
		if ( x==0 || y ==0 )
			rigidbody.AddForce ( transform.position - new Vector3( 0f, 0f, 0f ) * MovementForce, ForceMode.Impulse );
		else
			rigidbody.velocity = new Vector3 (x, y, 0f) * MovementForce;
	}
}
