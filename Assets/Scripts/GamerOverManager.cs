using UnityEngine;
using System.Collections;

public class GamerOverManager : MonoBehaviour {

	public GameObject boss;
	public GameObject windows;
	public GameObject popupMediumWin;
	// Use this for initialization
	void Start () {
	
	}
	public void StartGameOver(){
		boss.SetActive(true);
		gameObject.SetActive(true);
		windows.SetActive(false);
		GetComponents<AudioSource>()[0].Play();
	}
	public void StartMediumEnding() {
		windows.SetActive(false);
		popupMediumWin.SetActive(true);
		GetComponents<AudioSource>()[1].Play();
	}
	// Update is called once per frame
	void Update () {
		
	}
}
