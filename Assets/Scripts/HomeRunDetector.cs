﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeRunDetector : MonoBehaviour {
	public GameObject field;
	public GameObject pitcher;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col){
		int playerOnBaseNum = field.GetComponent<BaseCondition> ().playerOnBaseNum;
		field.GetComponent<Game> ().AddPoint (playerOnBaseNum + 1);
		gameObject.GetComponent<MeshRenderer> ().material.color = Color.red;
		field.GetComponent<BaseCondition> ().SetBase ("Empty");
		field.GetComponent<Game> ().ToNextPlayer();
		field.GetComponent<Game>().isBallFlying = false;
		field.GetComponent<Game>().AddHitNum();
		field.GetComponent<Game> ().ShowImage ("HomeRun");
		Invoke ("SwitchCamera", 2f);
	}

	private void SwitchCamera(){
		field.GetComponent<Game>().isBallCameraMoving = false;
		pitcher.GetComponent<Pitch> ().cloneBall.SetActive (false);
		if (field.GetComponent<Game>().nowAttack == "visitor") {
			pitcher.GetComponent<Pitch> ().EnableReadyBtn ();
			field.GetComponent<SwitchCamera>().SwitchToHitterCamera();
		} else {
			pitcher.GetComponent<Pitch>().EnableChooseButton();
		}
	}
}
