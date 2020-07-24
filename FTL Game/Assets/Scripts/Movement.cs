using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
	// Start is called before the first frame update
	[SerializeField] Rigidbody2D rb;
	[SerializeField] float moveSpeed;
	[SerializeField] Text distanceText;
	[SerializeField] Text statsText;
	[SerializeField] GameObject playZone;
	[SerializeField] float zoneSectionZone = 100;

	Vector2 movement;
	public float distanceFromStartZone;
	float mapTop = 1000;
	float forceAtTop = 4;
	public float downForce;
	public float dragForce;
	float initalZoneForce;
	float initalZoneDrag;
	//Holo
	public GameObject hologram;
	public bool settingNewPos = false;

	bool canRotate = false;
	float rotateAmount = 5;

	private void Start()
	{
		//initalZoneForce = playZone.GetComponent<AreaEffector2D>().forceMagnitude;
		//initalZoneDrag = playZone.GetComponent<AreaEffector2D>().drag;
		distanceFromStartZone = transform.position.y - playZone.transform.position.y;
		hologram.SetActive(false);
	}


	// Update is called once per frame
	void Update()
	{
		CalculateGravity();

		//Holo
		if (hologram.activeSelf == true && settingNewPos)
		{
			hologram.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}

		if (canRotate)
		{
			hologram.transform.Rotate(0, 0, rotateAmount);
		}

	}

	private void CalculateGravity()
	{
		distanceFromStartZone = transform.position.y - playZone.transform.position.y;

		distanceText.text = "" + distanceFromStartZone;
		statsText.text = " Velocity = " + rb.velocity;

		float ratio = distanceFromStartZone / mapTop;
		downForce = Mathf.Lerp(0, forceAtTop, ratio) - initalZoneForce;
		downForce = Mathf.Clamp(downForce, 0, Mathf.Infinity);
		dragForce = downForce / 2 - initalZoneDrag;
		dragForce = Mathf.Clamp(dragForce, 0, Mathf.Infinity);

		float dragRatio = Mathf.Sqrt(Mathf.Pow(rb.rotation, 2)) / 90;
		dragRatio = Mathf.Clamp(dragRatio, 0, 1);
		dragForce = Mathf.Lerp(dragForce, dragForce / 2, dragRatio);
	}

	private void FixedUpdate()
	{
		//Movement
		//print(movement);
		rb.AddRelativeForce(movement*moveSpeed);
		rb.AddForce(new Vector2(0, -downForce));
		rb.drag = dragForce;
		//rb.MoveRotation(rb.rotation + -Input.GetAxisRaw("Horizontal"));
		//print(rb.velocity);
		
		

	}

	public void Confirm(InputAction.CallbackContext context)
	{
		if (settingNewPos == true)
		{
			settingNewPos = false;
			GetComponent<Unit>().setTarget(hologram.transform);

		}
	}

	public void RotateHoloLeft(InputAction.CallbackContext context)
	{
		
		if(settingNewPos == true && context.action.triggered)
		{
			canRotate = true;
			rotateAmount = Mathf.Abs(rotateAmount);
		}
		else
		{
			canRotate = false;
		}
	}

	public void RotateHoloRight(InputAction.CallbackContext context)
	{

		if (settingNewPos == true && context.action.triggered)
		{
			canRotate = true;
			rotateAmount = -Mathf.Abs(rotateAmount);
		}
		else
		{
			canRotate = false;
		}
	}

	public void ClickButtonToMove(InputAction.CallbackContext context)
	{
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		//print(mousePos);
		if (settingNewPos == false)
		{
			settingNewPos = true;
			hologram.SetActive(true);
		}
		else
		{
			settingNewPos = false;
		}

	}


}
