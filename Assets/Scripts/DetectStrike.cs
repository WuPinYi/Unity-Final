﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectStrike : MonoBehaviour {
	public GameObject pitcher;
	public GameObject field;
	public Camera hitterCamera;
	public Camera pitcherCamera;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if (field.GetComponent<Game> ().nowAttack == "visitor") {
			pitcher.GetComponent<Pitch> ().ballPositionImage.transform.position = hitterCamera.WorldToScreenPoint (col.gameObject.transform.position);
		} else {
			pitcher.GetComponent<Pitch> ().ballPositionImage.transform.position = pitcherCamera.WorldToScreenPoint (col.gameObject.transform.position);
		}
		pitcher.GetComponent<Pitch> ().isStrike = true;
		Invoke ("ChangeImagePosition", 1.5f);
	}

	public void ChangeImagePosition(){
		pitcher.GetComponent<Pitch> ().ballPositionImage.transform.position = new Vector3 (-10 ,-10, -10);
	}
}
