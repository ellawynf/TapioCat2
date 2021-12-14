using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchAndGo : MonoBehaviour {
	
	[SerializeField]
	float moveSpeed = 5f;

	Rigidbody2D rb;
	
	public Animator animator;
	public float screenWidth;
	private float horizontal = 0;
	Touch touch;
	Vector3 touchPosition, whereToMove;
	bool isMoving = false;

	//adding customers to queue
	public float queueGrowthTime = 30.0f;
	public bool waiting = false;

	float previousDistanceToTouchPos, currentDistanceToTouchPos;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator>();
		screenWidth = Screen.width;

		// deactivate cup objects in player's hand at start
		foreach (Transform child in transform){
			child.gameObject.SetActive(false);
		}
			
	}
	
	void Update () {

		StartCoroutine(addCustomer(queueGrowthTime)); //check if we should add someone

		if (isMoving)
			currentDistanceToTouchPos = (touchPosition - transform.position).magnitude;
		
		if (Input.touchCount > 0) {
			touch = Input.GetTouch (0);

			if (touch.phase == TouchPhase.Began) {
				if (touch.position.x > screenWidth / 2) {
					if(GamePlay.pickup == true) {
						horizontal = 1.0f;
						transform.localScale = new Vector3(-1, 1, 1);
					} else {
						horizontal = 1.0f;
						transform.localScale = new Vector3(1, 1, 1);
					}
				}
				if (touch.position.x < screenWidth / 2)
				{
					if(GamePlay.pickup == true) {
						horizontal = -1.0f;
						transform.localScale = new Vector3(1, 1, 1);
					} else {
						horizontal = -1.0f;
						transform.localScale = new Vector3(-1, 1, 1);
					}
				}
				previousDistanceToTouchPos = 0;
				currentDistanceToTouchPos = 0;
				isMoving = true;
				touchPosition = Camera.main.ScreenToWorldPoint (touch.position);
				touchPosition.z = 0;
				whereToMove = (touchPosition - transform.position).normalized;
				rb.velocity = new Vector2 (whereToMove.x * moveSpeed, whereToMove.y * moveSpeed);
			}
		} else if (currentDistanceToTouchPos > previousDistanceToTouchPos) {
			isMoving = false;
			rb.velocity = Vector2.zero;
			horizontal = 0.0f;
		}

		if (isMoving)
			previousDistanceToTouchPos = (touchPosition - transform.position).magnitude;

		animator.SetFloat("Horizontal", horizontal);
		animator.SetBool("HoldDrink", GamePlay.pickup);
	}

	IEnumerator addCustomer(float time) {
		if (waiting == true || GamePlay.customerTotal >= 6){ // if we already know we are waiting to add someone or we have hit the customer limit
			yield break;
		}
		waiting = true; //know we are waiting
		GamePlay.customerQueue++; //increment both the queue and the total num of customers seen in the level
		GamePlay.customerTotal++;
		print("JUST ADDED SOMEONE TO THE QUEUE: ");
		print(GamePlay.customerQueue);
		yield return new WaitForSeconds(time); //wait to execute all code between if and here until time seconds
		waiting = false; //reset our waiting
	}
}