using UnityEngine;
using System.Collections;

public class CollegueScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Animator>().SetBool("startBlink",true);
		Invoke("RestartAnim",5);
	}

	void RestartAnim(){
		GetComponent<Animator>().SetBool("startBlink",true);
	}
	// Update is called once per frame
	void Update () {
	
	}
	public void FinishAnim(){
		GetComponent<Animator>().SetBool("startBlink",false);		
		Invoke("RestartAnim",5);
	}

}
