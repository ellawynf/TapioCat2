using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchAndGo : MonoBehaviour {
	
	[SerializeField]
	float moveSpeed = 5f;

	Rigidbody2D rb;

	Touch touch;
	Vector3 touchPosition, whereToMove;
	bool isMoving = false;

	//adding customers to queue
	public bool waiting = false;

	float previousDistanceToTouchPos, currentDistanceToTouchPos;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();

		// deactivate cup objects at start
		foreach (Transform child in transform){
			child.gameObject.SetActive(false);
		}
	}
	
	void Update () {

		StartCoroutine(addCustomer(60));

		if (isMoving)
			currentDistanceToTouchPos = (touchPosition - transform.position).magnitude;
		
		if (Input.touchCount > 0) {
			touch = Input.GetTouch (0);

			if (touch.phase == TouchPhase.Began) {
					previousDistanceToTouchPos = 0;
					currentDistanceToTouchPos = 0;
					isMoving = true;
					touchPosition = Camera.main.ScreenToWorldPoint (touch.position);
					touchPosition.z = 0;
					whereToMove = (touchPosition - transform.position).normalized;
					rb.velocity = new Vector2 (whereToMove.x * moveSpeed, whereToMove.y * moveSpeed);
				}
		}

		if (currentDistanceToTouchPos > previousDistanceToTouchPos) {
			isMoving = false;
			rb.velocity = Vector2.zero;
		}

		if (isMoving)
			previousDistanceToTouchPos = (touchPosition - transform.position).magnitude;
	}


	IEnumerator addCustomer(float time) {
		if (waiting == true || GamePlay.customerTotal >= 6){
			yield break;
		}
		GamePlay.customerQueue++;
		GamePlay.customerTotal++;
		yield return new WaitForSeconds(time);
	}
}