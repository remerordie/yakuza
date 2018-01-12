using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

	public Rigidbody2D bullet;
	public Transform firePoint;
	public float maxSpeed = 25.0f;
	public float fireRate = 0;
	public LayerMask ToHit;

	PlayerController playerController;
	SpriteRenderer spr;
	float timeToFire = 0;
	Vector3 objectPos;
	Vector2 mousePosition;
	float rotationSpeed = 5f;

	void Awake() {
		playerController = GetComponentInParent<PlayerController> ();
		spr = GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void Update () {
		if (fireRate == 0) {
			if (Input.GetButtonDown ("Fire1")) {
				mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
				Vector2 firePointPosition = new Vector2 (firePoint.position.x, firePoint.position.y);
				RaycastHit2D hit = Physics2D.Raycast (firePointPosition, mousePosition - firePointPosition, 100, ToHit);
				Debug.DrawLine (firePointPosition, (mousePosition-firePointPosition) *100, Color.yellow);
				if (hit.collider != null) {
					Debug.DrawLine (firePointPosition, hit.point, Color.red);
				}
				Rigidbody2D bul = Instantiate (bullet, firePointPosition, Quaternion.identity) as Rigidbody2D;
				var vel = bul.velocity;
				vel = transform.forward * maxSpeed;

				Physics2D.IgnoreCollision(bul.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());

				CameraShake.Shake(0.25f, 0.025f);
			}
		} else {
			if (Input.GetButtonDown ("Fire1") && Time.time > timeToFire) {
				timeToFire = Time.time + 1 / fireRate;
				mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
				Vector2 firePointPosition = new Vector2 (firePoint.position.x, firePoint.position.y);
				RaycastHit2D hit = Physics2D.Raycast (firePointPosition, mousePosition - firePointPosition, 100, ToHit);
				Debug.DrawLine (firePointPosition, (mousePosition-firePointPosition) *100, Color.yellow);
				if (hit.collider != null) {
					Debug.DrawLine (firePointPosition, hit.point, Color.red);
				}
				Rigidbody2D bul = Instantiate (bullet, firePointPosition, Quaternion.identity) as Rigidbody2D;
				bul.position = transform.forward * maxSpeed;

				Physics2D.IgnoreCollision(bul.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());

				CameraShake.Shake(0.25f, 0.025f);
			}
		}

		Vector2 direction = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		float angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
		Quaternion rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, maxSpeed * Time.deltaTime);
		if (direction.x > transform.position.x) {
			spr.flipY = false;
		} else if (direction.x < transform.position.y) {
			spr.flipY = true;	
		}
			
	}


	/*void Shoot() {
		mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
		Vector2 firePointPosition = new Vector2 (firePoint.position.x, firePoint.position.y);
		RaycastHit2D hit = Physics2D.Raycast (firePointPosition, mousePosition - firePointPosition, 100, ToHit);
		Debug.DrawLine (firePointPosition, (mousePosition-firePointPosition) *100, Color.yellow);
		if (hit.collider != null) {
			Debug.DrawLine (firePointPosition, hit.point, Color.red);
		}
		Rigidbody2D bul = Instantiate (bullet, firePointPosition, Quaternion.identity) as Rigidbody2D;
		bul.position = transform.forward * maxSpeed;

		Physics2D.IgnoreCollision(bul.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());

		CameraShake.Shake(0.25f, 0.025f);
	}*/
			
}
