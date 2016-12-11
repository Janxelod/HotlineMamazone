﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MessengerPopupManager : MonoBehaviour {

	public GameObject[] messengerPopUpList;
	public int currentMessengerWindows;
	// Use this for initialization
	void Start () {
		reshuffle(messengerPopUpList);

	}
	public void showMessengerPopUp(){
		if(currentMessengerWindows<messengerPopUpList.Length) {
			messengerPopUpList[currentMessengerWindows].SetActive(true);
			currentMessengerWindows++;	
		}
	}
	void reshuffle(GameObject[] list)
	{
		// Knuth shuffle algorithm :: courtesy of Wikipedia :)
		for (int t = 0; t < list.Length; t++ )
		{
			GameObject tmp = list[t];
			int r = Random.Range(t, list.Length);
			list[t] = list[r];
			list[r] = tmp;
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
