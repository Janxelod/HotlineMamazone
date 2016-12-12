using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GamerOverManager : MonoBehaviour {

	public GameObject boss;
	public GameObject windows;
	public GameObject popUpMediumEnding;
	public GameObject popUpBadEnding;
	public GameObject popUpGoodEnding;
	// Use this for initialization
	void Start () {
	
	}
	public void StartGameOver(){
		gameObject.SetActive(true);
		boss.SetActive(true);
		popUpBadEnding.SetActive (true);
		windows.SetActive(false);
		GetComponents<AudioSource>()[0].Play();
	}
	public void StartMediumEnding() {
		gameObject.SetActive(true);
		popUpMediumEnding.SetActive(true);
		GameObject.Find("Messenger").SetActive(false);
		GetComponents<AudioSource>()[1].Play();
	}
	public void StartGoodEnding() {
		gameObject.SetActive(true);
		popUpGoodEnding.SetActive(true);
		//GameObject.Find("Messenger").SetActive(false);
		GetComponents<AudioSource>()[2].Play();
	}
	public void RestartGame(){
		GameObject initBackground = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().initBackground;
		initBackground.SetActive(true);
		initBackground.GetComponent<Animator>().SetBool("finishGame",true);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
