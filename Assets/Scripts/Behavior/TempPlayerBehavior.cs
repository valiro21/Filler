using UnityEngine;
using System.Collections;

public class TempPlayerBehavior : MonoBehaviour {

	public bool Frozen = false;
	public float RadiusLerpSpeed = 1f;

	public void Unfreeze () {
		transform.rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
		transform.rigidbody.useGravity = true;
		Frozen = false;
	}

	void OnCollisionEnter ( Collision collision ) {
		if (Frozen) {
			if ( collision.collider.tag == "Ball" )
				Unfreeze ();
			else if  ( collision.collider.tag == "Bullet" ) {
				Unfreeze ();
				//GameController.LoseHP ();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Frozen) {
			Vector3 position = InputController.GetInput ();
			float Radius = gameObject.transform.localScale.x / 2;
			Radius += RadiusLerpSpeed * Time.deltaTime;
			if ( ( GameController.DownWall + 2 * Radius > GameController.UpperWall) ||
			    ( GameController.LeftWall + 2 * Radius > GameController.RightWall ) ) {
				Unfreeze ();
				return ;
			}

			//test UpperMagrin
			if ( position.y + Radius > GameController.UpperWall )
				position.y = GameController.UpperWall - Radius;

			//testDownMargin
			if ( position.y - Radius <  GameController.DownWall )
				position.y = GameController.DownWall + Radius;

			//test RightMargin
			if ( position.x + Radius > GameController.RightWall )
				position.x = GameController.RightWall - Radius;

			//test LeftMargin
			if ( position.x - Radius < GameController.LeftWall )
				position.x = GameController.LeftWall + Radius;

			Radius *= 2;
			gameObject.transform.localScale = new Vector3 ( Radius, Radius, Radius );
			gameObject.transform.position = position;
		}
	}
}
