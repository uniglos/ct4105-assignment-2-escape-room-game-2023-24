﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragScript : MonoBehaviour
{
	// Variables to determine an offset between your finger touch
	// and a center of a game object so it will not jump to the touch position
	// when you move your finger for the first time
	float deltaX, deltaY;

	// allows to move a game object if you touch it
	bool moveAllowed = false;

	// allows to move only this particular game object
	// that you touched when touch began
	bool thisColTouched = false;

	// Reference to game objects RigidBody2D component
	Rigidbody2D rb;

	void Awake()
	{
		// Get game objects RigidBody2D component to be able to move it
		rb = GetComponent<Rigidbody2D> ();

		// Set isKinematic to true so if game object is not moved
		// by your finger it acts as an obstacle
		rb.isKinematic = true;
	}

	void Update()
	{
		// if you touch the devices screen
		if (Input.touchCount > 0) {

				// then get your touch
				Touch touch = Input.GetTouch (0);

				// and determine its position converted to World point
				Vector3 touchPos = Camera.main.ScreenToWorldPoint (touch.position);
				
				// processing touch phases
				switch (touch.phase) {

					// when you touches a screen for the first time
					case TouchPhase.Began:

						// and if you touches some object that has a collider and this script attached
						if (GetComponent<Collider2D> () == Physics2D.OverlapPoint (touchPos)) {

							// then you can move this particular game object
							thisColTouched = true;
							moveAllowed = true;
							rb.isKinematic = false;

							// and determine touch offset
							deltaX = touchPos.x - transform.position.x;
							deltaY = touchPos.y - transform.position.y;
						}
					break;

					// when you move your finger
					case TouchPhase.Moved:

						// and if you still touches this game object
						if (GetComponent<Collider2D> () == Physics2D.OverlapPoint (touchPos)
															&& moveAllowed
															&& thisColTouched)

								// then object is moved to the touch position
								// corrected by the offset
								rb.MovePosition (new Vector2 (touchPos.x - deltaX,
															touchPos.y - deltaY));
					break;

					// when you release your finger
					case TouchPhase.Ended:

						// you are not allowed to move this game object anymore
						moveAllowed = true;
						thisColTouched = false;

						// and this game object turns to obstacle
						rb.isKinematic = true;
					break;
				}
		}
	}
}

