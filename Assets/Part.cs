﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour{
	
	public bool working = true;
	public bool attached = true;
	public int health = 500;
	MeshCollider collider;

	void Start (){
		GetCollider ();
		if (collider != null) {
			collider.gameObject.AddComponent <PassCollision>();
			collider.gameObject.GetComponent <PassCollision> ().target = this;
		}
		if (health <= 0) {
			Detach ();
		}
	}

	void GetCollider (){
		if (GetComponent<MeshCollider> () == null) {
			if (transform.GetChild (0).GetComponent<MeshCollider> () == null) collider = null;
			else collider = transform.GetChild (0).GetComponent<MeshCollider> ();
		}
		else collider = GetComponent<MeshCollider> ();
	}

	public void OnCollisionEnter(Collision collision){
		print ("Collision");
	}

	public void Detach(){
		gameObject.AddComponent<Rigidbody> ();
		working = false;
		attached = false;
	}
}
