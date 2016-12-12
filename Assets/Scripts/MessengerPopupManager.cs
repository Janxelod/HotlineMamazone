using UnityEngine;
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
		Invoke("ShowMessengerPopUp2",3.5f);
	}
	void ShowMessengerPopUp2() {
		if(currentMessengerWindows<messengerPopUpList.Length) {
			GetComponent<AudioSource>().Play();
			messengerPopUpList[currentMessengerWindows].SetActive(true);
			messengerPopUpList[currentMessengerWindows].transform.SetAsLastSibling();
			currentMessengerWindows++;	
		}
	}
	void reshuffle(GameObject[] list)
	{
		// Knuth shuffle algorithm :: courtesy of Wikipedia :)
		for (int t = 0; t < list.Length; t++ ) {
			GameObject tmp = list[t];
			int r = Random.Range(t, list.Length);
			list[t] = list[r];
			list[r] = tmp;
		}
		for (int i = 0; i < list.Length; i++ ) {
			list[i].transform.SetSiblingIndex(i);
		}

	}
	// Update is called once per frame
	void Update () {
	
	}
}
