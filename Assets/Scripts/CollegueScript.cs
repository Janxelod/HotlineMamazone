﻿using UnityEngine;
using System.Collections;

public class CollegueScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Animator>().SetBool("startBlink",true);
		Invoke("RestartAnim",5);
	}

	public void RestartAnim(){
		GetComponent<Animator>().SetBool("startBlink",true);
	}
	public void StartLookingAtYou(){
		CancelInvoke();
		if(!GetComponent<Animator>().GetBool("lookingAtYou")){
			GetComponent<Animator>().SetBool("lookingAtYou",true);	
		}

	}
	public void FinishLookingAtYou(){
		GetComponent<Animator>().SetBool("lookingAtYou",false);	
		Invoke("RestartAnim",5);
	}
	// Update is called once per frame
	void Update () {
	
	}
	public void FinishAnim(){
		GetComponent<Animator>().SetBool("startBlink",false);		
		Invoke("RestartAnim",5);
	}

}
