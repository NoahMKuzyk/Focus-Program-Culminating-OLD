﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneWrapper : MonoBehaviour {

	//This is the code that will manage the components of the plane so that other scripts can be more simplified. This will be specialised to this specific plane 

	//Landing gear
	public GameObject noseGear;
	public GameObject leftGear;
	public GameObject rightGear;
	public bool noseGearWorking = true;
	public bool leftGearWorking = true;
	public bool rightGearWorking = true;
	public GameObject tailHook;
	public bool tailHookWorking = true;
	//Elevators
	public GameObject leftElevator;
	public GameObject rightElevator;
	//Rudders, paddles are the control surfaces themselves
	public GameObject leftTail;
	public GameObject rightTail;
	public GameObject leftRudderPaddle;
	public GameObject rightRudderPaddle;
	//Canopy
	public GameObject canopy;
	public GameObject frontSeat;
	public GameObject backSeat;

	// Use this for initialization
	void Start () {
		
	}


	public void ToggleGear(){
		print ("Toggle Gear");
		noseGear.GetComponent<Animator> ().SetTrigger ("Toggle gear");
		leftGear.GetComponent<Animator> ().SetTrigger ("Toggle gear");
		rightGear.GetComponent<Animator> ().SetTrigger ("Toggle gear");
	}

	public void ToggleCanopy(){
		canopy.GetComponent<Animator> ().SetTrigger ("Toggle canopy");
	}

	public void ToggleHook(){
		tailHook.GetComponent<Animator> ().SetTrigger ("Toggle hook");
	}

	public void RotateElevator(float angle){
		rightElevator.transform.localEulerAngles = new Vector3 (0, angle, 0);
		leftElevator.transform.localEulerAngles = new Vector3 (0, angle, 0);
		leftElevator.GetComponent<Rigidbody> ().AddRelativeForce (new Vector3(0, 0, angle/10));
		rightElevator.GetComponent<Rigidbody> ().AddRelativeForce (new Vector3(0, 0, angle/10));
	}

	public void RotateRudder(float angle){
		rightRudderPaddle.transform.localEulerAngles = new Vector3 (rightRudderPaddle.transform.localEulerAngles.x, rightRudderPaddle.transform.localEulerAngles.y, angle);
		leftRudderPaddle.transform.localEulerAngles = new Vector3 (leftRudderPaddle.transform.localEulerAngles.x, leftRudderPaddle.transform.localEulerAngles.y, -angle);
	}

	public void Eject(){
		canopy.SetActive (false);
		frontSeat.GetComponent<Eject> ().Fire (5);
		backSeat.GetComponent<Eject> ().Fire (0);
	}
}
