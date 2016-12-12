using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class InitBackgroundScript : MonoBehaviour {

	public GameObject initTitle;
	public GameObject background;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void RemoveInitBackground(){
		gameObject.SetActive(false);
		initTitle.GetComponent<Animator>().SetBool("moveTitle",true);
	}
	public void RemoveInitGameScreen(){
		initTitle.SetActive(false);
		background.SetActive(false);
		GameObject.Find("FakePhoneBody").SetActive(false);
		GameObject.Find("InitScreen").GetComponent<AudioSource>().Play();
	}
	public void InitGame(){
		GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().StartInitGame();
	}
	public void RestartGame(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex,LoadSceneMode.Single);
	}
}
