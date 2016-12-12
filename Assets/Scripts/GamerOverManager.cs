using UnityEngine;
using System.Collections;

public class GamerOverManager : MonoBehaviour {

	public GameObject boss;
	public GameObject windows;
	public GameObject popupMediumWin;
	public GameObject pupUpBadEnding;
	// Use this for initialization
	void Start () {
	
	}
	public void StartGameOver(){
		gameObject.SetActive(true);
		boss.SetActive(true);
		pupUpBadEnding.SetActive (true);
		windows.SetActive(false);
		GetComponents<AudioSource>()[0].Play();
	}
	public void StartMediumEnding() {
		gameObject.SetActive(true);
		popupMediumWin.SetActive(true);

		GameObject.Find("Messenger").SetActive(false);
		GetComponents<AudioSource>()[1].Play();
	}
	// Update is called once per frame
	void Update () {
		
	}
}
