using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {
	public GameObject[] mistakesList;
	public int currentIndex;
	// Use this for initialization
	void Start () {
		currentIndex = 0;
	}
	void ShowMistake2() {
		mistakesList[currentIndex].SetActive(true);
	}
	public void showMistake(int index){
		currentIndex = index;
		Invoke("ShowMistake2",3.5f);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
